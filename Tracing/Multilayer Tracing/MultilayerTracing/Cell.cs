namespace MultilayerTracing
{
    public class Cell
    {
        public int Y { get; private set; }
        public int X { get; private set; }
        public int P { get; set; }
        public int V { get; set; }

        public Cell(int y, int x, int p = 0, int v = 0)
        {
            Y = y;
            X = x;
            P = p;
            V = v;
        }
    }
}
