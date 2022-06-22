using System.Collections.Generic;

namespace MST
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public int[,] GetAdjacencyMatrix()
        {
            int verticesCount = Vertices.Count;
            int[,] matrix = new int[verticesCount, verticesCount];
            for (int i = 0; i < verticesCount; i++)
                for (int j = 0; j < verticesCount; j++)
                    matrix[i, j] = 0;

            int edgesCount = Edges.Count;
            for (int i = 0; i < edgesCount; i++)
            {
                matrix[Edges[i].V1, Edges[i].V2] = Edges[i].Weight;
                matrix[Edges[i].V2, Edges[i].V1] = Edges[i].Weight;
            }

            return matrix;
        }

        public int[,] GetIncidenceMatrix()
        {
            int verticesCount = Vertices.Count;
            int edgesCount = Edges.Count;
            int[,] matrix = new int[verticesCount, edgesCount];
            for (int i = 0; i < verticesCount; i++)
                for (int j = 0; j < edgesCount; j++)
                    matrix[i, j] = 0;

            for (int i = 0; i < edgesCount; i++)
            {
                matrix[Edges[i].V1, i] = Edges[i].Weight;
                matrix[Edges[i].V2, i] = Edges[i].Weight;
            }

            return matrix;
        }
    }
}
