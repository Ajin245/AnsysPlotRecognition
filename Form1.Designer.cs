﻿
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.selectRegion = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.recognizeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fragmentPicBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.recognRichTBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.filesTreeView = new System.Windows.Forms.TreeView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLogLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.checkBoxForAll = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentPicBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1168, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileToolStripMenuItem1});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 19);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenFileToolStripMenuItem1
            // 
            this.OpenFileToolStripMenuItem1.Name = "OpenFileToolStripMenuItem1";
            this.OpenFileToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.OpenFileToolStripMenuItem1.Text = "Открыть";
            this.OpenFileToolStripMenuItem1.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectRegion,
            this.toolStripSeparator3,
            this.recognizeBtn,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1168, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // selectRegion
            // 
            this.selectRegion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectRegion.Image = ((System.Drawing.Image)(resources.GetObject("selectRegion.Image")));
            this.selectRegion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectRegion.Name = "selectRegion";
            this.selectRegion.Size = new System.Drawing.Size(111, 22);
            this.selectRegion.Text = "Выделить область";
            this.selectRegion.Click += new System.EventHandler(this.selectRegionBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // recognizeBtn
            // 
            this.recognizeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.recognizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("recognizeBtn.Image")));
            this.recognizeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recognizeBtn.Name = "recognizeBtn";
            this.recognizeBtn.Size = new System.Drawing.Size(73, 22);
            this.recognizeBtn.Text = "Распознать";
            this.recognizeBtn.Click += new System.EventHandler(this.recognizeBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.30625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.56202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.13173F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.filesTreeView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 499F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1168, 499);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.99307F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.00693F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxForAll, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(771, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 493);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.fragmentPicBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 240);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фрагмент для анализа:";
            // 
            // fragmentPicBox
            // 
            this.fragmentPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fragmentPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fragmentPicBox.Location = new System.Drawing.Point(3, 20);
            this.fragmentPicBox.Margin = new System.Windows.Forms.Padding(0);
            this.fragmentPicBox.Name = "fragmentPicBox";
            this.fragmentPicBox.Size = new System.Drawing.Size(382, 217);
            this.fragmentPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fragmentPicBox.TabIndex = 5;
            this.fragmentPicBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.recognRichTBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 241);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Распознанный текст";
            // 
            // recognRichTBox
            // 
            this.recognRichTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recognRichTBox.Location = new System.Drawing.Point(3, 20);
            this.recognRichTBox.Name = "recognRichTBox";
            this.recognRichTBox.Size = new System.Drawing.Size(192, 218);
            this.recognRichTBox.TabIndex = 4;
            this.recognRichTBox.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(216, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(549, 493);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // filesTreeView
            // 
            this.filesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesTreeView.Location = new System.Drawing.Point(3, 3);
            this.filesTreeView.Name = "filesTreeView";
            this.filesTreeView.Size = new System.Drawing.Size(207, 493);
            this.filesTreeView.TabIndex = 6;
            this.filesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.filesTreeView_AfterSelect);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 549);
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
            // checkBoxForAll
            // 
            this.checkBoxForAll.AutoSize = true;
            this.checkBoxForAll.Location = new System.Drawing.Point(207, 249);
            this.checkBoxForAll.Name = "checkBoxForAll";
            this.checkBoxForAll.Size = new System.Drawing.Size(162, 22);
            this.checkBoxForAll.TabIndex = 10;
            this.checkBoxForAll.Text = "Выделить для всех";
            this.checkBoxForAll.UseVisualStyleBackColor = true;
            this.checkBoxForAll.CheckedChanged += new System.EventHandler(this.checkBoxForAll_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Ansys Plot Recognition";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fragmentPicBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton recognizeBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox recognRichTBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton selectRegion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox fragmentPicBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TreeView filesTreeView;
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
    }
}
