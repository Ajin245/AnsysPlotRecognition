using AnsysPlotRecognition.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace AnsysPlotRecognition
{
    public partial class MainForm : Form
    {
        private readonly Recognizer recognizer = new Recognizer(@".\lang\");

        private readonly BindingList<PlotResult> plotResults = new BindingList<PlotResult>();

        //List<PlotResult> resultsForExport = new List<PlotResult>();
        //List<PlotResult> errorList = new List<PlotResult>();

        private static readonly Logger _log = LogManager.GetCurrentClassLogger();

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

            plotResults.ListChanged += PlotResults_ListChanged;
            //exportToExcelBtn.DataBindings.Add(new Binding("Enabled", recognRichTBox, ""))
        }

        private void PlotResults_ListChanged(object sender, ListChangedEventArgs e)
        {
            var h = e.PropertyDescriptor.Name;
        }

        private void selectRegionBtn_Click(object sender, EventArgs e)
        {
            toolStripProgressBar.Value = 0;
            if (pictureLoaded)
            {
                selecting = true;
            }
            //checkBoxForAll.Enabled = false;
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
                    _log.Error(ex);
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

        private void Recognize(PlotResult plotResult)
        {
            string recognizedText = recognizer.RecognizeIt((Bitmap)plotResult.OriginalImg, crop);
            Bitmap img = (Bitmap)plotResult.OriginalImg;
            plotResult.CropImg = img.Clone(crop, System.Drawing.Imaging.PixelFormat.DontCare);
            plotResult.RecognizedText = recognizedText;

            if (PlotInformationParser.ParseSolutionInformation(plotResult))
                plotResult.ParsingError = false;
            else
                plotResult.ParsingError = true;
        }
        //private void Export(bool all = true)
        //{
        //    toolStripProgressBar.Maximum = plotResults.Count;

        //    //TODO Проработать логику установки пути
        //    ElementTableParser parser = new ElementTableParser($"{directoryPath}");
        //    List<SolutionInformation> solutions = new List<SolutionInformation>();
        //    //TODO Переписать метод. Нужно парсить не весь массив plotResults или richTextBox, а непосредственно выделенные в ListBox элементы
        //    //Это добавит гибкости для обработки результатов пользователю. Дополнительно была добавлена возможность 
        //    //выделять несколько элементов в ListBox 
        //    if (all)
        //    {
        //        foreach (var result in plotResults)
        //        {
        //            solutions.Add(parser.ParseSolutionInformation(result.RecognizedText));
        //        }
        //    }
        //    else
        //    {
        //        solutions.Add(parser.ParseSolutionInformation(recognRichTBox.Text));
        //    }
        //    parser.WriteReport(solutions);
        //}
        private void Export()
        {
            List<SolutionInformation> solutionsForExport = new List<SolutionInformation>();
            
            foreach (PlotResult result in filesListBox.SelectedItems)
            {
                try
                {
                    PlotInformationParser.ParseSolutionInformation(result);
                    solutionsForExport.Add(result.SolutionInformation);
                }
                catch (Exception)
                {
                    //errorList.Add(result);
                }
            }
            Reporter.WriteReport(solutionsForExport, directoryPath);
        }
        private void exportToExcelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (recognRichTBox.Text == null)
                {
                    MessageBox.Show("Нет данных для экспорта","Необходим распознанный текст", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    toolStripProgressBar.Value = 0;
                    toolStripProgressBar.Maximum = filesListBox.SelectedItems.Count;
                    foreach (var exportItem in filesListBox.SelectedItems)
                    {
                        //Export(exportItem);
                        toolStripProgressBar.PerformStep();
                    }

                    MessageBox.Show("Экспорт данных завершен", "Результаты выгружены успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    recognRichTBox.Enabled = true;
                    toolStripProgressBar.Value = 0;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
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

        private void filesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (pictureLoaded)
            {
                PlotResult item = (PlotResult)filesListBox.SelectedItem;
                plotResults.Remove(item);
            }
        }

        private void checkBoxForAll_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureLoaded)
            {
                if (checkBoxForAll.CheckState == CheckState.Checked)
                {
                    for (int i = 0; i < filesListBox.Items.Count; i++)
                    {
                        filesListBox.SetSelected(i, true);
                    }
                }
                else
                {
                    filesListBox.SelectedItem = null;
                    filesListBox.SetSelected(0, true);
                }
            }
        }

        private void recognizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (fragmentPicBox.Image == null)
                {
                    MessageBox.Show("Необходимо выделить фрагмент изображения для распознавания", "Не выбран фрагмент файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    toolStripProgressBar.Value = 0;
                    toolStripProgressBar.Maximum = filesListBox.SelectedItems.Count;

                    int errors = 0;

                    List<PlotResult> listItems = filesListBox.SelectedItems.OfType<PlotResult>().ToList();

                    foreach (PlotResult plotResult in listItems)
                    {
                        Recognize(plotResult);
                        toolStripProgressBar.PerformStep();
                        if (plotResult.ParsingError)
                            errors++;
                    }
                    toolStripProgressBar.Value = 0;
                    //checkBoxForAll.Enabled = false;
                    
                    toolStripLogLabel.Text = $"Обработано: {listItems.Count} файлов";

                    if (errors > 0)
                    {
                        MessageBox.Show("Распознавание завершено c ошибками\nФайлы с ошибками выделены", "Результаты выгружены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        for (int i = 0; i < filesListBox.Items.Count; i++)
                        {
                            var selected = (PlotResult)filesListBox.Items[i];
                            filesListBox.SetSelected(i, selected.ParsingError);
                        }
                    }
                    else
                        MessageBox.Show("Распознавание завершено", "Результаты выгружены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    exportToExcelBtn.Enabled = true;
                    recognRichTBox.Enabled = true;
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
