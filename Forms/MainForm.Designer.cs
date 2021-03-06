
namespace AnsysPlotRecognition
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.openFilesBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectRegionBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fragmentPicBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.recognRichTBox = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.recognizeBtn = new System.Windows.Forms.Button();
            this.renameBtn = new System.Windows.Forms.Button();
            this.exportToExcelBtn = new System.Windows.Forms.Button();
            this.checkBoxForAll = new System.Windows.Forms.CheckBox();
            this.originalPicBox = new System.Windows.Forms.PictureBox();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLogLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentPicBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFilesBtn,
            this.toolStripSeparator3,
            this.selectRegionBtn,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1168, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // openFilesBtn
            // 
            this.openFilesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFilesBtn.Image = ((System.Drawing.Image)(resources.GetObject("openFilesBtn.Image")));
            this.openFilesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFilesBtn.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.openFilesBtn.Name = "openFilesBtn";
            this.openFilesBtn.Size = new System.Drawing.Size(23, 22);
            this.openFilesBtn.Text = "toolStripButton1";
            this.openFilesBtn.ToolTipText = "Открыть файл изображения или несколько файлов\r\n";
            this.openFilesBtn.Click += new System.EventHandler(this.openFilesBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // selectRegionBtn
            // 
            this.selectRegionBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectRegionBtn.Image")));
            this.selectRegionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectRegionBtn.Name = "selectRegionBtn";
            this.selectRegionBtn.Size = new System.Drawing.Size(127, 22);
            this.selectRegionBtn.Text = "Выделить область";
            this.selectRegionBtn.Click += new System.EventHandler(this.selectRegionBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(31, 22);
            this.toolStripButton1.Text = "Лог";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.30625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.56202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.13173F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.originalPicBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.filesListBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 525F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1168, 525);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(771, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 519);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.fragmentPicBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 253);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фрагмент для анализа:";
            // 
            // fragmentPicBox
            // 
            this.fragmentPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fragmentPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fragmentPicBox.Location = new System.Drawing.Point(3, 20);
            this.fragmentPicBox.Name = "fragmentPicBox";
            this.fragmentPicBox.Size = new System.Drawing.Size(382, 230);
            this.fragmentPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fragmentPicBox.TabIndex = 0;
            this.fragmentPicBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.recognRichTBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 254);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Распознанный текст";
            // 
            // recognRichTBox
            // 
            this.recognRichTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recognRichTBox.Enabled = false;
            this.recognRichTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recognRichTBox.Location = new System.Drawing.Point(3, 20);
            this.recognRichTBox.Name = "recognRichTBox";
            this.recognRichTBox.Size = new System.Drawing.Size(185, 231);
            this.recognRichTBox.TabIndex = 4;
            this.recognRichTBox.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.recognizeBtn);
            this.groupBox3.Controls.Add(this.renameBtn);
            this.groupBox3.Controls.Add(this.exportToExcelBtn);
            this.groupBox3.Controls.Add(this.checkBoxForAll);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(200, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 254);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Отчет";
            // 
            // recognizeBtn
            // 
            this.recognizeBtn.Location = new System.Drawing.Point(6, 48);
            this.recognizeBtn.Name = "recognizeBtn";
            this.recognizeBtn.Size = new System.Drawing.Size(179, 40);
            this.recognizeBtn.TabIndex = 13;
            this.recognizeBtn.Text = "Распознать";
            this.recognizeBtn.UseVisualStyleBackColor = true;
            this.recognizeBtn.Click += new System.EventHandler(this.recognizeBtn_Click);
            // 
            // renameBtn
            // 
            this.renameBtn.Location = new System.Drawing.Point(6, 94);
            this.renameBtn.Name = "renameBtn";
            this.renameBtn.Size = new System.Drawing.Size(179, 40);
            this.renameBtn.TabIndex = 12;
            this.renameBtn.Text = "Переименовать";
            this.renameBtn.UseVisualStyleBackColor = true;
            this.renameBtn.Click += new System.EventHandler(this.renameBtn_Click);
            // 
            // exportToExcelBtn
            // 
            this.exportToExcelBtn.Enabled = false;
            this.exportToExcelBtn.Location = new System.Drawing.Point(6, 195);
            this.exportToExcelBtn.Name = "exportToExcelBtn";
            this.exportToExcelBtn.Size = new System.Drawing.Size(179, 40);
            this.exportToExcelBtn.TabIndex = 11;
            this.exportToExcelBtn.Text = "Выгрузить в Excel";
            this.exportToExcelBtn.UseVisualStyleBackColor = true;
            this.exportToExcelBtn.Click += new System.EventHandler(this.exportToExcelBtn_Click);
            // 
            // checkBoxForAll
            // 
            this.checkBoxForAll.AutoSize = true;
            this.checkBoxForAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxForAll.Enabled = false;
            this.checkBoxForAll.Location = new System.Drawing.Point(3, 20);
            this.checkBoxForAll.Name = "checkBoxForAll";
            this.checkBoxForAll.Size = new System.Drawing.Size(185, 22);
            this.checkBoxForAll.TabIndex = 10;
            this.checkBoxForAll.Text = "Выделить для всех";
            this.checkBoxForAll.UseVisualStyleBackColor = true;
            this.checkBoxForAll.CheckedChanged += new System.EventHandler(this.checkBoxForAll_CheckedChanged);
            // 
            // originalPicBox
            // 
            this.originalPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalPicBox.Location = new System.Drawing.Point(216, 3);
            this.originalPicBox.Name = "originalPicBox";
            this.originalPicBox.Size = new System.Drawing.Size(549, 519);
            this.originalPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalPicBox.TabIndex = 0;
            this.originalPicBox.TabStop = false;
            this.originalPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.originalPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.originalPicBox.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.originalPicBox.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.originalPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.originalPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // filesListBox
            // 
            this.filesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.ItemHeight = 18;
            this.filesListBox.Location = new System.Drawing.Point(3, 3);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.filesListBox.Size = new System.Drawing.Size(207, 519);
            this.filesListBox.TabIndex = 6;
            this.filesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.filesListBox_MouseDoubleClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PNG (.png)|*.png|JPG (.jpg)|*.jpg";
            this.openFileDialog.Multiselect = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelX,
            this.toolStripStatusX,
            this.toolStripStatusLabelY,
            this.toolStripStatusY,
            this.toolStripStatusSpace,
            this.toolStripLogLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 550);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1168, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelX
            // 
            this.toolStripStatusLabelX.Name = "toolStripStatusLabelX";
            this.toolStripStatusLabelX.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabelX.Text = "X:";
            // 
            // toolStripStatusX
            // 
            this.toolStripStatusX.Name = "toolStripStatusX";
            this.toolStripStatusX.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusX.Text = "toolStripStatusX";
            // 
            // toolStripStatusLabelY
            // 
            this.toolStripStatusLabelY.Name = "toolStripStatusLabelY";
            this.toolStripStatusLabelY.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabelY.Text = "Y:";
            // 
            // toolStripStatusY
            // 
            this.toolStripStatusY.Name = "toolStripStatusY";
            this.toolStripStatusY.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusY.Text = "toolStripStatusY";
            // 
            // toolStripStatusSpace
            // 
            this.toolStripStatusSpace.Name = "toolStripStatusSpace";
            this.toolStripStatusSpace.Size = new System.Drawing.Size(635, 17);
            this.toolStripStatusSpace.Spring = true;
            // 
            // toolStripLogLabel
            // 
            this.toolStripLogLabel.Name = "toolStripLogLabel";
            this.toolStripLogLabel.Size = new System.Drawing.Size(100, 17);
            this.toolStripLogLabel.Text = "toolStripLogLabel";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Maximum = 1000;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 572);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Ansys Plot Recognition";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fragmentPicBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox originalPicBox;
        private System.Windows.Forms.RichTextBox recognRichTBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton selectRegionBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSpace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelY;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusY;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLogLabel;
        private System.Windows.Forms.CheckBox checkBoxForAll;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.PictureBox fragmentPicBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button exportToExcelBtn;
        private System.Windows.Forms.Button recognizeBtn;
        private System.Windows.Forms.Button renameBtn;
        private System.Windows.Forms.ToolStripButton openFilesBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

