using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PCBDelamination;

namespace PCBDelaminationUI
{
    public partial class Form : System.Windows.Forms.Form
    {
        private const int radius = 20;
        private Bitmap map;
        private const string graphName = "G";
        private const string graphNamePattern = "{0}{1}";
        private Color vertexColor = Color.LightGray;
        private Color selectedColor = Color.LightBlue;

        private List<Control> controls = new List<Control>();

        private List<Vertex> vertices;
        private List<Edge> edges;
        List<Vertex> selectedVertices;
        private bool[,] matrix;

        public Form()
        {
            InitializeComponent();

            InitForm();
        }

        private void btnAddVertex_Click(object sender, System.EventArgs e) => AddVertexClickHandling();
        private void btnAddEdge_Click(object sender, System.EventArgs e) => AddEdgeClickHandling();
        private void btnRemoveVertex_Click(object sender, EventArgs e) => RemoveElementClickHandling();
        private void btnClearGraph_Click(object sender, System.EventArgs e) => ClearGraphClickHandling();
        private void btnCalculate_Click(object sender, System.EventArgs e) => CalculateClickHandling();
        private void pbGraph_MouseClick(object sender, MouseEventArgs e) => GraphClickHandling(sender, e);
        private void Form_Resize(object sender, System.EventArgs e) => FormResizeHandling();

        private void InitForm()
        {
            map = new Bitmap(pbGraph.Width, pbGraph.Height);

            vertices = new List<Vertex>();
            edges = new List<Edge>();
            selectedVertices = new List<Vertex>();
            UpdateMatrix();

            DrawGraph(map, pbGraph);
        }

        private void AddVertexClickHandling()
        {
            btnAddVertex.Enabled = false;
            btnAddEdge.Enabled = true;
            btnRemoveVertex.Enabled = true;
            
            RemoveResult();

            selectedVertices.Clear();
            DrawGraph(map, pbGraph);
        }

        private void AddEdgeClickHandling()
        {
            btnAddVertex.Enabled = true;
            btnAddEdge.Enabled = false;
            btnRemoveVertex.Enabled = true;

            RemoveResult();
        }

        private void RemoveElementClickHandling()
        {
            btnAddVertex.Enabled = true;
            btnAddEdge.Enabled = true;
            btnRemoveVertex.Enabled = false;

            RemoveResult();

            selectedVertices.Clear();
            DrawGraph(map, pbGraph);
        }

        private void ClearGraphClickHandling()
        {
            btnAddVertex.Enabled = true;
            btnAddEdge.Enabled = true;
            btnRemoveVertex.Enabled = true;

            selectedVertices.Clear();

            vertices.Clear();
            edges.Clear();
            UpdateMatrix();

            RemoveResult();

            DrawGraph(map, pbGraph);
        }

        private void GraphClickHandling(object sender, MouseEventArgs e)
        {
            RemoveResult();

            if (!btnAddVertex.Enabled)
            {
                vertices.Add(new Vertex(e.X, e.Y));
            }
            else if (!btnAddEdge.Enabled)
            {
                Vertex vertex = FindVertex(e.X, e.Y);
                if (vertex != null)
                {
                    if (selectedVertices.Contains(vertex))
                    {
                        selectedVertices.Remove(vertex);
                    }
                    else
                    {
                        selectedVertices.Add(vertex);
                    }

                    if (selectedVertices.Count == 2)
                    {
                        if (!edges.Any(n => ((n.Vertex1 == selectedVertices[0]) || (n.Vertex1 == selectedVertices[1])) 
                            && ((n.Vertex2 == selectedVertices[0]) || (n.Vertex2 == selectedVertices[1]))))
                        {
                            edges.Add(new Edge(selectedVertices[0], selectedVertices[1]));
                        }

                        selectedVertices.Clear();
                    }
                }
                else
                {
                    selectedVertices.Clear();
                }
            }
            else if (!btnRemoveVertex.Enabled)
            {
                Vertex vertex = FindVertex(e.X, e.Y);
                if (vertex != null)
                {
                    vertices.Remove(vertex);

                    List<Edge> edgesToRemove = edges.Where(n => (n.Vertex1 == vertex) || (n.Vertex2 == vertex)).ToList();
                    foreach (Edge edge in edgesToRemove)
                        edges.Remove(edge);
                }
            }

            UpdateMatrix();
            DrawGraph(map, pbGraph);
        }

