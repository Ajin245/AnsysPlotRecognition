using AnsysPlotRecognition.Models;
using ImageRecognition;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AnsysPlotRecognition
{
    public partial class MainForm : Form
    {
        PlotResult selectedPlot = new PlotResult();

        List<PlotResult> plotResults = new List<PlotResult>();

        RectangleF region = RectangleF.Empty;
        RectangleF imgArea = RectangleF.Empty;
        Rectangle crop = Rectangle.Empty;

        PointF startPoint = PointF.Empty;

        bool pictureLoaded = false;
        bool selecting, mouseDown = false;

        
        float zoom = 1f;

        //Для расчета progressbar 
        int filesCount = 0;

        public MainForm()
        {
            InitializeComponent();
            toolStripStatusX.Text = "0";
            toolStripStatusY.Text = "0";
            toolStripLogLabel.Text = "...";
            
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    PlotResult plot = new PlotResult(file);
                    plotResults.Add(plot);
                }
                toolStripLogLabel.Text = $"Загружено файлов: {filesCount}";

                filesCount = plotResults.Count;
                
                pictureLoaded = true;

                toolStripProgressBar.Maximum = filesCount;

                //Заполняем дерево именами файлов
                FillFilesTree(filesTreeView.Nodes);
                
                //При первой загрузке открываем первую картинку
                InitPlot(0);
            }
        }

        private void InitPlot(int id)
        {
            if (plotResults.Count != 0)
            {
                selectedPlot = plotResults[id];

                pictureBox1.Image = selectedPlot.OriginalImg;
                fragmentPicBox.Image = selectedPlot.CropImg;
                toolStripLogLabel.Text = $"Загружено изображение №{selectedPlot.Id}";
            }
        }
        
        private void FillFilesTree(TreeNodeCollection files)
        {
            foreach (PlotResult plotResult in plotResults)
            {
                var node = new TreeNode(plotResult.FIleName);
                node.Nodes.Add(new TreeNode(plotResult.FilePath));
                files.Add(node);
            }
        }

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
        
        private void recognizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPlot.CropImg == null)
                {
                    throw new Exception("Не выбран фрагмент файла");
                }
                else
                {
                    Recognizer recognizer = new Recognizer(@"C:\Users\OLEJA\source\repos\ImageRecognition\lang");
                    if (region != Rectangle.Empty)
                    {
                        (string recognizedText, bool succed) = recognizer.RecognizeIt((Bitmap)selectedPlot.CropImg);

                        if (succed)
                        {
                            toolStripProgressBar.PerformStep();
                        }
                        recognRichTBox.Text = recognizedText;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Обнаружена ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                
                //Bitmap h = (Bitmap)pictureBox1.Image;
                Bitmap h = (Bitmap)selectedPlot.OriginalImg;
                try
                {
                    Image cropImg = h.Clone(crop, System.Drawing.Imaging.PixelFormat.DontCare);
                    
                    selectedPlot.CropImg = cropImg;

                    fragmentPicBox.Image = cropImg;
                    
                    /// TODO: Дописать проверку
                    /// Если прямоугольник выбора рисуется изначально за пределами картинки
                }
                catch (Exception ex)
                {
                    toolStripLogLabel.Text = ex.Message;
                    MessageBox.Show(ex.Message);
                }
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
                    SetImageScale(pictureBox1, out imgArea, out zoom);
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

        private void filesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            InitPlot(e.Node.Index);
        }

        private void checkBoxForAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxForAll.Checked)
            {

            }
        }

        

        private void selectRegionBtn_Click(object sender, EventArgs e)
        {
            if (pictureLoaded)
            {
                selecting = true;
            }
        }

        
    }
}
