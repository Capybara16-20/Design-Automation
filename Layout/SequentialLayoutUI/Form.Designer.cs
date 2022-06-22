
namespace SequentialLayoutUI
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoadLists = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pArrangeConditions = new System.Windows.Forms.Panel();
            this.nudPinsCount = new System.Windows.Forms.NumericUpDown();
            this.lPinsCount = new System.Windows.Forms.Label();
            this.lElementsCount = new System.Windows.Forms.Label();
            this.nudElementsCount = new System.Windows.Forms.NumericUpDown();
            this.pCells = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pArrangeConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudElementsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLoadLists,
            this.menuItemArrange,
            this.toolStripSeparator,
            this.menuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItemFile.Text = "Файл";
            // 
            // menuItemLoadLists
            // 
            this.menuItemLoadLists.Name = "menuItemLoadLists";
            this.menuItemLoadLists.Size = new System.Drawing.Size(287, 22);
            this.menuItemLoadLists.Text = "Загрузить списки цепей по элементам";
            this.menuItemLoadLists.Click += new System.EventHandler(this.menuItemLoadLists_Click);
            // 
            // menuItemArrange
            // 
            this.menuItemArrange.Name = "menuItemArrange";
            this.menuItemArrange.Size = new System.Drawing.Size(287, 22);
            this.menuItemArrange.Text = "Скомпоновать блоки";
            this.menuItemArrange.Click += new System.EventHandler(this.menuItemArrange_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(284, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(287, 22);
            this.menuItemExit.Text = "Выход";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pArrangeConditions, 0, 0);
            this.tlpMain.Controls.Add(this.pCells, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(784, 437);
            this.tlpMain.TabIndex = 1;
            // 
            // pArrangeConditions
            // 
            this.pArrangeConditions.Controls.Add(this.nudPinsCount);
            this.pArrangeConditions.Controls.Add(this.lPinsCount);
            this.pArrangeConditions.Controls.Add(this.lElementsCount);
            this.pArrangeConditions.Controls.Add(this.nudElementsCount);
            this.pArrangeConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pArrangeConditions.Location = new System.Drawing.Point(3, 3);
            this.pArrangeConditions.Name = "pArrangeConditions";
            this.pArrangeConditions.Size = new System.Drawing.Size(778, 44);
            this.pArrangeConditions.TabIndex = 0;
            // 
            // nudPinsCount
            // 
            this.nudPinsCount.Location = new System.Drawing.Point(523, 3);
            this.nudPinsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPinsCount.Name = "nudPinsCount";
            this.nudPinsCount.Size = new System.Drawing.Size(50, 23);
            this.nudPinsCount.TabIndex = 3;
            this.nudPinsCount.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lPinsCount
            // 
            this.lPinsCount.AutoSize = true;
            this.lPinsCount.Location = new System.Drawing.Point(300, 5);
            this.lPinsCount.Name = "lPinsCount";
            this.lPinsCount.Size = new System.Drawing.Size(217, 15);
            this.lPinsCount.TabIndex = 2;
            this.lPinsCount.Text = "Ограничение на количество выходов:";
            // 
            // lElementsCount
            // 
            this.lElementsCount.AutoSize = true;
            this.lElementsCount.Location = new System.Drawing.Point(9, 5);
            this.lElementsCount.Name = "lElementsCount";
            this.lElementsCount.Size = new System.Drawing.Size(229, 15);
            this.lElementsCount.TabIndex = 1;
            this.lElementsCount.Text = "Ограничение на количество элементов:";
            // 
            // nudElementsCount
            // 
            this.nudElementsCount.Location = new System.Drawing.Point(244, 3);
            this.nudElementsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudElementsCount.Name = "nudElementsCount";
            this.nudElementsCount.Size = new System.Drawing.Size(50, 23);
            this.nudElementsCount.TabIndex = 0;
            this.nudElementsCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // pCells
            // 
            this.pCells.AutoScroll = true;
            this.pCells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCells.Location = new System.Drawing.Point(3, 53);
            this.pCells.Name = "pCells";
            this.pCells.Size = new System.Drawing.Size(778, 381);
            this.pCells.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Последовательная компоновка";
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.pArrangeConditions.ResumeLayout(false);
            this.pArrangeConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudElementsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadLists;
        private System.Windows.Forms.ToolStripMenuItem menuItemArrange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pArrangeConditions;
        private System.Windows.Forms.NumericUpDown nudPinsCount;
        private System.Windows.Forms.Label lPinsCount;
        private System.Windows.Forms.Label lElementsCount;
        private System.Windows.Forms.NumericUpDown nudElementsCount;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel pCells;
    }
}