        private Vertex FindVertex(int x, int y)
        {
            for (int i = 0; i < vertices.Count; i++)
                if (Math.Pow(vertices[i].X - x, 2) + Math.Pow(vertices[i].Y - y, 2) <= Math.Pow(radius, 2))
                    return vertices[i];

            return null;
        }

        private void UpdateMatrix()
        {
            matrix = new bool[vertices.Count, vertices.Count];
            foreach (Edge edge in edges)
            {
                int vertex1Index = vertices.Select((vertex, index) => new { index, vertex })
                    .Where(n => n.vertex == edge.Vertex1).Select(n => n.index).First();
                int vertex2Index = vertices.Select((vertex, index) => new { index, vertex })
                    .Where(n => n.vertex == edge.Vertex2).Select(n => n.index).First();

                matrix[vertex1Index, vertex2Index] = true;
                matrix[vertex2Index, vertex1Index] = true;
            }
        }

        private void DrawGraph(Bitmap bitmap, PictureBox picture)
        {
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);

            DrawGraphName(graphName, graphics);

            for (int i = 0; i < edges.Count; i++)
                DrawEdge(edges[i], graphics);

            for (int i = 0; i < vertices.Count; i++)
            {
                Color color = selectedVertices.Contains(vertices[i]) ? selectedColor : vertexColor;
                DrawVertex(vertices[i].X, vertices[i].Y, i + 1, graphics, color);
            }

            bitmap = newBitmap;
            picture.Image = bitmap;
        }

        private void DrawVertex(int x, int y, int number, Graphics graphics, Color color)
        {
            graphics.FillEllipse(new SolidBrush(color), x - radius, y - radius, radius * 2, radius * 2);
            graphics.DrawEllipse(new Pen(Color.Black, 1), x - radius, y - radius, radius * 2, radius * 2);
            
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            graphics.DrawString(number.ToString(), new Font("Calibri", 14), new SolidBrush(Color.Black), x, y, format);
        }

        private void DrawEdge(Edge edge, Graphics graphics)
        {
            Point start = new Point(edge.Vertex1.X, edge.Vertex1.Y);
            Point end = new Point(edge.Vertex2.X, edge.Vertex2.Y);
            graphics.DrawLine(new Pen(Color.Black, 2), start, end);
        }

        private void CalculateClickHandling()
        {
            selectedVertices.Clear();
            DrawGraph(map, pbGraph);

            RemoveResult();

            int layersCount = (int)nudLayers.Value;
            DelaminationProcessor processor = new DelaminationProcessor(matrix);
            List<List<int>> layers = processor.GetLayers(layersCount, 
                out List<List<int>> g, out List<List<int>> s, out List<int> extraS);

            AddSeparator();
            AddSLabel(string.Empty, s[0]);
            for (int i = 1; i < s.Count; i++)
            {
                AddSeparator();
                AddGraphPicture(i, g[i]);
                AddSeparator();
                AddSLabel(i.ToString(), s[i]);
            }
            AddSLabel("*", extraS);
            AddSeparator();

            for (int i = 0; i < layersCount; i++)
                AddSLabel((i + 1).ToString(), layers[i]);

            DrawLayersGraph(map, pbGraph, layers);
        }

        private void DrawGraphName(string name, Graphics graphics)
        {
            const int x = 20;
            const int y = 20;

            Font font = new Font("Calibri", 16);
            graphics.DrawString(name, font, new SolidBrush(Color.Black), x, y, new StringFormat());
        }

