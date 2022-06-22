
namespace SequentialDistributionUI
{
    partial class MainForm
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
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCompose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbSourceData = new System.Windows.Forms.GroupBox();
            this.tlpSourceData = new System.Windows.Forms.TableLayoutPanel();
            this.pConditions = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPinsCount = new System.Windows.Forms.NumericUpDown();
            this.nudElementsCount = new System.Windows.Forms.NumericUpDown();
            this.lElementsCount = new System.Windows.Forms.Label();
            this.lbElements = new System.Windows.Forms.ListBox();
            this.lbChains = new System.Windows.Forms.ListBox();
            this.gbCalculation = new System.Windows.Forms.GroupBox();
            this.tlpCalulation = new System.Windows.Forms.TableLayoutPanel();
            this.pCalculationStep = new System.Windows.Forms.Panel();
            this.btnStepUp = new System.Windows.Forms.Button();
            this.btnStepBack = new System.Windows.Forms.Button();
            this.lbCalculation = new System.Windows.Forms.ListBox();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.lbResult = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.gbSourceData.SuspendLayout();
            this.tlpSourceData.SuspendLayout();
            this.pConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudElementsCount)).BeginInit();
            this.gbCalculation.SuspendLayout();
            this.tlpCalulation.SuspendLayout();
            this.pCalculationStep.SuspendLayout();
            this.gbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(884, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.menuItemCompose,
            this.toolStripSeparator,
            this.menuItemExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.Size = new System.Drawing.Size(125, 22);
            this.menuItemOpen.Text = "Open";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemCompose
            // 
            this.menuItemCompose.Name = "menuItemCompose";
            this.menuItemCompose.Size = new System.Drawing.Size(125, 22);
            this.menuItemCompose.Text = "Compose";
            this.menuItemCompose.Click += new System.EventHandler(this.menuItemCompose_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(122, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(125, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.Controls.Add(this.gbSourceData, 0, 0);
            this.tlpMain.Controls.Add(this.gbCalculation, 1, 0);
            this.tlpMain.Controls.Add(this.gbResult, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(884, 437);
            this.tlpMain.TabIndex = 1;
            // 
            // gbSourceData
            // 
            this.gbSourceData.Controls.Add(this.tlpSourceData);
            this.gbSourceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSourceData.Location = new System.Drawing.Point(3, 3);
            this.gbSourceData.Name = "gbSourceData";
            this.gbSourceData.Size = new System.Drawing.Size(259, 431);
            this.gbSourceData.TabIndex = 1;
            this.gbSourceData.TabStop = false;
            this.gbSourceData.Text = "Source Data";
            // 
            // tlpSourceData
            // 
            this.tlpSourceData.ColumnCount = 1;
            this.tlpSourceData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSourceData.Controls.Add(this.pConditions, 0, 2);
            this.tlpSourceData.Controls.Add(this.lbElements, 0, 0);
            this.tlpSourceData.Controls.Add(this.lbChains, 0, 1);
            this.tlpSourceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSourceData.Location = new System.Drawing.Point(3, 19);
            this.tlpSourceData.Name = "tlpSourceData";
            this.tlpSourceData.RowCount = 3;
            this.tlpSourceData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSourceData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tlpSourceData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpSourceData.Size = new System.Drawing.Size(253, 409);
            this.tlpSourceData.TabIndex = 0;
            // 
            // pConditions
            // 
            this.pConditions.Controls.Add(this.label1);
            this.pConditions.Controls.Add(this.nudPinsCount);
            this.pConditions.Controls.Add(this.nudElementsCount);
            this.pConditions.Controls.Add(this.lElementsCount);
            this.pConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pConditions.Location = new System.Drawing.Point(3, 331);
            this.pConditions.Name = "pConditions";
            this.pConditions.Size = new System.Drawing.Size(247, 75);
            this.pConditions.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pins count";
            // 
            // nudPinsCount
            // 
            this.nudPinsCount.Location = new System.Drawing.Point(195, 37);
            this.nudPinsCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPinsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPinsCount.Name = "nudPinsCount";
            this.nudPinsCount.Size = new System.Drawing.Size(40, 23);
            this.nudPinsCount.TabIndex = 2;
            this.nudPinsCount.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // nudElementsCount
            // 
            this.nudElementsCount.Location = new System.Drawing.Point(195, 8);
            this.nudElementsCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudElementsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudElementsCount.Name = "nudElementsCount";
            this.nudElementsCount.Size = new System.Drawing.Size(40, 23);
            this.nudElementsCount.TabIndex = 1;
            this.nudElementsCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lElementsCount
            // 
            this.lElementsCount.AutoSize = true;
            this.lElementsCount.Location = new System.Drawing.Point(10, 10);
            this.lElementsCount.Name = "lElementsCount";
            this.lElementsCount.Size = new System.Drawing.Size(89, 15);
            this.lElementsCount.TabIndex = 0;
            this.lElementsCount.Text = "Elements count";
            // 
            // lbElements
            // 
            this.lbElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbElements.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbElements.FormattingEnabled = true;
            this.lbElements.ItemHeight = 20;
            this.lbElements.Location = new System.Drawing.Point(3, 3);
            this.lbElements.Name = "lbElements";
            this.lbElements.Size = new System.Drawing.Size(247, 158);
            this.lbElements.TabIndex = 1;
            // 
            // lbChains
            // 
            this.lbChains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbChains.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbChains.FormattingEnabled = true;
            this.lbChains.ItemHeight = 20;
            this.lbChains.Location = new System.Drawing.Point(3, 167);
            this.lbChains.Name = "lbChains";
            this.lbChains.Size = new System.Drawing.Size(247, 158);
            this.lbChains.TabIndex = 2;
            // 
            // gbCalculation
            // 
            this.gbCalculation.Controls.Add(this.tlpCalulation);
            this.gbCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCalculation.Location = new System.Drawing.Point(268, 3);
            this.gbCalculation.Name = "gbCalculation";
            this.gbCalculation.Size = new System.Drawing.Size(436, 431);
            this.gbCalculation.TabIndex = 2;
            this.gbCalculation.TabStop = false;
            this.gbCalculation.Text = "Calculation";
            // 
            // tlpCalulation
            // 
            this.tlpCalulation.ColumnCount = 1;
            this.tlpCalulation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCalulation.Controls.Add(this.pCalculationStep, 0, 1);
            this.tlpCalulation.Controls.Add(this.lbCalculation, 0, 0);
            this.tlpCalulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCalulation.Location = new System.Drawing.Point(3, 19);
            this.tlpCalulation.Name = "tlpCalulation";
            this.tlpCalulation.RowCount = 2;
            this.tlpCalulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCalulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCalulation.Size = new System.Drawing.Size(430, 409);
            this.tlpCalulation.TabIndex = 0;
            // 
            // pCalculationStep
            // 
            this.pCalculationStep.Controls.Add(this.btnStepUp);
            this.pCalculationStep.Controls.Add(this.btnStepBack);
            this.pCalculationStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCalculationStep.Location = new System.Drawing.Point(3, 362);
            this.pCalculationStep.Name = "pCalculationStep";
            this.pCalculationStep.Size = new System.Drawing.Size(424, 44);
            this.pCalculationStep.TabIndex = 0;
            // 
            // btnStepUp
            // 
            this.btnStepUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStepUp.Location = new System.Drawing.Point(166, 10);
            this.btnStepUp.Name = "btnStepUp";
            this.btnStepUp.Size = new System.Drawing.Size(150, 25);
            this.btnStepUp.TabIndex = 1;
            this.btnStepUp.Text = "Step up";
            this.btnStepUp.UseVisualStyleBackColor = true;
            this.btnStepUp.Click += new System.EventHandler(this.btnStepUp_Click);
            // 
            // btnStepBack
            // 
            this.btnStepBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStepBack.Location = new System.Drawing.Point(10, 10);
            this.btnStepBack.Name = "btnStepBack";
            this.btnStepBack.Size = new System.Drawing.Size(150, 25);
            this.btnStepBack.TabIndex = 0;
            this.btnStepBack.Text = "Step back";
            this.btnStepBack.UseVisualStyleBackColor = true;
            this.btnStepBack.Click += new System.EventHandler(this.btnStepBack_Click);
            // 
            // lbCalculation
            // 
            this.lbCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCalculation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbCalculation.FormattingEnabled = true;
            this.lbCalculation.ItemHeight = 20;
            this.lbCalculation.Location = new System.Drawing.Point(3, 3);
            this.lbCalculation.Name = "lbCalculation";
            this.lbCalculation.Size = new System.Drawing.Size(424, 353);
            this.lbCalculation.TabIndex = 1;
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.lbResult);
            this.gbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResult.Location = new System.Drawing.Point(710, 3);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(171, 431);
            this.gbResult.TabIndex = 3;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Result";
            // 
            // lbResult
            // 
            this.lbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbResult.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbResult.FormattingEnabled = true;
            this.lbResult.ItemHeight = 20;
            this.lbResult.Location = new System.Drawing.Point(3, 19);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(165, 409);
            this.lbResult.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Компоновка по связности";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.gbSourceData.ResumeLayout(false);
            this.tlpSourceData.ResumeLayout(false);
            this.pConditions.ResumeLayout(false);
            this.pConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudElementsCount)).EndInit();
            this.gbCalculation.ResumeLayout(false);
            this.tlpCalulation.ResumeLayout(false);
            this.pCalculationStep.ResumeLayout(false);
            this.gbResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemCompose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbSourceData;
        private System.Windows.Forms.GroupBox gbCalculation;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.TableLayoutPanel tlpSourceData;
        private System.Windows.Forms.Panel pConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPinsCount;
        private System.Windows.Forms.NumericUpDown nudElementsCount;
        private System.Windows.Forms.Label lElementsCount;
        private System.Windows.Forms.ListBox lbElements;
        private System.Windows.Forms.ListBox lbChains;
        private System.Windows.Forms.TableLayoutPanel tlpCalulation;
        private System.Windows.Forms.Panel pCalculationStep;
        private System.Windows.Forms.Button btnStepBack;
        private System.Windows.Forms.Button btnStepUp;
        private System.Windows.Forms.ListBox lbCalculation;
        private System.Windows.Forms.ListBox lbResult;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

