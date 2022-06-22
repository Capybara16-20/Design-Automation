using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MultilayerTracing;

namespace MultilayerTracingUI
{
    public partial class FieldControl : UserControl
    {
        private const int cellSize = 30;

        private readonly int rows;
        private readonly int cols;
        private Button btnSource;
        private Button btnTarget;
        private Button btnLocked;
        private Button btnEmpty;
        private Panel panel;

        public Bitmap Bitmap { get; set; }
        public FieldCell Source { get; set; } = null;
        public FieldCell Target { get; set; } = null;
        public FieldCell[,] Cells { get; set; }
        public char[,] TracingField { get; set; }

        public FieldControl(int rows, int cols, string fieldName, Button btnSource, 
            Button btnTarget, Button btnLocked, Button btnEmpty, Panel panel, ref char[,] tracingField)
        {
            InitializeComponent();

            this.rows = rows;
            this.cols = cols;
            this.btnSource = btnSource;
            this.btnTarget = btnTarget;
            this.btnLocked = btnLocked;
            this.btnEmpty = btnEmpty;
            this.panel = panel;
            TracingField = tracingField;

            InitField(fieldName);
        }

        private void pbField_MouseClick(object sender, MouseEventArgs e) => FieldClickHandling(sender, e);

        private void InitField(string fieldName)
        {
            pField.Height = rows * cellSize + 25;
            pField.Width = cols * cellSize;
            lFieldName.Text = fieldName;

            InitCells();
            Bitmap = new Bitmap(cols * cellSize, rows * cellSize);
            DrawCells();
        }

        private void InitCells()
        {
            Cells = new FieldCell[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    Cells[i, j] = new FieldCell(j, i);
        }

        private void DrawCells()
        {
            Graphics graphics = Graphics.FromImage(Bitmap);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((Source == null) && (Target == null))
                    {
                        Cells[i, j].DrawEmptyCell(graphics, j * cellSize, i * cellSize, cellSize);
                    }
                    else
                    {
                        if ((Source != null) && (j == Source.X) && (i == Source.Y))
                        {
                            Cells[i, j].DrawEmptyCell(graphics, j * cellSize, i * cellSize, cellSize);
                        }
                        if ((Target != null) && (j == Target.X) && (i == Target.Y))
                        {
                            Cells[i, j].DrawEmptyCell(graphics, j * cellSize, i * cellSize, cellSize);
                        }
                    }
                }
            }

            pbField.Image = Bitmap;
        }

        private void FieldClickHandling(object sender, MouseEventArgs e)
        {
            int i = e.Y / cellSize;
            int j = e.X / cellSize;

            if (!btnSource.Enabled)
            {
                DrawSourceCell(i, j);
            }
            else if (!btnTarget.Enabled)
            {
                DrawTargetCell(i, j);
            }
            else if (!btnLocked.Enabled)
            {
                DrawLockedCell(i, j);
            }
            else if (!btnEmpty.Enabled)
            {
                DrawEmptyCell(i, j);
            }
        }

        public void DrawSourceCell(int i, int j)
        {
            foreach (FieldControl field in panel.Controls.OfType<FieldControl>())
            {
                Graphics graphics = Graphics.FromImage(field.Bitmap);
                if (field.Source != null)
                {
                    field.Cells[i, j].DrawEmptyCell(graphics, field.Source.X * cellSize, field.Source.Y * cellSize, cellSize);

                    field.TracingField[field.Source.Y, field.Source.X] = TracingProcessor.FreeCell;
                }

                field.Cells[i, j].DrawSourceCell(graphics, j * cellSize, i * cellSize, cellSize);
                field.Source = field.Cells[i, j];

                field.pbField.Image = field.Bitmap;

                field.TracingField[i, j] = TracingProcessor.SourceCell;
            }
        }

        public void DrawTargetCell(int i, int j)
        {
            foreach (FieldControl field in panel.Controls.OfType<FieldControl>())
            {
                Graphics graphics = Graphics.FromImage(field.Bitmap);
                if (field.Target != null)
                {
                    field.Cells[i, j].DrawEmptyCell(graphics, field.Target.X * cellSize, field.Target.Y * cellSize, cellSize);

                    field.TracingField[field.Target.Y, field.Target.X] = TracingProcessor.FreeCell;
                }

                field.Cells[i, j].DrawTargetCell(graphics, j * cellSize, i * cellSize, cellSize);
                field.Target = field.Cells[i, j];

                field.pbField.Image = field.Bitmap;

                field.TracingField[i, j] = TracingProcessor.TargetCell;
            }
        }

        private void DrawLockedCell(int i, int j)
        {
            Graphics graphics;
            foreach (FieldControl field in panel.Controls.OfType<FieldControl>())
            {
                graphics = Graphics.FromImage(field.Bitmap);

                if ((field.Source != null) && (field.Source.Y == i) && (field.Source.X == j))
                {
                    field.Cells[i, j].DrawEmptyCell(graphics, j * cellSize, i * cellSize, cellSize);
                    field.Source = null;

                    field.TracingField[i, j] = TracingProcessor.FreeCell;
                }
                if ((field.Target != null) && (field.Target.Y == i) && (field.Target.X == j))
                {
                    field.Cells[i, j].DrawEmptyCell(graphics, j * cellSize, i * cellSize, cellSize);
                    field.Target = null;

                    field.TracingField[i, j] = TracingProcessor.FreeCell;
                }

                field.pbField.Image = field.Bitmap;
            }

            graphics = Graphics.FromImage(Bitmap);
            Cells[i, j].DrawLockedCell(graphics, j * cellSize, i * cellSize, cellSize);

            pbField.Image = Bitmap;

            TracingField[i, j] = TracingProcessor.LockCell;
        }

        private void DrawEmptyCell(int i, int j)
        {
            Graphics graphics;
            if ((Source != null) && (Source.Y == i) && (Source.X == j))
            {
                foreach (FieldControl field in panel.Controls.OfType<FieldControl>())
                {
                    graphics = Graphics.FromImage(field.Bitmap);
                    field.Cells[i, j].DrawEmptyCell(graphics, j * cellSize, i * cellSize, cellSize);
                    field.Source = null;

                    field.pbField.Image = field.Bitmap;

                    field.TracingField[i, j] = TracingProcessor.FreeCell;
                }
            }
            if ((Target != null) && (Target.Y == i) && (Target.X == j))
            {
                foreach (FieldControl field in panel.Controls.OfType<FieldControl>())
                {
                    graphics = Graphics.FromImage(field.Bitmap);
                    field.Cells[i, j].DrawEmptyCell(graphics, j * cellSize, i * cellSize, cellSize);
                    field.Target = null;

                    field.pbField.Image = field.Bitmap;

                    field.TracingField[i, j] = TracingProcessor.FreeCell;
                }
            }

            graphics = Graphics.FromImage(Bitmap);
            Cells[i, j].DrawEmptyCell(graphics, j * cellSize, i * cellSize, cellSize);
            pbField.Image = Bitmap;

            TracingField[i, j] = TracingProcessor.FreeCell;
        }

        public void DrawPathCell(int i, int j)
        {
            Graphics graphics = Graphics.FromImage(Bitmap);
            Cells[i, j].DrawPathCell(graphics, j * cellSize, i * cellSize, cellSize);
            pbField.Image = Bitmap;
        }
    }
}
