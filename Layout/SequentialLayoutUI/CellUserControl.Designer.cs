
namespace SequentialLayoutUI
{
    partial class CellUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pCell = new System.Windows.Forms.Panel();
            this.pbNumber = new System.Windows.Forms.PictureBox();
            this.lbCalculation = new System.Windows.Forms.ListBox();
            this.pbCell = new System.Windows.Forms.PictureBox();
            this.pCell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCell)).BeginInit();
            this.SuspendLayout();
            // 
            // pCell
            // 
            this.pCell.BackColor = System.Drawing.Color.LightGray;
            this.pCell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCell.Controls.Add(this.pbNumber);
            this.pCell.Controls.Add(this.lbCalculation);
            this.pCell.Controls.Add(this.pbCell);
            this.pCell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCell.Location = new System.Drawing.Point(0, 0);
            this.pCell.Margin = new System.Windows.Forms.Padding(0);
            this.pCell.Name = "pCell";
            this.pCell.Size = new System.Drawing.Size(150, 150);
            this.pCell.TabIndex = 0;
            // 
            // pbNumber
            // 
            this.pbNumber.BackColor = System.Drawing.Color.Transparent;
            this.pbNumber.Location = new System.Drawing.Point(0, 99);
            this.pbNumber.Margin = new System.Windows.Forms.Padding(0);
            this.pbNumber.Name = "pbNumber";
            this.pbNumber.Size = new System.Drawing.Size(101, 24);
            this.pbNumber.TabIndex = 2;
            this.pbNumber.TabStop = false;
            // 
            // lbCalculation
            // 
            this.lbCalculation.FormattingEnabled = true;
            this.lbCalculation.ItemHeight = 15;
            this.lbCalculation.Location = new System.Drawing.Point(0, 50);
            this.lbCalculation.Margin = new System.Windows.Forms.Padding(0);
            this.lbCalculation.Name = "lbCalculation";
            this.lbCalculation.Size = new System.Drawing.Size(100, 49);
            this.lbCalculation.TabIndex = 1;
            // 
            // pbCell
            // 
            this.pbCell.BackColor = System.Drawing.Color.Transparent;
            this.pbCell.Location = new System.Drawing.Point(0, 0);
            this.pbCell.Margin = new System.Windows.Forms.Padding(0);
            this.pbCell.Name = "pbCell";
            this.pbCell.Size = new System.Drawing.Size(100, 50);
            this.pbCell.TabIndex = 0;
            this.pbCell.TabStop = false;
            // 
            // CellUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pCell);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CellUserControl";
            this.pCell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCell)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pCell;
        private System.Windows.Forms.PictureBox pbCell;
        private System.Windows.Forms.ListBox lbCalculation;
        private System.Windows.Forms.PictureBox pbNumber;
    }
}