        private void AddGraphPicture(int number, List<int> g)
        {
            PictureBox picture = new PictureBox();
            picture.Width = pbGraph.Width;
            picture.Height = pbGraph.Height;
            picture.Dock = DockStyle.Top;

            Bitmap bitmap = new Bitmap(picture.Width, picture.Height);

            DrawPartGraph(bitmap, picture, number, g);
            picture.Image = bitmap;

            pGraphs.Controls.Add(picture);
            pGraphs.Controls.SetChildIndex(picture, 0);

            controls.Add(picture);
        }

        private void DrawPartGraph(Bitmap bitmap, PictureBox picture, int number, List<int> g)
        {
            Graphics graphics = Graphics.FromImage(bitmap);

            DrawGraphName(string.Format(graphNamePattern, graphName, number), graphics);

            foreach (Edge edge in edges)
            {
                int vertex1Index = vertices.Select((vertex, index) => new { index, vertex })
                    .Where(n => n.vertex == edge.Vertex1).Select(n => n.index).First();
                int vertex2Index = vertices.Select((vertex, index) => new { index, vertex })
                    .Where(n => n.vertex == edge.Vertex2).Select(n => n.index).First();

                if (g.Contains(vertex1Index) && g.Contains(vertex2Index))
                {
                    DrawEdge(edge, graphics);
                }
            }

            for (int i = 0; i < vertices.Count; i++)
                if (g.Contains(i))
                    DrawVertex(vertices[i].X, vertices[i].Y, i + 1, graphics, vertexColor);

            picture.Image = bitmap;
        }

        private void DrawLayersGraph(Bitmap bitmap, PictureBox picture, List<List<int>> layers)
        {
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);

            DrawGraphName(graphName, graphics);

            for (int i = 0; i < edges.Count; i++)
                DrawEdge(edges[i], graphics);

            Random random = new Random();
            for (int i = 0; i < layers.Count; i++)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                for (int j = 0; j < vertices.Count; j++)
                {
                    if (layers[i].Contains(j))
                    {
                        DrawVertex(vertices[j].X, vertices[j].Y, j + 1, graphics, randomColor);
                    }
                }
            }

            bitmap = newBitmap;
            picture.Image = bitmap;
        }

        private void AddSeparator()
        {
            Panel separator = new Panel();
            separator.BackColor = Color.DarkGray;
            separator.Height = 6;
            separator.Dock = DockStyle.Top;

            pGraphs.Controls.Add(separator);
            pGraphs.Controls.SetChildIndex(separator, 0);

            controls.Add(separator);
        }

        private void AddSLabel(string number, List<int> s)
        {
            const string sPattern = "S{0} = {{{1}}}";
            const string sElementPattern = " {0} ";
            const string separator = ",";

            StringBuilder elements = new StringBuilder();
            if (s.Count > 0)
            {
                elements.Append(string.Format(sElementPattern, s[0] + 1));
                for (int i = 1; i < s.Count; i++)
                {
                    elements.Append(separator);
                    elements.Append(string.Format(sElementPattern, s[i] + 1));
                }
            }

            string text = string.Format(sPattern, number, elements.ToString());

            Label label = new Label();
            label.Text = text;
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Top;
            label.Font = new Font("Calibri", 11);

            pGraphs.Controls.Add(label);
            pGraphs.Controls.SetChildIndex(label, 0);

            controls.Add(label);
        }

        private void RemoveResult()
        {
            foreach (Control control in controls)
            {
                pGraphs.Controls.Remove(control);
                control.Dispose();
            }
        }

        private void FormResizeHandling()
        {
            Bitmap newMap = new Bitmap(pbGraph.Width, pbGraph.Height);
            using Graphics graphics = Graphics.FromImage(newMap);
            graphics.DrawImage(map, 0, 0, pbGraph.Width, pbGraph.Height);

            map = newMap;
        }
    }
}
