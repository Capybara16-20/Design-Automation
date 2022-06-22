using System.Collections.Generic;
using System.Linq;

namespace PCBDelamination
{
    public class DelaminationProcessor
    {
        private readonly bool[,] matrix;
        private readonly int size;

        public DelaminationProcessor(bool[,] matrix)
        {
            this.matrix = matrix;
            size = matrix.GetLength(0);
        }

        public List<List<int>> GetLayers(int k, out List<List<int>> G, out List<List<int>> S, out List<int> extraS)
        {
            G = new List<List<int>>();
            List<int> baseG = Enumerable.Range(0, size).ToList();
            G.Add(baseG);

            bool[,] currentMatrix = GetMatrixCopy(matrix);

            S = new List<List<int>>();
            List<int> baseS = GetbaseS(currentMatrix, k);
            S.Add(baseS);

            List<int> currentG = baseG;
            List<int> currentS = baseS;
            for (int i = 0; i < k; i++)
            {
                currentG = currentG.Except(currentS).ToList();
                G.Add(currentG.Select(n => n).ToList());

                currentS = GetS(GetMatrixCopy(currentMatrix), currentG);
                S.Add(currentS);

                foreach (int vertex in currentS)
                    RemoveVertex(currentMatrix, vertex);
            }

            extraS = new List<int>();
            extraS.AddRange(currentG.Except(currentS));

            List<List<int>> layers = GetLayers(matrix, S, extraS);
            return layers;
        }

        private List<List<int>> GetLayers(bool[,] matrix, List<List<int>> S, List<int> extraS)
        {
            List<List<int>> layers = new List<List<int>>();
            for (int i = 1; i < S.Count; i++)
                layers.Add(S[i].Select(n => n).ToList());

            List<int> baseS = S[0];
            for (int i = baseS.Count - 1; i >= 0; i--)
                AddVertex(layers, baseS[i]);

            for (int i = extraS.Count - 1; i >= 0; i--)
                AddVertex(layers, extraS[i]);

            return layers;
        }

        private void AddVertex(List<List<int>> layers, int vertex)
        {
            int minLayer = -1;
            int minIntersections = int.MaxValue;
            for (int i = 0; i < layers.Count; i++)
            {
                int intersections = 0;

                for (int j = 0; j < layers[i].Count; j++)
                {
                    if (matrix[vertex, layers[i][j]])
                    {
                        intersections++;
                    }
                }

                if (intersections < minIntersections)
                {
                    minIntersections = intersections;
                    minLayer = i;
                }
            }

            layers[minLayer].Add(vertex);
        }

        private List<int> GetS(bool[,] matrix, List<int> g)
        {
            List<int> s = g.Select(n => n).ToList();
            bool isRemoved = true;
            while (isRemoved)
            {
                bool changed = false;

                int maxVertex = -1;
                int maxLocalDegree = int.MinValue;
                for (int i = 0; i < s.Count; i++)
                {
                    int localDegree = 0;
                    for (int j = 0; j < size; j++)
                    {
                        if (matrix[s[i], j])
                        {
                            localDegree++;
                        }
                    }

                    if ((localDegree > 0) && (localDegree > maxLocalDegree))
                    {
                        maxLocalDegree = localDegree;
                        maxVertex = s[i];

                        changed = true;
                    }
                }

                if (changed)
                {
                    s.Remove(maxVertex);
                    RemoveVertex(matrix, maxVertex);
                }
                
                isRemoved = changed;
            }

            return s;
        }

        private List<int> GetbaseS(bool[,] matrix, int k)
        {
            List<int> s = new List<int>();
            bool isRemoved = true;
            while (isRemoved)
            {
                int changes = 0;

                for (int i = 0; i < size; i++)
                {
                    int localDegree = 0;
                    for (int j = 0; j < size; j++)
                    {
                        if (matrix[i, j])
                        {
                            localDegree++;
                        }
                    }

                    if ((localDegree > 0) && (localDegree < k))
                    {
                        RemoveVertex(matrix, i);
                        s.Add(i);

                        changes++;
                    }
                }

                isRemoved = changes > 0; 
            }

            return s;
        }

        private void RemoveVertex(bool[,] matrix, int vertex)
        {
            for (int i = 0; i < size; i++)
            {
                matrix[vertex, i] = false;
                matrix[i, vertex] = false;
            }
        }

        private bool[,] GetMatrixCopy(bool[,] matrix)
        {
            bool[,] copy = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    copy[i, j] = matrix[i, j];
                    copy[j, i] = matrix[j, i];
                }
            }

            return copy;
        }
    }
}
