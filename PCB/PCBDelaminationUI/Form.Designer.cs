
namespace PCBDelaminationUI
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
            this.pMenu = new System.Windows.Forms.Panel();
            this.gbCalculate = new System.Windows.Forms.GroupBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lLayers = new System.Windows.Forms.Label();
            this.nudLayers = new System.Windows.Forms.NumericUpDown();
            this.pSeparator = new System.Windows.Forms.Panel();
            this.gbEditor = new System.Windows.Forms.GroupBox();
            this.btnClearGraph = new System.Windows.Forms.Button();
            this.btnRemoveVertex = new System.Windows.Forms.Button();
            this.btnAddEdge = new System.Windows.Forms.Button();
            this.btnAddVertex = new System.Windows.Forms.Button();
            this.pGraphs = new System.Windows.Forms.Panel();
            this.pbGraph = new System.Windows.Forms.PictureBox();
            this.tlpMain.SuspendLayout();
            this.pMenu.SuspendLayout();
            this.gbCalculate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayers)).BeginInit();
            this.gbEditor.SuspendLayout();
            this.pGraphs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.DarkGray;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pMenu, 0, 0);
            this.tlpMain.Controls.Add(this.pGraphs, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(784, 461);
            this.tlpMain.TabIndex = 0;
            // 
            // pMenu
            // 
            this.pMenu.BackColor = System.Drawing.Color.DarkGray;
            this.pMenu.Controls.Add(this.gbCalculate);
            this.pMenu.Controls.Add(this.pSeparator);
            this.pMenu.Controls.Add(this.gbEditor);
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMenu.Location = new System.Drawing.Point(3, 3);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(194, 455);
            this.pMenu.TabIndex = 0;
            // 
            // gbCalculate
            // 
            this.gbCalculate.BackColor = System.Drawing.SystemColors.Control;
            this.gbCalculate.Controls.Add(this.btnCalculate);
            this.gbCalculate.Controls.Add(this.lLayers);
            this.gbCalculate.Controls.Add(this.nudLayers);
            this.gbCalculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCalculate.Location = new System.Drawing.Point(0, 166);
            this.gbCalculate.Name = "gbCalculate";
            this.gbCalculate.Size = new System.Drawing.Size(194, 289);
            this.gbCalculate.TabIndex = 3;
            this.gbCalculate.TabStop = false;
            this.gbCalculate.Text = "Раскраска";
            // 
            // btnCalculate
            // 
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Location = new System.Drawing.Point(9, 51);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(179, 25);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.TabStop = false;
            this.btnCalculate.Text = "Раскрасить вершины";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lLayers
            // 
            this.lLayers.AutoSize = true;
            this.lLayers.Location = new System.Drawing.Point(9, 24);
            this.lLayers.Name = "lLayers";
            this.lLayers.Size = new System.Drawing.Size(110, 15);
            this.lLayers.TabIndex = 1;
            this.lLayers.Text = "Количество слоёв:";
            // 
            // nudLayers
            // 
            this.nudLayers.Location = new System.Drawing.Point(148, 22);
            this.nudLayers.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudLayers.Name = "nudLayers";
            this.nudLayers.Size = new System.Drawing.Size(40, 23);
            this.nudLayers.TabIndex = 0;
            this.nudLayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // pSeparator
            // 
            this.pSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSeparator.Location = new System.Drawing.Point(0, 160);
            this.pSeparator.Name = "pSeparator";
            this.pSeparator.Size = new System.Drawing.Size(194, 6);
            this.pSeparator.TabIndex = 2;
            // 
            // gbEditor
            // 
            this.gbEditor.BackColor = System.Drawing.SystemColors.Control;
            this.gbEditor.Controls.Add(this.btnClearGraph);
            this.gbEditor.Controls.Add(this.btnRemoveVertex);
            this.gbEditor.Controls.Add(this.btnAddEdge);
            this.gbEditor.Controls.Add(this.btnAddVertex);
            this.gbEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEditor.Location = new System.Drawing.Point(0, 0);
            this.gbEditor.Name = "gbEditor";
            this.gbEditor.Size = new System.Drawing.Size(194, 160);
            this.gbEditor.TabIndex = 0;
            this.gbEditor.TabStop = false;
            this.gbEditor.Text = "Редактор графа конфликтов";
            // 
            // btnClearGraph
            // 
            this.btnClearGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearGraph.Location = new System.Drawing.Point(9, 115);
            this.btnClearGraph.Name = "btnClearGraph";
            this.btnClearGraph.Size = new System.Drawing.Size(179, 25);
            this.btnClearGraph.TabIndex = 3;
            this.btnClearGraph.TabStop = false;
            this.btnClearGraph.Text = "Удалить граф";
            this.btnClearGraph.UseVisualStyleBackColor = true;
            this.btnClearGraph.Click += new System.EventHandler(this.btnClearGraph_Click);
            // 
            // btnRemoveVertex
            // 
            this.btnRemoveVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveVertex.Location = new System.Drawing.Point(9, 84);
            this.btnRemoveVertex.Name = "btnRemoveVertex";
            this.btnRemoveVertex.Size = new System.Drawing.Size(179, 25);
            this.btnRemoveVertex.TabIndex = 2;
            this.btnRemoveVertex.TabStop = false;
            this.btnRemoveVertex.Text = "Удалить вершину";
            this.btnRemoveVertex.UseVisualStyleBackColor = true;
            this.btnRemoveVertex.Click += new System.EventHandler(this.btnRemoveVertex_Click);
            // 
            // btnAddEdge
            // 
            this.btnAddEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEdge.Location = new System.Drawing.Point(9, 53);
            this.btnAddEdge.Name = "btnAddEdge";
            this.btnAddEdge.Size = new System.Drawing.Size(179, 25);
            this.btnAddEdge.TabIndex = 1;
            this.btnAddEdge.TabStop = false;
            this.btnAddEdge.Text = "Добавить соединение";
            this.btnAddEdge.UseVisualStyleBackColor = true;
            this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click);
            // 
            // btnAddVertex
            // 
            this.btnAddVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVertex.Location = new System.Drawing.Point(9, 22);
            this.btnAddVertex.Name = "btnAddVertex";
            this.btnAddVertex.Size = new System.Drawing.Size(179, 25);
            this.btnAddVertex.TabIndex = 0;
            this.btnAddVertex.TabStop = false;
            this.btnAddVertex.Text = "Добавить вершину";
            this.btnAddVertex.UseVisualStyleBackColor = true;
            this.btnAddVertex.Click += new System.EventHandler(this.btnAddVertex_Click);
            // 
            // pGraphs
            // 
            this.pGraphs.AutoScroll = true;
            this.pGraphs.BackColor = System.Drawing.SystemColors.Control;
            this.pGraphs.Controls.Add(this.pbGraph);
            this.pGraphs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGraphs.Location = new System.Drawing.Point(203, 3);
            this.pGraphs.Name = "pGraphs";
            this.pGraphs.Size = new System.Drawing.Size(578, 455);
            this.pGraphs.TabIndex = 1;
            // 
            // pbGraph
            // 
            this.pbGraph.BackColor = System.Drawing.SystemColors.Control;
            this.pbGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbGraph.Location = new System.Drawing.Point(0, 0);
            this.pbGraph.Name = "pbGraph";
            this.pbGraph.Size = new System.Drawing.Size(578, 400);
            this.pbGraph.TabIndex = 0;
            this.pbGraph.TabStop = false;
            this.pbGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbGraph_MouseClick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tlpMain);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Раскраска вершин графа конфликтов";
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.tlpMain.ResumeLayout(false);
            this.pMenu.ResumeLayout(false);
            this.gbCalculate.ResumeLayout(false);
            this.gbCalculate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayers)).EndInit();
            this.gbEditor.ResumeLayout(false);
            this.pGraphs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.GroupBox gbEditor;
        private System.Windows.Forms.Panel pGraphs;
        private System.Windows.Forms.Button btnAddVertex;
        private System.Windows.Forms.Button btnClearGraph;
        private System.Windows.Forms.Button btnRemoveVertex;
        private System.Windows.Forms.Button btnAddEdge;
        private System.Windows.Forms.GroupBox gbCalculate;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lLayers;
        private System.Windows.Forms.NumericUpDown nudLayers;
        private System.Windows.Forms.Panel pSeparator;
        private System.Windows.Forms.PictureBox pbGraph;
    }
}

