using AnsysPlotRecognition.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AnsysPlotRecognition
{
    public partial class MainForm : Form
    {
        Recognizer recognizer = new Recognizer(@".\lang\");

        BindingList<PlotResult> plotResults = new BindingList<PlotResult>();

        private static readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();

        RectangleF region = RectangleF.Empty;
        RectangleF imgArea = RectangleF.Empty;
        Rectangle crop = Rectangle.Empty;

        PointF startPoint = PointF.Empty;

        bool pictureLoaded = false;
        bool selecting, mouseDown = false;

        float zoom = 1f;

        string directoryPath = Directory.GetCurrentDirectory();

        public MainForm()
        {
            InitializeComponent();
            toolStripStatusX.Text = "0";
            toolStripStatusY.Text = "0";
            toolStripLogLabel.Text = "...";

            //Data bindings
            filesListBox.DataSource = plotResults;
            originalPicBox.DataBindings.Add(new Binding("Image", plotResults, "OriginalImg",true, DataSourceUpdateMode.OnPropertyChanged));
            fragmentPicBox.DataBindings.Add(new Binding("Image", plotResults, "CropImg", true, DataSourceUpdateMode.OnPropertyChanged));
            recognRichTBox.DataBindings.Add(new Binding("Text", plotResults, "RecognizedText", true, DataSourceUpdateMode.OnPropertyChanged));

            //exportToExcelBtn.DataBindings.Add(new Binding("Enabled", recognRichTBox, ""))
            _log.Info("Open MainForm");
        }


        private void selectRegionBtn_Click(object sender, EventArgs e)
        {
            toolStripProgressBar.Value = 0;
            if (pictureLoaded)
            {
                selecting = true;

            }
            checkBoxForAll.Enabled = false;
        }

        #region Drawing
        /// <summary>
        /// Метод определения коэффициента масштабирования изображения при отображении в PictureBox с опцией SizeMode: Zoom
        /// </summary>
        /// <param name="pbox">PictureBox в котором отображается масштабированное изображение</param>
        /// <param name="ImgArea">Область, которую занимает изображение при отображении</param>
        /// <param name="zoom">Коэффициент масштабирования</param>
        private void SetImageScale(PictureBox pbox, out RectangleF ImgArea, out float zoom)
        {
            SizeF sp = pbox.ClientSize;
            SizeF si = pbox.Image.Size;
            float rp = sp.Width / sp.Height;   // calculate the ratios of
            float ri = si.Width / si.Height;   // pbox and image

            if (rp > ri)
            {
                zoom = 1f * sp.Height / si.Height;
                float width = si.Width * zoom;
                float left = (sp.Width - width) / 2;
                ImgArea = new RectangleF(left, 0, width, sp.Height);
            }
            else
            {
                zoom = 1f * sp.Width / si.Width;
                float height = si.Height * zoom;
                float top = (sp.Height - height) / 2;
                ImgArea = new RectangleF(0, top, sp.Width, height);
            }
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mouseDown)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Red, 3f), Rectangle.Round(region));
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureLoaded & selecting)
            {
                mouseDown = true;
                startPoint = e.Location;

                if (e.X <= imgArea.Left)
                {
                    startPoint.X = imgArea.Left;
                }
                if (e.Y <= imgArea.Top)
                {
                    startPoint.Y = imgArea.Top;
                }
                if (e.X >= imgArea.Right)
                {
                    startPoint.X = imgArea.Right;
                }
                if (e.Y >= imgArea.Bottom)
                {
                    startPoint.Y = imgArea.Bottom;
                }
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (pictureLoaded && selecting)
            {
                selecting = false;
                mouseDown = false;
                
                Bitmap originalPic = (Bitmap)originalPicBox.Image;
                try
                {
                    fragmentPicBox.Image = originalPic.Clone(crop, System.Drawing.Imaging.PixelFormat.DontCare);
                    PlotResult currentPlot = (PlotResult)filesListBox.SelectedItem;
                    currentPlot.CropImg = fragmentPicBox.Image;
                }
                catch (Exception ex)
                {
                    toolStripLogLabel.Text = ex.Message;
                    MessageBox.Show(ex.Message);
                }
                checkBoxForAll.Enabled = true;
                
                this.Cursor = Cursors.Default;
            }
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (pictureLoaded && selecting)
            {
                this.Cursor = Cursors.Cross;
            }
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (pictureLoaded && selecting)
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureLoaded)
            {
                if (selecting)
                {
                    //Позиция прямоугольника выбора
                    float posX = Math.Min(startPoint.X, e.X);
                    float posY = Math.Min(startPoint.Y, e.Y);

                    //Ширина и высота прямоугольника выбора
                    float width = Math.Max(startPoint.X, e.X) - Math.Min(startPoint.X, e.X);
                    float height = Math.Max(startPoint.Y, e.Y) - Math.Min(startPoint.Y, e.Y);
                    
                    #region Ограничитель рамки
                    if (e.X <= imgArea.Left)
                    {
                        posX = imgArea.Left;
                        width = startPoint.X - imgArea.Left;
                    }
                    if (e.Y <= imgArea.Top)
                    {
                        posY = imgArea.Top;
                        height = startPoint.Y - imgArea.Top;
                    }
                    if (e.X >= imgArea.Right)
                    {
                        width = imgArea.Right - startPoint.X;
                    }
                    if (e.Y >= imgArea.Bottom)
                    {
                        height = imgArea.Bottom - startPoint.Y;
                    }
                    #endregion

                    ///При использовании Zoom в свойствах отрисовки PictureBox отображение Image происходит "поверх" оригинального
                    ///и имеет свои размеры. Для правильного выделения прямоугольником нужно иметь новую СК, перестраиваемую при изменении окна
                    SetImageScale(originalPicBox, out imgArea, out zoom);
                    region = new RectangleF(posX, posY, width, height);

                    Point RLoc = Point.Round(new PointF((region.X - imgArea.X) / zoom,
                                     (region.Y - imgArea.Y) / zoom));
                    Size RSz = Size.Round(new SizeF(region.Width / zoom, region.Height / zoom));
                    
                    crop = new Rectangle(RLoc, RSz);

                    if (sender is PictureBox t)
                    {
                        t.Refresh();
                    }
                }
                toolStripStatusX.Text = e.X.ToString();
                toolStripStatusY.Text = e.Y.ToString();
            }
        }
        #endregion

        private void Recognize(bool all = true)
        {
            toolStripProgressBar.Maximum = plotResults.Count;
            if (all)
            {
                foreach (var plot in plotResults)
                {
                    (string recognizedText, bool succed) = recognizer.RecognizeIt((Bitmap)plot.OriginalImg, crop);

                    if (succed)
                    {
                        toolStripProgressBar.PerformStep();
                    }
                    Bitmap img = (Bitmap)plot.OriginalImg;
                    plot.CropImg = img.Clone(crop, System.Drawing.Imaging.PixelFormat.DontCare);
                    plot.RecognizedText = recognizedText;
                }
            }
            else
            {
                (string recognizedText, bool succed) = recognizer.RecognizeIt((Bitmap)fragmentPicBox.Image);

                if (succed)
                {
                    toolStripProgressBar.PerformStep();
                }
                recognRichTBox.Text = recognizedText;
            }
            recognRichTBox.Enabled = true;
            checkBoxForAll.Enabled = false;
            exportToExcelBtn.Enabled = true;
            toolStripProgressBar.Value = 0;
        }
        private void Export(bool all = true)
        {
            toolStripProgressBar.Maximum = plotResults.Count;

            //TODO Проработать логику установки пути
            ElementTableParser parser = new ElementTableParser($"{directoryPath}");
            List<SolutionInformation> solutions = new List<SolutionInformation>();
            if (all)
            {
                foreach (var result in plotResults)
                {
                    solutions.Add(parser.ParseSolutionInformation(result.RecognizedText));
                }
            }
            else
            {
                solutions.Add(parser.ParseSolutionInformation(recognRichTBox.Text));
            }
            parser.WriteReport(solutions);
        }
        private void exportToExcelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (recognRichTBox.Text == null)
                {
                    throw new Exception("Нет данных для экспорта");
                }
                else
                {
                    toolStripProgressBar.Value = 0;
                    if (checkBoxForAll.Checked)
                    {
                        Export(all: true);
                    }
                    else
                    {
                        Export(all: false);
                    }
                    MessageBox.Show("Экспорт данных завершен", "Результаты выгружены успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Обнаружена ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            //TODO Заполнить заглушку renameBtn_Click
        }

        private void openFilesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripProgressBar.Value = 0;

                plotResults.Clear();
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (var file in openFileDialog.FileNames)
                    {
                        PlotResult plot = new PlotResult(file);
                        plotResults.Add(plot);
                    }
                    toolStripLogLabel.Text = $"Загружено файлов: {plotResults.Count}";
                    pictureLoaded = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //TODO Заполнить заглушку формы лога
        }

        private void recognizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (fragmentPicBox.Image == null)
                {
                    throw new Exception("Не выбран фрагмент файла");
                }
                else
                {
                    toolStripProgressBar.Value = 0;

                    if (region != Rectangle.Empty)
                    {
                        if (checkBoxForAll.Checked)
                        {
                            Recognize(all: true);
                        }
                        else
                        {
                            Recognize(all: false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Обнаружена ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _log.Error(ex);
            }
        }

        

    }
}
