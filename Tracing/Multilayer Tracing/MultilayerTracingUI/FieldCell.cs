using System.Drawing;

namespace MultilayerTracingUI
{
    public class FieldCell
    {
        private const int borderWidth = 2;
        private const string sourceCellText = "A";
        private const string targetCellText = "B";
        private const string lockedCellText = "X";
        private readonly Color emptyCellColor = Color.DarkGray;
        private readonly Color lockedCellColor = Color.DimGray;
        private readonly Color sourceCellColor = Color.LightSteelBlue;
        private readonly Color targetCellColor = Color.Coral;
        private readonly Color pathCellColor = Color.SpringGreen;
        private readonly Font font = new Font("Calibri", 16);

        public int X { get; set; }
        public int Y { get; set; }

        public FieldCell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DrawCell(Graphics g, int x, int y, int size, Color color, string text)
        {
            g.FillRectangle(new SolidBrush(color), x, y, size, size);
            g.DrawRectangle(new Pen(Color.Black, borderWidth), x, y, size, size);


            if (!string.IsNullOrEmpty(text))
            {
                float centerX = size / 2 + x - 10;
                float centerY = size / 2 + y - 12;
                StringFormat format = new StringFormat();
                g.DrawString(text, font, new SolidBrush(Color.Black), centerX, centerY, format);
            }
        }

        public void DrawEmptyCell(Graphics g, int x, int y, int size)
        {
            DrawCell(g, x, y, size, emptyCellColor, string.Empty);
        }

        public void DrawSourceCell(Graphics g, int x, int y, int size)
        {
            DrawCell(g, x, y, size, sourceCellColor, sourceCellText);
        }

        public void DrawTargetCell(Graphics g, int x, int y, int size)
        {
            DrawCell(g, x, y, size, targetCellColor, targetCellText);
        }

        public void DrawLockedCell(Graphics g, int x, int y, int size)
        {
            DrawCell(g, x, y, size, lockedCellColor, lockedCellText);
        }

        public void DrawPathCell(Graphics g, int x, int y, int size)
        {
            DrawCell(g, x, y, size, pathCellColor, string.Empty);
        }
    }
}
