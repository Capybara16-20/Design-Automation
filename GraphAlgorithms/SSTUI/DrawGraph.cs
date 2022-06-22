using System.Collections.Generic;
using System.Drawing;
using MST;

namespace MSTUI
{
    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen greenPen;
        Pen bluePen;
        Pen redPen;
        Graphics graph;
        Font font;
        Brush brush;
        PointF point;
        public int R = 20;

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            graph = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            greenPen = new Pen(Color.Green);
            greenPen.Width = 2;
            bluePen = new Pen(Color.DarkBlue);
            bluePen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            font = new Font("Arial", 15);
            brush = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            graph.Clear(Color.White);
        }

        public void drawVertex(int x, int y, string number)
        {
            graph.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            graph.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9 - number.Length * 5, y - 11);
            graph.DrawString("x" + number, font, brush, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            graph.DrawEllipse(greenPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Vertex vertex1, Vertex vertex2, Edge edge, int number)
        {
            if (edge.V1 != edge.V2)
            {
                int shift = edge.Weight.ToString().Length * 15;
                graph.DrawLine(bluePen, vertex1.X, vertex1.Y, vertex2.X, vertex2.Y);
                point = new PointF((vertex1.X + vertex2.X) / 2 - shift, (vertex1.Y + vertex2.Y) / 2);
                graph.DrawString(((char)('a' + number) + " (" + edge.Weight + ")").ToString(), font, brush, point);
                drawVertex(vertex1.X, vertex1.Y, (edge.V1 + 1).ToString());
                drawVertex(vertex2.X, vertex2.Y, (edge.V2 + 1).ToString());
            }
        }

        public void drawMSTEdge(Vertex vertex1, Vertex vertex2, Edge edge)
        {
            if (edge.V1 != edge.V2)
            {
                graph.DrawLine(redPen, vertex1.X, vertex1.Y, vertex2.X, vertex2.Y);
                drawVertex(vertex1.X, vertex1.Y, (edge.V1 + 1).ToString());
                drawVertex(vertex2.X, vertex2.Y, (edge.V2 + 1).ToString());
            }
        }

        public void drawALLGraph(List<Vertex> vertices, List<Edge> edges)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].V1 != edges[i].V2)
                {
                    int shift = edges[i].Weight.ToString().Length * 15;
                    graph.DrawLine(bluePen, vertices[edges[i].V1].X, vertices[edges[i].V1].Y, vertices[edges[i].V2].X, vertices[edges[i].V2].Y);
                    point = new PointF((vertices[edges[i].V1].X + vertices[edges[i].V2].X) / 2 - shift, (vertices[edges[i].V1].Y + vertices[edges[i].V2].Y) / 2);
                    graph.DrawString(((char)('a' + i) + " (" + edges[i].Weight + ")").ToString(), font, brush, point);
                }
            }

            for (int i = 0; i < vertices.Count; i++)
            {
                drawVertex(vertices[i].X, vertices[i].Y, (i + 1).ToString());
            }
        }
    }
}
