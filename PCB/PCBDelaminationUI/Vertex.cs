namespace PCBDelaminationUI
{
    public class Vertex
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Vertex a, Vertex b)
        {
            if ((object)a == null)
                return (object)b == null;
            else if ((object)b == null)
                return (object)a == null;

            return (a.X == b.X) && (a.Y == b.Y);
        }

        public static bool operator !=(Vertex a, Vertex b)
        {
            return !(a == b);
        }
    }
}
