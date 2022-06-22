using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WayCoordinates;

namespace WayCoordinatesUI
{
    public partial class Form : System.Windows.Forms.Form
    {
        private const int cellSize = 50;
        private char[,] field;
        private Cell source = null;
        private Cell destination = null;
        private List<Cell> lockedCells = new List<Cell>();
        private Bitmap map;
        private readonly Font cellFont = new Font("Cambria", 16);
        private const int cellBorderWidth = 2;
        private const string upArrow = "↑";
        private const string rightArrow = "→";
        private const string downArrow = "↓";
        private const string leftArrow = "←";

        public Form()
        {
            InitializeComponent();
            InitForm();
        }

        private void nudRows_ValueChanged(object sender, EventArgs e) => FieldSizeChangeHandling();
        private void nudColumns_ValueChanged(object sender, EventArgs e) => FieldSizeChangeHandling();
        private void btnLoadField_Click(object sender, EventArgs e) => LoadField();
        private void btnAddSource_Click(object sender, EventArgs e) => AddSource();
        private void btnAddDestination_Click(object sender, EventArgs e) => AddDestination();
        private void btnAddLock_Click(object sender, EventArgs e) => AddLock();
        private void btnClearCell_Click_1(object sender, EventArgs e) => ClearCell();
        private void pbField_MouseClick(object sender, MouseEventArgs e) => FieldClickHandling(sender, e);
        private void btnShowPath_Click(object sender, EventArgs e) => ShowPath();

        private void InitForm()
        {
            InitNewField();
            DrawField();
        }

        private void InitNewField()
        {
            int rows = (int)nudRows.Value;
            int columns = (int)nudColumns.Value;
            field = new char[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    field[i, j] = LoadFieldProcessor.EmptyCell;
        }

        private void DrawField()
        {
            int rows = (int)nudRows.Value;
            int columns = (int)nudColumns.Value;
            pbField.Size = new Size(columns * cellSize, rows * cellSize);
            map = new Bitmap(columns * cellSize, rows * cellSize);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    switch(field[i, j])
                    {
                        case LoadFieldProcessor.EmptyCell:
                            DrawEmptyCell(i * cellSize, j * cellSize);
                            break;
                        case LoadFieldProcessor.LockedCell:
                            DrawLockCell(i * cellSize, j * cellSize);
                            break;
                        case LoadFieldProcessor.SourceCell:
                            DrawSourceCell(i * cellSize, j * cellSize);
                            break;
                        case LoadFieldProcessor.DestinationCell:
                            DrawDestinationCell(i * cellSize, j * cellSize);
                            break;
                    }
                }
            }
        }

        private void DrawCell(int y, int x, Color color, string text = null)
        {
            Graphics graphics = Graphics.FromImage(map);

            graphics.FillRectangle(new SolidBrush(color), x, y, cellSize, cellSize);
            graphics.DrawRectangle(new Pen(Color.Black, cellBorderWidth), x, y, cellSize, cellSize);
            if (!string.IsNullOrEmpty(text))
            {
                float centerX = cellSize / 2 + x - cellFont.Size;
                float centerY = cellSize / 2 + y - cellFont.Height / 2;
                graphics.DrawString(text, cellFont, new SolidBrush(Color.Black), centerX, centerY);
            }

            pbField.Image = map;
        }

        private void DrawEmptyCell(int y, int x)
        {
            DrawCell(y, x, Color.LightGray);
        }

        private void DrawLockCell(int y, int x)
        {
            DrawCell(y, x, Color.DimGray, LoadFieldProcessor.LockedCell.ToString());
        }

        private void DrawSourceCell(int y, int x)
        {
            DrawCell(y, x, Color.Red, LoadFieldProcessor.SourceCell.ToString());
        }

        private void DrawDestinationCell(int y, int x)
        {
            DrawCell(y, x, Color.Blue, LoadFieldProcessor.DestinationCell.ToString());
        }

