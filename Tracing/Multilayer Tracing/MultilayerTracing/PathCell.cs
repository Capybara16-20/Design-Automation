namespace MultilayerTracing
{
    public class PathCell
    {
        public Cell Cell { get; private set; }
        public int FieldIndex { get; private set; }

        public PathCell(Cell cell, int fieldIndex)
        {
            Cell = cell;
            FieldIndex = fieldIndex;
        }
    }
}
