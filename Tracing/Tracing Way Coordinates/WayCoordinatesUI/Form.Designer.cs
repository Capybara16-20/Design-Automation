
namespace WayCoordinatesUI
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.btnLoadField = new System.Windows.Forms.Button();
            this.btnShowPath = new System.Windows.Forms.Button();
            this.btnClearCell = new System.Windows.Forms.Button();
            this.btnAddLock = new System.Windows.Forms.Button();
            this.btnAddDestination = new System.Windows.Forms.Button();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lRows = new System.Windows.Forms.Label();
            this.nudColumns = new System.Windows.Forms.NumericUpDown();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.pField = new System.Windows.Forms.Panel();
            this.pbField = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tlpMain.SuspendLayout();
            this.gbMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            this.pField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.gbMenu, 0, 0);
            this.tlpMain.Controls.Add(this.pField, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(800, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.btnLoadField);
            this.gbMenu.Controls.Add(this.btnShowPath);
            this.gbMenu.Controls.Add(this.btnClearCell);
            this.gbMenu.Controls.Add(this.btnAddLock);
            this.gbMenu.Controls.Add(this.btnAddDestination);
            this.gbMenu.Controls.Add(this.btnAddSource);
            this.gbMenu.Controls.Add(this.label1);
            this.gbMenu.Controls.Add(this.lRows);
            this.gbMenu.Controls.Add(this.nudColumns);
            this.gbMenu.Controls.Add(this.nudRows);
            this.gbMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMenu.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbMenu.Location = new System.Drawing.Point(3, 3);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(199, 444);
            this.gbMenu.TabIndex = 0;
            this.gbMenu.TabStop = false;
            // 
            // btnLoadField
            // 
            this.btnLoadField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadField.Location = new System.Drawing.Point(9, 22);
            this.btnLoadField.Name = "btnLoadField";
            this.btnLoadField.Size = new System.Drawing.Size(179, 25);
            this.btnLoadField.TabIndex = 9;
            this.btnLoadField.TabStop = false;
            this.btnLoadField.Text = "Загрузить ДРП";
            this.btnLoadField.UseVisualStyleBackColor = true;
            this.btnLoadField.Click += new System.EventHandler(this.btnLoadField_Click);
            // 
            // btnShowPath
            // 
            this.btnShowPath.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnShowPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPath.Location = new System.Drawing.Point(9, 260);
            this.btnShowPath.Name = "btnShowPath";
            this.btnShowPath.Size = new System.Drawing.Size(179, 25);
            this.btnShowPath.TabIndex = 8;
            this.btnShowPath.TabStop = false;
            this.btnShowPath.Text = "Рассчитать путь";
            this.btnShowPath.UseVisualStyleBackColor = false;
            this.btnShowPath.Click += new System.EventHandler(this.btnShowPath_Click);
            // 
            // btnClearCell
            // 
            this.btnClearCell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCell.Location = new System.Drawing.Point(9, 202);
            this.btnClearCell.Name = "btnClearCell";
            this.btnClearCell.Size = new System.Drawing.Size(179, 25);
            this.btnClearCell.TabIndex = 7;
            this.btnClearCell.TabStop = false;
            this.btnClearCell.Text = "Очистить ячейку";
            this.btnClearCell.UseVisualStyleBackColor = true;
            this.btnClearCell.Click += new System.EventHandler(this.btnClearCell_Click_1);
            // 
            // btnAddLock
            // 
            this.btnAddLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLock.Location = new System.Drawing.Point(9, 173);
            this.btnAddLock.Name = "btnAddLock";
            this.btnAddLock.Size = new System.Drawing.Size(179, 23);
            this.btnAddLock.TabIndex = 6;
            this.btnAddLock.TabStop = false;
            this.btnAddLock.Text = "Добавить препятствие";
            this.btnAddLock.UseVisualStyleBackColor = true;
            this.btnAddLock.Click += new System.EventHandler(this.btnAddLock_Click);
            // 
            // btnAddDestination
            // 
            this.btnAddDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDestination.Location = new System.Drawing.Point(9, 142);
            this.btnAddDestination.Name = "btnAddDestination";
            this.btnAddDestination.Size = new System.Drawing.Size(179, 25);
            this.btnAddDestination.TabIndex = 5;
            this.btnAddDestination.TabStop = false;
            this.btnAddDestination.Text = "Добавить цель";
            this.btnAddDestination.UseVisualStyleBackColor = true;
            this.btnAddDestination.Click += new System.EventHandler(this.btnAddDestination_Click);
            // 
            // btnAddSource
            // 
            this.btnAddSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSource.Location = new System.Drawing.Point(9, 111);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(179, 25);
            this.btnAddSource.TabIndex = 4;
            this.btnAddSource.TabStop = false;
            this.btnAddSource.Text = "Добавить источник";
            this.btnAddSource.UseVisualStyleBackColor = true;
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество столбцов";
            // 
            // lRows
            // 
            this.lRows.AutoSize = true;
            this.lRows.Location = new System.Drawing.Point(9, 55);
            this.lRows.Name = "lRows";
            this.lRows.Size = new System.Drawing.Size(114, 15);
            this.lRows.TabIndex = 2;
            this.lRows.Text = "Количество строк";
            // 
            // nudColumns
            // 
            this.nudColumns.Location = new System.Drawing.Point(148, 82);
            this.nudColumns.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Size = new System.Drawing.Size(40, 23);
            this.nudColumns.TabIndex = 1;
            this.nudColumns.TabStop = false;
            this.nudColumns.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudColumns.ValueChanged += new System.EventHandler(this.nudColumns_ValueChanged);
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(148, 53);
            this.nudRows.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(40, 23);
            this.nudRows.TabIndex = 0;
            this.nudRows.TabStop = false;
            this.nudRows.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRows.ValueChanged += new System.EventHandler(this.nudRows_ValueChanged);
            // 
            // pField
            // 
            this.pField.AutoScroll = true;
            this.pField.AutoSize = true;
            this.pField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pField.Controls.Add(this.pbField);
            this.pField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pField.Location = new System.Drawing.Point(208, 3);
            this.pField.Name = "pField";
            this.pField.Size = new System.Drawing.Size(589, 444);
            this.pField.TabIndex = 1;
            // 
            // pbField
            // 
            this.pbField.Location = new System.Drawing.Point(3, 3);
            this.pbField.Name = "pbField";
            this.pbField.Size = new System.Drawing.Size(200, 200);
            this.pbField.TabIndex = 0;
            this.pbField.TabStop = false;
            this.pbField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbField_MouseClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "Form";
            this.Text = "Трассировка с путевыми координатами";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            this.pField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lRows;
        private System.Windows.Forms.NumericUpDown nudColumns;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.Button btnClearCell;
        private System.Windows.Forms.Button btnAddLock;
        private System.Windows.Forms.Button btnAddDestination;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Button btnShowPath;
        private System.Windows.Forms.Panel pField;
        private System.Windows.Forms.PictureBox pbField;
        private System.Windows.Forms.Button btnLoadField;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

