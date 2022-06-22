namespace WayCoordinates
{
    public class Cell
    {
        public const int UpIndex = 0;
        public const int RightIndex = 1;
        public const int DownIndex = 2;
        public const int LeftIndex = 3;

        public int Y { get; private set; }
        public int X { get; private set; }
        public int Parent { get; private set; }

        public Cell(int y, int x, int parent = -1)
        {
            Y = y;
            X = x;
            Parent = parent;
        }

        public static bool operator ==(Cell x, Cell y)
        {
            if ((object)x == null)
                return (object)y == null;
            else if ((object)y == null)
                return (object)x == null;

            return (x.X == y.X) && (x.Y == y.Y);
        }

        public static bool operator !=(Cell x, Cell y)
        {
            return !(x == y);
        }
    }
}
