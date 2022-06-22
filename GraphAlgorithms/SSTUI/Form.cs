using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MST;

namespace MSTUI
{
    public partial class Form : System.Windows.Forms.Form
    {
        private HeuristicAlgorithm algorithm;
        private Graph graph;
        private DrawGraph drawGraph;
        private List<Vertex> vertices;
        private List<Edge> edges;
        private int[,] adjacency;
        private int[,] incidence;
        private List<Edge> cycle;

        private int selected1;
        private int selected2;

        public Form()
        {
            InitializeComponent();
            InitComponents();
        }

        private void btnAddVertex_Click(object sender, EventArgs e) => AddVertex();
        private void btnAddEdge_Click(object sender, EventArgs e) => AddEdge();
        private void btnRemoveElement_Click(object sender, EventArgs e) => RemoveElement();
        private void btnRemoveGraph_Click(object sender, EventArgs e) => RemoveGraph();
        private void tbEdgeWeight_KeyPress(object sender, KeyPressEventArgs e) => EdgeWeightKeyPressHandling(sender, e);
        private void btnStepUp_Click(object sender, EventArgs e) => StepUp();
        private void btnStepBack_Click(object sender, EventArgs e) => StepBack();
        private void btnResult_Click(object sender, EventArgs e) => ShowResult();
        private void pictureBox_MouseClick(object sender, MouseEventArgs e) => PictureBoxClickHandling(sender, e);

        private void AddVertex()
        {
            btnAddVertex.Enabled = false;
            btnAddEdge.Enabled = true;
            btnRemoveElement.Enabled = true;
            DrawGraph();
            selected1 = -1;
            selected2 = -1;
        }

        private void AddEdge()
        {
            btnAddEdge.Enabled = false;
            btnAddVertex.Enabled = true;
            btnRemoveElement.Enabled = true;
            DrawGraph();
            selected1 = -1;
            selected2 = -1;
        }

        private void RemoveElement()
        {
            btnRemoveElement.Enabled = false;
            btnAddVertex.Enabled = true;
            btnAddEdge.Enabled = true;
            DrawGraph();
            selected1 = -1;
            selected2 = -1;
        }

        private void RemoveGraph()
        {
            btnAddVertex.Enabled = true;
            btnAddEdge.Enabled = true;
            btnRemoveElement.Enabled = true;
            const string message = "Are you sure you want to delete the graph?";
            const string caption = "Deleting";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                vertices.Clear();
                edges.Clear();
                DrawGraph();
            }
        }

        private void StepUp()
        {
            drawGraph.clearSheet();
            drawGraph.drawALLGraph(vertices, edges);
            pictureBox.Image = drawGraph.GetBitmap();

            cycle = algorithm.StepUp();

            DrawMST();
        }

        private void StepBack()
        {
            drawGraph.clearSheet();
            drawGraph.drawALLGraph(vertices, edges);
            pictureBox.Image = drawGraph.GetBitmap();

            cycle = algorithm.StepBack();

            DrawMST();
        }

        private void ShowResult()
        {
            drawGraph.clearSheet();
            drawGraph.drawALLGraph(vertices, edges);
            pictureBox.Image = drawGraph.GetBitmap();

            cycle = algorithm.GetResult();

            DrawMST();
        }

