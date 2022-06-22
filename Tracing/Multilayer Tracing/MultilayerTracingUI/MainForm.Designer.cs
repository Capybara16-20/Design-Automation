
namespace MultilayerTracingUI
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.pMenuFields = new System.Windows.Forms.Panel();
            this.nudColumns = new System.Windows.Forms.NumericUpDown();
            this.lColumns = new System.Windows.Forms.Label();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.lRows = new System.Windows.Forms.Label();
            this.btnAddField = new System.Windows.Forms.Button();
            this.btnRemoveField = new System.Windows.Forms.Button();
            this.pMenuElements = new System.Windows.Forms.Panel();
            this.btnClearCell = new System.Windows.Forms.Button();
            this.btnAddLockCell = new System.Windows.Forms.Button();
            this.btnAddTarget = new System.Windows.Forms.Button();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.pMenuCalculate = new System.Windows.Forms.Panel();
            this.btnShowPath = new System.Windows.Forms.Button();
            this.pFields = new System.Windows.Forms.Panel();
            this.tlpMain.SuspendLayout();
            this.tlpMenu.SuspendLayout();
            this.pMenuFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            this.pMenuElements.SuspendLayout();
            this.pMenuCalculate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpMenu, 0, 0);
            this.tlpMain.Controls.Add(this.pFields, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(834, 461);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpMenu
            // 
            this.tlpMenu.ColumnCount = 1;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Controls.Add(this.pMenuFields, 0, 0);
            this.tlpMenu.Controls.Add(this.pMenuElements, 0, 1);
            this.tlpMenu.Controls.Add(this.pMenuCalculate, 0, 2);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMenu.Location = new System.Drawing.Point(3, 3);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 3;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(194, 455);
            this.tlpMenu.TabIndex = 0;
            // 
            // pMenuFields
            // 
            this.pMenuFields.BackColor = System.Drawing.Color.LightGray;
            this.pMenuFields.Controls.Add(this.nudColumns);
            this.pMenuFields.Controls.Add(this.lColumns);
            this.pMenuFields.Controls.Add(this.nudRows);
            this.pMenuFields.Controls.Add(this.lRows);
            this.pMenuFields.Controls.Add(this.btnAddField);
            this.pMenuFields.Controls.Add(this.btnRemoveField);
            this.pMenuFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMenuFields.Location = new System.Drawing.Point(3, 3);
            this.pMenuFields.Name = "pMenuFields";
            this.pMenuFields.Size = new System.Drawing.Size(188, 114);
            this.pMenuFields.TabIndex = 0;
            // 
            // nudColumns
            // 
            this.nudColumns.Location = new System.Drawing.Point(70, 32);
            this.nudColumns.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudColumns.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Size = new System.Drawing.Size(40, 23);
            this.nudColumns.TabIndex = 1;
            this.nudColumns.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lColumns
            // 
            this.lColumns.AutoSize = true;
            this.lColumns.Location = new System.Drawing.Point(6, 34);
            this.lColumns.Name = "lColumns";
            this.lColumns.Size = new System.Drawing.Size(60, 15);
            this.lColumns.TabIndex = 4;
            this.lColumns.Text = "Столбцы:";
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(70, 3);
            this.nudRows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(40, 23);
            this.nudRows.TabIndex = 0;
            this.nudRows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lRows
            // 
            this.lRows.AutoSize = true;
            this.lRows.Location = new System.Drawing.Point(6, 5);
            this.lRows.Name = "lRows";
            this.lRows.Size = new System.Drawing.Size(50, 15);
            this.lRows.TabIndex = 2;
            this.lRows.Text = "Строки:";
            // 
            // btnAddField
            // 
            this.btnAddField.BackColor = System.Drawing.Color.Transparent;
            this.btnAddField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddField.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddField.Location = new System.Drawing.Point(0, 64);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(188, 25);
            this.btnAddField.TabIndex = 2;
            this.btnAddField.Text = "Добавить поле";
            this.btnAddField.UseVisualStyleBackColor = false;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // btnRemoveField
            // 
            this.btnRemoveField.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRemoveField.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveField.Location = new System.Drawing.Point(0, 89);
            this.btnRemoveField.Name = "btnRemoveField";
            this.btnRemoveField.Size = new System.Drawing.Size(188, 25);
            this.btnRemoveField.TabIndex = 3;
            this.btnRemoveField.Text = "Удалить поле";
            this.btnRemoveField.UseVisualStyleBackColor = false;
            this.btnRemoveField.Click += new System.EventHandler(this.btnRemoveField_Click);
            // 
            // pMenuElements
            // 
            this.pMenuElements.BackColor = System.Drawing.Color.LightGray;
            this.pMenuElements.Controls.Add(this.btnClearCell);
            this.pMenuElements.Controls.Add(this.btnAddLockCell);
            this.pMenuElements.Controls.Add(this.btnAddTarget);
            this.pMenuElements.Controls.Add(this.btnAddSource);
            this.pMenuElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMenuElements.Location = new System.Drawing.Point(3, 123);
            this.pMenuElements.Name = "pMenuElements";
            this.pMenuElements.Size = new System.Drawing.Size(188, 99);
            this.pMenuElements.TabIndex = 1;
            // 
            // btnClearCell
            // 
            this.btnClearCell.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClearCell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearCell.Location = new System.Drawing.Point(0, 75);
            this.btnClearCell.Name = "btnClearCell";
            this.btnClearCell.Size = new System.Drawing.Size(188, 23);
            this.btnClearCell.TabIndex = 3;
            this.btnClearCell.Text = "Очистить ячейку";
            this.btnClearCell.UseVisualStyleBackColor = true;
            this.btnClearCell.Click += new System.EventHandler(this.btnClearCell_Click);
            // 
            // btnAddLockCell
            // 
            this.btnAddLockCell.BackColor = System.Drawing.Color.Transparent;
            this.btnAddLockCell.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddLockCell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddLockCell.Location = new System.Drawing.Point(0, 50);
            this.btnAddLockCell.Name = "btnAddLockCell";
            this.btnAddLockCell.Size = new System.Drawing.Size(188, 25);
            this.btnAddLockCell.TabIndex = 2;
            this.btnAddLockCell.Text = "Добавить препятствие";
            this.btnAddLockCell.UseVisualStyleBackColor = false;
            this.btnAddLockCell.Click += new System.EventHandler(this.btnAddLockCell_Click);
            // 
            // btnAddTarget
            // 
            this.btnAddTarget.BackColor = System.Drawing.Color.Transparent;
            this.btnAddTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddTarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddTarget.Location = new System.Drawing.Point(0, 25);
            this.btnAddTarget.Name = "btnAddTarget";
            this.btnAddTarget.Size = new System.Drawing.Size(188, 25);
            this.btnAddTarget.TabIndex = 1;
            this.btnAddTarget.Text = "Добавить ячейку-цель";
            this.btnAddTarget.UseVisualStyleBackColor = false;
            this.btnAddTarget.Click += new System.EventHandler(this.btnAddTarget_Click);
            // 
            // btnAddSource
            // 
            this.btnAddSource.BackColor = System.Drawing.Color.Transparent;
            this.btnAddSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddSource.Location = new System.Drawing.Point(0, 0);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(188, 25);
            this.btnAddSource.TabIndex = 0;
            this.btnAddSource.Text = "Добавить ячейку-источник";
            this.btnAddSource.UseVisualStyleBackColor = false;
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // pMenuCalculate
            // 
            this.pMenuCalculate.BackColor = System.Drawing.Color.LightGray;
            this.pMenuCalculate.Controls.Add(this.btnShowPath);
            this.pMenuCalculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMenuCalculate.Location = new System.Drawing.Point(3, 228);
            this.pMenuCalculate.Name = "pMenuCalculate";
            this.pMenuCalculate.Size = new System.Drawing.Size(188, 224);
            this.pMenuCalculate.TabIndex = 2;
            // 
            // btnShowPath
            // 
            this.btnShowPath.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowPath.Location = new System.Drawing.Point(0, 0);
            this.btnShowPath.Name = "btnShowPath";
            this.btnShowPath.Size = new System.Drawing.Size(188, 23);
            this.btnShowPath.TabIndex = 0;
            this.btnShowPath.Text = "Построить путь";
            this.btnShowPath.UseVisualStyleBackColor = false;
            this.btnShowPath.Click += new System.EventHandler(this.btnShowPath_Click);
            // 
            // pFields
            // 
            this.pFields.AutoScroll = true;
            this.pFields.BackColor = System.Drawing.Color.LightGray;
            this.pFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFields.Location = new System.Drawing.Point(203, 3);
            this.pFields.Name = "pFields";
            this.pFields.Size = new System.Drawing.Size(628, 455);
            this.pFields.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.tlpMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Трассировка многослойных ППП";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tlpMain.ResumeLayout(false);
            this.tlpMenu.ResumeLayout(false);
            this.pMenuFields.ResumeLayout(false);
            this.pMenuFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            this.pMenuElements.ResumeLayout(false);
            this.pMenuCalculate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.Panel pMenuFields;
        private System.Windows.Forms.Panel pMenuElements;
        private System.Windows.Forms.Panel pMenuCalculate;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Button btnRemoveField;
        private System.Windows.Forms.Panel pFields;
        private System.Windows.Forms.Button btnAddLockCell;
        private System.Windows.Forms.Button btnAddTarget;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Button btnShowPath;
        private System.Windows.Forms.NumericUpDown nudColumns;
        private System.Windows.Forms.Label lColumns;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.Label lRows;
        private System.Windows.Forms.Button btnClearCell;
    }
}

