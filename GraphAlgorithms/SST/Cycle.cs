using System.Collections.Generic;

namespace MST
{
    public class Cycle
    {
        public Edge Edge { get; set; }
        public List<Edge> Edges { get; set; }

        public Cycle(Edge edge, List<Edge> edges)
        {
            Edge = edge;
            Edges = edges;
        }
    }
}