        private void EdgeWeightKeyPressHandling(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void PictureBoxClickHandling(object sender, MouseEventArgs e)
        {
            if (btnAddVertex.Enabled == false)
            {
                vertices.Add(new Vertex(e.X, e.Y));
                drawGraph.drawVertex(e.X, e.Y, vertices.Count.ToString());

                drawGraph.clearSheet();
                drawGraph.drawALLGraph(vertices, edges);
                pictureBox.Image = drawGraph.GetBitmap();
            }

            if (btnAddEdge.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < vertices.Count; i++)
                    {
                        if (Math.Pow((vertices[i].X - e.X), 2) + Math.Pow((vertices[i].Y - e.Y), 2) <= drawGraph.R * drawGraph.R)
                        {
                            if (selected1 == -1)
                            {
                                DrawGraph();
                                drawGraph.drawSelectedVertex(vertices[i].X, vertices[i].Y);
                                selected1 = i;
                                pictureBox.Image = drawGraph.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                drawGraph.drawSelectedVertex(vertices[i].X, vertices[i].Y);
                                selected2 = i;
                                if (selected1 != selected2)
                                {
                                    if (tbEdgeWeight.Text != "")
                                    {
                                        int weight = int.Parse(tbEdgeWeight.Text);
                                        Edge edge = new Edge(selected1, selected2, weight);
                                        edges.Add(edge);
                                        drawGraph.drawEdge(vertices[selected1], vertices[selected2], edges[edges.Count - 1], edges.Count - 1);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Enter edge weight");
                                    }

                                    selected1 = -1;
                                    selected2 = -1;
                                    pictureBox.Image = drawGraph.GetBitmap();
                                    break;
                                }
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((vertices[selected1].X - e.X), 2) + Math.Pow((vertices[selected1].Y - e.Y), 2) <= drawGraph.R * drawGraph.R))
                    {
                        drawGraph.drawVertex(vertices[selected1].X, vertices[selected1].Y, (selected1 + 1).ToString());
                        selected1 = -1;
                        pictureBox.Image = drawGraph.GetBitmap();
                    }
                }
            }

            if (btnRemoveElement.Enabled == false)
            {
                bool flag = false;
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (Math.Pow((vertices[i].X - e.X), 2) + Math.Pow((vertices[i].Y - e.Y), 2) <= drawGraph.R * drawGraph.R)
                    {
                        for (int j = 0; j < edges.Count; j++)
                        {
                            if ((edges[j].V1 == i) || (edges[j].V2 == i))
                            {
                                edges.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (edges[j].V1 > i) edges[j].V1--;
                                if (edges[j].V2 > i) edges[j].V2--;
                            }
                        }
                        vertices.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    for (int i = 0; i < edges.Count; i++)
                    {
                        if (edges[i].V1 == edges[i].V2)
                        {
                            if ((Math.Pow((vertices[edges[i].V1].X - drawGraph.R - e.X), 2) + Math.Pow((vertices[edges[i].V1].Y - drawGraph.R - e.Y), 2)
                                    <= ((drawGraph.R + 2) * (drawGraph.R + 2))) &&
                                (Math.Pow((vertices[edges[i].V1].X - drawGraph.R - e.X), 2) + Math.Pow((vertices[edges[i].V1].Y - drawGraph.R - e.Y), 2)
                                    >= ((drawGraph.R - 2) * (drawGraph.R - 2))))
                            {
                                edges.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else
                        {
                            if (((e.X - vertices[edges[i].V1].X) * (vertices[edges[i].V2].Y - vertices[edges[i].V1].Y)
                                    / (vertices[edges[i].V2].X - vertices[edges[i].V1].X) + vertices[edges[i].V1].Y) <= (e.Y + 4)
                                && ((e.X - vertices[edges[i].V1].X) * (vertices[edges[i].V2].Y - vertices[edges[i].V1].Y)
                                    / (vertices[edges[i].V2].X - vertices[edges[i].V1].X) + vertices[edges[i].V1].Y) >= (e.Y - 4))
                            {
                                if ((vertices[edges[i].V1].X <= vertices[edges[i].V2].X && vertices[edges[i].V1].X <= e.X
                                        && e.X <= vertices[edges[i].V2].X) ||
                                    (vertices[edges[i].V1].X >= vertices[edges[i].V2].X && vertices[edges[i].V1].X >= e.X
                                        && e.X >= vertices[edges[i].V2].X))
                                {
                                    edges.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (flag)
                {
                    DrawGraph();
                }
            }

            UpdateGraph(vertices, edges);
            UpdateMatrices();
        }

        private void InitComponents()
        {
            vertices = new List<Vertex>();
            drawGraph = new DrawGraph(pictureBox.Width, pictureBox.Height);
            edges = new List<Edge>();
            pictureBox.Image = drawGraph.GetBitmap();
            tbEdgeWeight.Text = "1";
            cycle = new List<Edge>();
        }
        
        private void DrawGraph()
        {
            drawGraph.clearSheet();
            drawGraph.drawALLGraph(vertices, edges);
            pictureBox.Image = drawGraph.GetBitmap();
        }

        private void UpdateGraph(List<Vertex> vertices, List<Edge> edges)
        {
            graph = new Graph(vertices, edges);
            algorithm = new HeuristicAlgorithm(graph);
        }

        private void UpdateMatrices()
        {
            UpdateAdjacency();
            UpdateIncidence();
        }

        private void UpdateAdjacency()
        {
            const string elementFormat = "{0, 3}";

            adjacency = graph.GetAdjacencyMatrix();
            lbAdjacency.Items.Clear();

            StringBuilder matrix = new StringBuilder();
            matrix.Append("   ");
            for (int i = 0; i < vertices.Count; i++)
                matrix.AppendFormat(elementFormat, i + 1);
            lbAdjacency.Items.Add(matrix.ToString());

            for (int i = 0; i < vertices.Count; i++)
            {
                matrix.Clear();
                matrix.Append(i + 1);
                matrix.Append("|");
                for (int j = 0; j < vertices.Count; j++)
                    matrix.AppendFormat(elementFormat, adjacency[i, j]);

                lbAdjacency.Items.Add(matrix.ToString());
            }
        }

        private void UpdateIncidence()
        {
            const string elementFormat = "{0, 3}";

            if (edges.Count > 0)
            {
                incidence = graph.GetIncidenceMatrix();
                lbIncidence.Items.Clear();

                StringBuilder matrix = new StringBuilder();
                matrix.Append("   ");
                for (int i = 0; i < edges.Count; i++)
                    matrix.AppendFormat(elementFormat, (char)('a' + i));
                lbIncidence.Items.Add(matrix.ToString());

                for (int i = 0; i < vertices.Count; i++)
                {
                    matrix.Clear();
                    matrix.Append(i + 1);
                    matrix.Append("|");
                    for (int j = 0; j < edges.Count; j++)
                        matrix.AppendFormat(elementFormat, incidence[i, j]);

                    lbIncidence.Items.Add(matrix.ToString());
                }
            }
            else
            {
                lbIncidence.Items.Clear();
            }
        }

        private void DrawMST()
        {
            if (cycle == null)
            {
                MessageBox.Show("Algorithm completed");
                algorithm = new HeuristicAlgorithm(graph);
            }
            else
            {
                foreach (Edge edge in cycle)
                {
                    if (FindEdge(edge, out Vertex vertex1, out Vertex vertex2))
                    {
                        drawGraph.drawMSTEdge(vertex1, vertex2, edge);
                        pictureBox.Image = drawGraph.GetBitmap();
                    }
                }
            }
        }

        private bool FindEdge(Edge edge, out Vertex vertex1, out Vertex vertex2)
        {
            vertex1 = null;
            vertex2 = null;
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < vertices.Count; j++)
                {
                    if (edge.V1 == i && edge.V2 == j)
                    {
                        vertex1 = vertices[i];
                        vertex2 = vertices[j];
                        return true;
                    }
                    else if (edge.V1 == j && edge.V2 == i)
                    {
                        vertex1 = vertices[j];
                        vertex2 = vertices[i];
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
