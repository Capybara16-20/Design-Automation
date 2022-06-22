using System.Collections.Generic;
using System.Linq;

namespace MST
{
    public class HeuristicAlgorithm
    {
        private Graph graph;
        private List<Edge> edges;
        private HashSet<int> vertices;
        private int step;

        public HeuristicAlgorithm(Graph graph)
        {
            this.graph = graph;
            edges = new List<Edge>();
            vertices = new HashSet<int>();
            step = 1;
        }

        private void StepOne()
        {
            List<Edge> graphEdges = graph.Edges;
            Edge minEdge = graphEdges[0];
            foreach (Edge edge in graphEdges)
                if (edge.Weight < minEdge.Weight)
                    minEdge = edge;

            edges.Add(minEdge);
        }

        private void StepTwo(List<Cycle> cycles)
        {
            Cycle minCycle = cycles[0];
            int minIncrement = GetCycleIncrement(cycles[0]);
            foreach (Cycle cycle in cycles)
            {
                int increment = GetCycleIncrement(cycle);
                if (increment < minIncrement)
                {
                    minIncrement = increment;
                    minCycle = cycle;
                }
            }

            edges.AddRange(minCycle.Edges);
        }

        private void StepThree(List<Cycle> cycles)
        {
            Cycle minCycle = cycles[0];
            int minIncrement = GetCycleIncrement(cycles[0]) - cycles[0].Edge.Weight;
            foreach (Cycle cycle in cycles)
            {
                int increment = GetCycleIncrement(cycle) - cycle.Edge.Weight;
                if (increment < minIncrement)
                {
                    minIncrement = increment;
                    minCycle = cycle;
                }
            }

            edges.AddRange(minCycle.Edges);
            edges.Remove(minCycle.Edge);
        }

        public void StepFour()
        {
            Edge maxEdge = edges[0];
            for (int i = 0; i < edges.Count; i++)
                if (edges[i].Weight > maxEdge.Weight)
                    maxEdge = edges[i];

            edges.RemoveAll(n => (n.V1 == maxEdge.V1 && n.V2 == maxEdge.V2) || (n.V1 == maxEdge.V2 && n.V2 == maxEdge.V1));
        }

        public List<Edge> StepUp()
        {
            if (graph.Vertices.Count < 3)
                return null;

            if (step == 1)
            {
                StepOne();
            }
            else if (edges.Count < graph.Vertices.Count)
            {
                List<Cycle> cycles = FindCycles();

                if (cycles.Count > 0)
                {
                    if (edges.Count == 1)
                    {
                        StepTwo(cycles);
                    }
                    else
                    {
                        StepThree(cycles);
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                StepFour();
            }

            UpdateVertices();
            step++;
            return edges;
        }

        public List<Edge> StepBack()
        {
            if (step == 1)
                return new List<Edge>();

            int requiredStep = step - 1;
            edges = new List<Edge>();
            step = 1;

            edges = new List<Edge>();
            while (step != requiredStep)
                edges = StepUp();

            return edges;
        }

        public List<Edge> GetResult()
        {
            edges = new List<Edge>();
            step = 1;
            while (edges.Count != graph.Vertices.Count)
                edges = StepUp();

            edges = StepUp();

            return edges;
        }

        private List<Cycle> FindCycles()
        {
            List<Cycle> cycles = new List<Cycle>();
            List<int> notIncludedVertices = GetNotIncludedVertices();
            for (int i = 0; i < edges.Count; i++)
            {
                for (int j = 0; j < notIncludedVertices.Count; j++)
                {
                    List<Edge> cycle = FindCycle(edges[i], notIncludedVertices[j]);
                    if (cycle != null)
                        cycles.Add(new Cycle(edges[i], cycle));
                }
            }

            return cycles;
        }

        public List<Edge> FindCycle(Edge edge, int vertex)
        {
            List<Edge> edges = graph.Edges.Where(n => (n.V1 == edge.V1 && n.V2 == vertex)
                                                        || (n.V2 == edge.V1 && n.V1 == vertex)
                                                        || (n.V1 == edge.V2 && n.V2 == vertex)
                                                        || (n.V2 == edge.V2 && n.V1 == vertex)).ToList();

            return (edges.Count == 2) ? edges : null;
        }

        private void UpdateVertices()
        {
            vertices = new HashSet<int>();
            foreach (Edge edge in edges)
            {
                vertices.Add(edge.V1);
                vertices.Add(edge.V2);
            }
        }

        private List<int> GetNotIncludedVertices()
        {
            HashSet<int> graphVertices = new HashSet<int>();
            foreach (Edge edge in graph.Edges)
            {
                graphVertices.Add(edge.V1);
                graphVertices.Add(edge.V2);
            }

            return graphVertices.Except(vertices).ToList();
        }

        private static int GetCycleIncrement(Cycle cycle)
        {
            int increment = 0;
            foreach (Edge edge in cycle.Edges)
                increment += edge.Weight;

            return increment;
        }
    }
}
