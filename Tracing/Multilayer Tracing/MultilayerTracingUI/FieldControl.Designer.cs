
namespace MultilayerTracingUI
{
    partial class FieldControl
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
            this.pField = new System.Windows.Forms.Panel();
            this.pPicture = new System.Windows.Forms.Panel();
            this.pbField = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lFieldName = new System.Windows.Forms.Label();
            this.pField.SuspendLayout();
            this.pPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pField
            // 
            this.pField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pField.BackColor = System.Drawing.Color.Transparent;
            this.pField.Controls.Add(this.pPicture);
            this.pField.Controls.Add(this.panel1);
            this.pField.Location = new System.Drawing.Point(10, 10);
            this.pField.Margin = new System.Windows.Forms.Padding(0);
            this.pField.Name = "pField";
            this.pField.Size = new System.Drawing.Size(269, 227);
            this.pField.TabIndex = 0;
            // 
            // pPicture
            // 
            this.pPicture.AutoSize = true;
            this.pPicture.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pPicture.BackColor = System.Drawing.Color.Coral;
            this.pPicture.Controls.Add(this.pbField);
            this.pPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPicture.Location = new System.Drawing.Point(0, 25);
            this.pPicture.Margin = new System.Windows.Forms.Padding(0);
            this.pPicture.Name = "pPicture";
            this.pPicture.Size = new System.Drawing.Size(269, 202);
            this.pPicture.TabIndex = 1;
            // 
            // pbField
            // 
            this.pbField.BackColor = System.Drawing.Color.DarkGray;
            this.pbField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbField.Location = new System.Drawing.Point(0, 0);
            this.pbField.Name = "pbField";
            this.pbField.Size = new System.Drawing.Size(269, 202);
            this.pbField.TabIndex = 0;
            this.pbField.TabStop = false;
            this.pbField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbField_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.lFieldName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 25);
            this.panel1.TabIndex = 0;
            // 
            // lFieldName
            // 
            this.lFieldName.BackColor = System.Drawing.Color.Gray;
            this.lFieldName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFieldName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lFieldName.Location = new System.Drawing.Point(0, 0);
            this.lFieldName.Name = "lFieldName";
            this.lFieldName.Size = new System.Drawing.Size(269, 25);
            this.lFieldName.TabIndex = 0;
            this.lFieldName.Text = "Field";
            this.lFieldName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FieldControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pField);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FieldControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(289, 247);
            this.pField.ResumeLayout(false);
            this.pField.PerformLayout();
            this.pPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pField;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lFieldName;
        private System.Windows.Forms.Panel pPicture;
        private System.Windows.Forms.PictureBox pbField;
    }
}
