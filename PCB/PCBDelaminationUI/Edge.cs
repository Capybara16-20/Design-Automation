namespace PCBDelaminationUI
{
    public class Edge
    {
        public Vertex Vertex1 { get; private set; }
        public Vertex Vertex2 { get; private set; }

        public Edge(Vertex vertex1, Vertex vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }
    }
}
