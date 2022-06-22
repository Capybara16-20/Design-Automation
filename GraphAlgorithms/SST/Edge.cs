using System;

namespace MST
{
    public class Edge : IEquatable<Edge>
    {
        public int V1 { get; set; }
        public int V2 { get; set; }
        public int Weight { get; set; }

        public Edge(int v1, int v2, int weight)
        {
            V1 = v1;
            V2 = v2;
            Weight = weight;
        }

        public bool Equals(Edge other)
        {
            return ((V1 == other.V1 && V2 == other.V2) || (V1 == other.V2 && V2 == other.V1));
        }
    }
}