        private void DrawMarkedCell(int y, int x, string arrow)
        {
            DrawCell(y, x, Color.LightGray, arrow);
        }

        private void DrawPathCell(int y, int x, string arrow)
        {
            DrawCell(y, x, Color.LightGreen, arrow);
        }

        private void FieldClickHandling(object sender, MouseEventArgs e)
        {
            int i = e.Y / cellSize;
            int j = e.X / cellSize;

            if (!btnAddSource.Enabled)
            {
                if (source != null)
                {
                    DrawEmptyCell(source.Y * cellSize, source.X * cellSize);
                    field[source.Y, source.X] = LoadFieldProcessor.EmptyCell;
                }

                DrawSourceCell(i * cellSize, j * cellSize);
                source = new Cell(i, j);
                field[i, j] = LoadFieldProcessor.SourceCell;

                RemoveLocked(source);
            }
            else if (!btnAddDestination.Enabled)
            {
                if (destination != null)
                {
                    DrawEmptyCell(destination.Y * cellSize, destination.X * cellSize);
                    field[destination.Y, destination.X] = LoadFieldProcessor.EmptyCell;
                }

                DrawDestinationCell(i * cellSize, j * cellSize);
                destination = new Cell(i, j);
                field[i, j] = LoadFieldProcessor.DestinationCell;

                RemoveLocked(destination);
            }
            else if (!btnAddLock.Enabled)
            {
                if ((source != null) && (source.Y == i) && (source.X == j))
                {
                    source = null;
                }
                if ((destination != null) && (destination.Y == i) && (destination.X == j))
                {
                    destination = null;
                }

                DrawLockCell(i * cellSize, j * cellSize);
                field[i, j] = LoadFieldProcessor.LockedCell;

                Cell locked = new Cell(i, j);
                AddLocked(locked);
            }
            else if (!btnClearCell.Enabled)
            {
                if ((source != null) && (source.Y == i) && (source.X == j))
                {
                    source = null;
                }
                if ((destination != null) && (destination.Y == i) && (destination.X == j))
                {
                    destination = null;
                }

                DrawEmptyCell(i * cellSize, j * cellSize);
                field[i, j] = LoadFieldProcessor.EmptyCell;

                Cell cleared = new Cell(i, j);
                RemoveLocked(cleared);
            }
        }

        private void AddLocked(Cell cell)
        {
            if (!lockedCells.Any(n => n == cell))
                lockedCells.Add(cell);
        }

        private void RemoveLocked(Cell cell)
        {
            List<Cell> cells = lockedCells.Where(n => n == cell).ToList();
            if (cells.Count > 0)
                lockedCells.Remove(cells.First());
        }

        private void AddSource()
        {
            btnAddSource.Enabled = false;
            btnAddDestination.Enabled = true;
            btnAddLock.Enabled = true;
            btnClearCell.Enabled = true;
        }

        private void AddDestination()
        {
            btnAddSource.Enabled = true;
            btnAddDestination.Enabled = false;
            btnAddLock.Enabled = true;
            btnClearCell.Enabled = true;
        }

        private void AddLock()
        {
            btnAddSource.Enabled = true;
            btnAddDestination.Enabled = true;
            btnAddLock.Enabled = false;
            btnClearCell.Enabled = true;
        }

        private void ClearCell()
        {
            btnAddSource.Enabled = true;
            btnAddDestination.Enabled = true;
            btnAddLock.Enabled = true;
            btnClearCell.Enabled = false;
        }

        private void ShowPath()
        {
            if (source == null)
            {
                MessageBox.Show("Добавьте ячейку-источник");
                return;
            }
            if (destination == null)
            {
                MessageBox.Show("Добавьте ячейку-цель");
                return;
            }

            List<Cell> path = TracingProcessor.GetShortestPath(field, source, destination, lockedCells, out List<Cell> marked);

            if (path != null)
            {
                DrawMarkedCells(marked);
                DrawPath(path);
            }
            else
            {
                MessageBox.Show("Путь отсутствует");
            }
        }

