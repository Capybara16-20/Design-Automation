
namespace MSTUI
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pGraphMenu = new System.Windows.Forms.Panel();
            this.gbMST = new System.Windows.Forms.GroupBox();
            this.btnStepUp = new System.Windows.Forms.Button();
            this.btnStepBack = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.gbInstruments = new System.Windows.Forms.GroupBox();
            this.btnRemoveGraph = new System.Windows.Forms.Button();
            this.btnRemoveElement = new System.Windows.Forms.Button();
            this.lEdgeWeight = new System.Windows.Forms.Label();
            this.tbEdgeWeight = new System.Windows.Forms.TextBox();
            this.btnAddEdge = new System.Windows.Forms.Button();
            this.btnAddVertex = new System.Windows.Forms.Button();
            this.pMatrices = new System.Windows.Forms.Panel();
            this.gbIncidence = new System.Windows.Forms.GroupBox();
            this.lbIncidence = new System.Windows.Forms.ListBox();
            this.gbAdjacency = new System.Windows.Forms.GroupBox();
            this.lbAdjacency = new System.Windows.Forms.ListBox();
            this.pGraphDrawing = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel.SuspendLayout();
            this.pGraphMenu.SuspendLayout();
            this.gbMST.SuspendLayout();
            this.gbInstruments.SuspendLayout();
            this.pMatrices.SuspendLayout();
            this.gbIncidence.SuspendLayout();
            this.gbAdjacency.SuspendLayout();
            this.pGraphDrawing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.Controls.Add(this.pGraphMenu, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pMatrices, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.pGraphDrawing, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(804, 461);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // pGraphMenu
            // 
            this.pGraphMenu.Controls.Add(this.gbMST);
            this.pGraphMenu.Controls.Add(this.gbInstruments);
            this.pGraphMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGraphMenu.Location = new System.Drawing.Point(3, 3);
            this.pGraphMenu.Name = "pGraphMenu";
            this.pGraphMenu.Size = new System.Drawing.Size(94, 455);
            this.pGraphMenu.TabIndex = 0;
            // 
            // gbMST
            // 
            this.gbMST.Controls.Add(this.btnStepUp);
            this.gbMST.Controls.Add(this.btnStepBack);
            this.gbMST.Controls.Add(this.btnResult);
            this.gbMST.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbMST.Location = new System.Drawing.Point(0, 325);
            this.gbMST.Name = "gbMST";
            this.gbMST.Size = new System.Drawing.Size(94, 130);
            this.gbMST.TabIndex = 1;
            this.gbMST.TabStop = false;
            this.gbMST.Text = "MST";
            // 
            // btnStepUp
            // 
            this.btnStepUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStepUp.Location = new System.Drawing.Point(3, 22);
            this.btnStepUp.Name = "btnStepUp";
            this.btnStepUp.Size = new System.Drawing.Size(87, 30);
            this.btnStepUp.TabIndex = 3;
            this.btnStepUp.Text = "Step Up";
            this.btnStepUp.UseVisualStyleBackColor = true;
            this.btnStepUp.Click += new System.EventHandler(this.btnStepUp_Click);
            // 
            // btnStepBack
            // 
            this.btnStepBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStepBack.Location = new System.Drawing.Point(3, 58);
            this.btnStepBack.Name = "btnStepBack";
            this.btnStepBack.Size = new System.Drawing.Size(87, 30);
            this.btnStepBack.TabIndex = 2;
            this.btnStepBack.Text = "Step Back";
            this.btnStepBack.UseVisualStyleBackColor = true;
            this.btnStepBack.Click += new System.EventHandler(this.btnStepBack_Click);
            // 
            // btnResult
            // 
            this.btnResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResult.Location = new System.Drawing.Point(3, 94);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(87, 30);
            this.btnResult.TabIndex = 1;
            this.btnResult.Text = "Result";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // gbInstruments
            // 
            this.gbInstruments.Controls.Add(this.btnRemoveGraph);
            this.gbInstruments.Controls.Add(this.btnRemoveElement);
            this.gbInstruments.Controls.Add(this.lEdgeWeight);
            this.gbInstruments.Controls.Add(this.tbEdgeWeight);
            this.gbInstruments.Controls.Add(this.btnAddEdge);
            this.gbInstruments.Controls.Add(this.btnAddVertex);
            this.gbInstruments.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInstruments.Location = new System.Drawing.Point(0, 0);
            this.gbInstruments.Name = "gbInstruments";
            this.gbInstruments.Size = new System.Drawing.Size(94, 254);
            this.gbInstruments.TabIndex = 0;
            this.gbInstruments.TabStop = false;
            this.gbInstruments.Text = "Instruments";
            // 
            // btnRemoveGraph
            // 
            this.btnRemoveGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveGraph.Location = new System.Drawing.Point(3, 184);
            this.btnRemoveGraph.Name = "btnRemoveGraph";
            this.btnRemoveGraph.Size = new System.Drawing.Size(87, 40);
            this.btnRemoveGraph.TabIndex = 5;
            this.btnRemoveGraph.Text = "Remove Graph";
            this.btnRemoveGraph.UseVisualStyleBackColor = true;
            this.btnRemoveGraph.Click += new System.EventHandler(this.btnRemoveGraph_Click);
            // 
            // btnRemoveElement
            // 
            this.btnRemoveElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveElement.Location = new System.Drawing.Point(3, 138);
            this.btnRemoveElement.Name = "btnRemoveElement";
            this.btnRemoveElement.Size = new System.Drawing.Size(87, 40);
            this.btnRemoveElement.TabIndex = 4;
            this.btnRemoveElement.Text = "Remove Element";
            this.btnRemoveElement.UseVisualStyleBackColor = true;
            this.btnRemoveElement.Click += new System.EventHandler(this.btnRemoveElement_Click);
            // 
            // lEdgeWeight
            // 
            this.lEdgeWeight.AutoSize = true;
            this.lEdgeWeight.Location = new System.Drawing.Point(9, 91);
            this.lEdgeWeight.Name = "lEdgeWeight";
            this.lEdgeWeight.Size = new System.Drawing.Size(74, 15);
            this.lEdgeWeight.TabIndex = 3;
            this.lEdgeWeight.Text = "Edge Weight";
            // 
            // tbEdgeWeight
            // 
            this.tbEdgeWeight.Location = new System.Drawing.Point(3, 109);
            this.tbEdgeWeight.Name = "tbEdgeWeight";
            this.tbEdgeWeight.Size = new System.Drawing.Size(87, 23);
            this.tbEdgeWeight.TabIndex = 2;
            this.tbEdgeWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEdgeWeight_KeyPress);
            // 
            // btnAddEdge
            // 
            this.btnAddEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEdge.Location = new System.Drawing.Point(3, 58);
            this.btnAddEdge.Name = "btnAddEdge";
            this.btnAddEdge.Size = new System.Drawing.Size(87, 30);
            this.btnAddEdge.TabIndex = 1;
            this.btnAddEdge.Text = "Add Edge";
            this.btnAddEdge.UseVisualStyleBackColor = true;
            this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click);
            // 
            // btnAddVertex
            // 
            this.btnAddVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVertex.Location = new System.Drawing.Point(3, 22);
            this.btnAddVertex.Name = "btnAddVertex";
            this.btnAddVertex.Size = new System.Drawing.Size(87, 30);
            this.btnAddVertex.TabIndex = 0;
            this.btnAddVertex.Text = "Add Vertex";
            this.btnAddVertex.UseVisualStyleBackColor = true;
            this.btnAddVertex.Click += new System.EventHandler(this.btnAddVertex_Click);
            // 
            // pMatrices
            // 
            this.pMatrices.Controls.Add(this.gbIncidence);
            this.pMatrices.Controls.Add(this.gbAdjacency);
            this.pMatrices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMatrices.Location = new System.Drawing.Point(607, 3);
            this.pMatrices.Name = "pMatrices";
            this.pMatrices.Size = new System.Drawing.Size(194, 455);
            this.pMatrices.TabIndex = 1;
            // 
            // gbIncidence
            // 
            this.gbIncidence.Controls.Add(this.lbIncidence);
            this.gbIncidence.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbIncidence.Location = new System.Drawing.Point(0, 194);
            this.gbIncidence.Name = "gbIncidence";
            this.gbIncidence.Size = new System.Drawing.Size(194, 194);
            this.gbIncidence.TabIndex = 1;
            this.gbIncidence.TabStop = false;
            this.gbIncidence.Text = "Incidence Matrix";
            // 
            // lbIncidence
            // 
            this.lbIncidence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIncidence.FormattingEnabled = true;
            this.lbIncidence.ItemHeight = 15;
            this.lbIncidence.Location = new System.Drawing.Point(3, 19);
            this.lbIncidence.Name = "lbIncidence";
            this.lbIncidence.Size = new System.Drawing.Size(188, 172);
            this.lbIncidence.TabIndex = 0;
            // 
            // gbAdjacency
            // 
            this.gbAdjacency.Controls.Add(this.lbAdjacency);
            this.gbAdjacency.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAdjacency.Location = new System.Drawing.Point(0, 0);
            this.gbAdjacency.Name = "gbAdjacency";
            this.gbAdjacency.Size = new System.Drawing.Size(194, 194);
            this.gbAdjacency.TabIndex = 0;
            this.gbAdjacency.TabStop = false;
            this.gbAdjacency.Text = "Adjacency Matrix";
            // 
            // lbAdjacency
            // 
            this.lbAdjacency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAdjacency.FormattingEnabled = true;
            this.lbAdjacency.ItemHeight = 15;
            this.lbAdjacency.Location = new System.Drawing.Point(3, 19);
            this.lbAdjacency.Name = "lbAdjacency";
            this.lbAdjacency.Size = new System.Drawing.Size(188, 172);
            this.lbAdjacency.TabIndex = 0;
            // 
            // pGraphDrawing
            // 
            this.pGraphDrawing.Controls.Add(this.pictureBox);
            this.pGraphDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGraphDrawing.Location = new System.Drawing.Point(103, 3);
            this.pGraphDrawing.Name = "pGraphDrawing";
            this.pGraphDrawing.Size = new System.Drawing.Size(498, 455);
            this.pGraphDrawing.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(498, 455);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 500);
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дерево Штейнера";
            this.tableLayoutPanel.ResumeLayout(false);
            this.pGraphMenu.ResumeLayout(false);
            this.gbMST.ResumeLayout(false);
            this.gbInstruments.ResumeLayout(false);
            this.gbInstruments.PerformLayout();
            this.pMatrices.ResumeLayout(false);
            this.gbIncidence.ResumeLayout(false);
            this.gbAdjacency.ResumeLayout(false);
            this.pGraphDrawing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel pGraphMenu;
        private System.Windows.Forms.Panel pMatrices;
        private System.Windows.Forms.Panel pGraphDrawing;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox gbInstruments;
        private System.Windows.Forms.Button btnRemoveElement;
        private System.Windows.Forms.Label lEdgeWeight;
        private System.Windows.Forms.TextBox tbEdgeWeight;
        private System.Windows.Forms.Button btnAddEdge;
        private System.Windows.Forms.Button btnAddVertex;
        private System.Windows.Forms.GroupBox gbMST;
        private System.Windows.Forms.Button btnStepUp;
        private System.Windows.Forms.Button btnStepBack;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnRemoveGraph;
        private System.Windows.Forms.GroupBox gbAdjacency;
        private System.Windows.Forms.GroupBox gbIncidence;
        private System.Windows.Forms.ListBox lbAdjacency;
        private System.Windows.Forms.ListBox lbIncidence;
    }
}