        private void DrawPath(List<Cell> path)
        {
            for (int i = 1; i < path.Count - 1; i++)
            {
                switch (path[i].Parent)
                {
                    case Cell.UpIndex:
                        DrawPathCell(path[i].Y * cellSize, path[i].X * cellSize, upArrow);
                        break;
                    case Cell.RightIndex:
                        DrawPathCell(path[i].Y * cellSize, path[i].X * cellSize, rightArrow);
                        break;
                    case Cell.DownIndex:
                        DrawPathCell(path[i].Y * cellSize, path[i].X * cellSize, downArrow);
                        break;
                    case Cell.LeftIndex:
                        DrawPathCell(path[i].Y * cellSize, path[i].X * cellSize, leftArrow);
                        break;
                }
            }
        }

        private void DrawMarkedCells(List<Cell> marked)
        {
            for (int i = 1; i < marked.Count - 1; i++)
            {
                switch (marked[i].Parent)
                {
                    case Cell.UpIndex:
                        DrawMarkedCell(marked[i].Y * cellSize, marked[i].X * cellSize, upArrow);
                        break;
                    case Cell.RightIndex:
                        DrawMarkedCell(marked[i].Y * cellSize, marked[i].X * cellSize, rightArrow);
                        break;
                    case Cell.DownIndex:
                        DrawMarkedCell(marked[i].Y * cellSize, marked[i].X * cellSize, downArrow);
                        break;
                    case Cell.LeftIndex:
                        DrawMarkedCell(marked[i].Y * cellSize, marked[i].X * cellSize, leftArrow);
                        break;
                }
            }
        }

        private void FieldSizeChangeHandling()
        {
            int newRows = (int)nudRows.Value;
            int newColumns = (int)nudColumns.Value;
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            if (newRows > rows)
            {
                AddFieldRow(ref field);
            }
            else if (newRows < rows)
            {
                RemoveFieldRow(ref field);
            }
            else if (newColumns > columns)
            {
                AddFieldColumns(ref field);
            }
            else if (newColumns < columns)
            {
                RemoveFieldColumns(ref field);
            }

            DrawField();
        }

        private static void AddFieldRow(ref char[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            char[,] newField = new char[rows + 1, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    newField[i, j] = field[i, j];

            for (int i = 0; i < columns; i++)
                newField[rows, i] = LoadFieldProcessor.EmptyCell;

            field = newField;
        }

        private void RemoveFieldRow(ref char[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            char[,] newField = new char[rows - 1, columns];
            for (int i = 0; i < rows - 1; i++)
                for (int j = 0; j < columns; j++)
                    newField[i, j] = field[i, j];

            field = newField;

            if ((source != null) && (rows - 1 <= source.Y))
                source = null;
            if ((destination != null) && (rows - 1 <= destination.Y))
                destination = null;
        }

        private static void AddFieldColumns(ref char[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            char[,] newField = new char[rows, columns + 1];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    newField[i, j] = field[i, j];

            for (int i = 0; i < rows; i++)
                newField[i, columns] = LoadFieldProcessor.EmptyCell;

            field = newField;
        }

        private void RemoveFieldColumns(ref char[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            char[,] newField = new char[rows, columns - 1];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns - 1; j++)
                    newField[i, j] = field[i, j];

            field = newField;

            if ((source != null) && (columns - 1 <= source.X))
                source = null;
            if ((destination != null) && (columns - 1 <= destination.X))
                destination = null;
        }

        private void LoadField()
        {
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filePath = openFileDialog.FileName;
            try
            {
                field = LoadFieldProcessor.ReadField(filePath, out source, out destination, out lockedCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            nudRows.Value = field.GetLength(0);
            nudColumns.Value = field.GetLength(1);

            DrawField();
        }
    }
}
