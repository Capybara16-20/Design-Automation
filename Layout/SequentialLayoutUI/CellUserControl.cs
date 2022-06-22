using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SequentialLayoutUI
{
    public partial class CellUserControl : UserControl
    {
        private const string tooMachChainsMessage = "Слишком много соединений элемента (максимум 8)";
        private const int shift = 10;
        private const int cellSize = 50;
        private const int connectionLength = 20;
        private Font elementFont = new Font("Calibri", 14);
        private Font chainFont = new Font("Calibri", 11);
        private int lineWidth = 1;
        private string elementNamePattern = "E{0}";
        private string chainNamePattern = "v{0}";
        private Bitmap map;

        public CellUserControl(int number, List<int> chains)
        {
            InitializeComponent();

            Size = new Size(cellSize + connectionLength * 2 + shift * 2, cellSize + connectionLength * 2 + shift * 2);
            pbCell.Location = new Point(shift, shift);
            pbCell.Size = new Size(cellSize + connectionLength * 2, cellSize + connectionLength * 2);
            map = new Bitmap(cellSize + connectionLength * 2, cellSize + connectionLength * 2);

            lbCalculation.Size = new Size(0, 0);
            pbNumber.Size = new Size(0, 0);

            Draw(string.Format(elementNamePattern, number), chains);
        }

        public void Draw(string name, List<int> chains)
        {
            Graphics graphics = Graphics.FromImage(map);
            graphics.FillRectangle(new SolidBrush(Color.DarkGray), connectionLength, connectionLength, cellSize, cellSize);
            graphics.DrawRectangle(new Pen(Color.Black, lineWidth), connectionLength, connectionLength, cellSize, cellSize);

            float centerX = connectionLength + cellSize / 2;
            float centerY = connectionLength + cellSize / 2;
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            graphics.DrawString(name, elementFont, new SolidBrush(Color.Black), centerX, centerY, format);

            for (int i = 0; i < chains.Count; i++)
                DrawConnection(graphics, i, string.Format(chainNamePattern, chains[i]));

            pbCell.Image = map;
        }

        public void DrawConnection(Graphics graphics, int connectionNumber, string connectionName)
        {
            Point start;
            Point end;
            switch (connectionNumber)
            {
                case 0:
                    start = new Point(0, connectionLength + cellSize * 2 / 3);
                    end = new Point(connectionLength, connectionLength + cellSize * 2 / 3);
                    DrawConnectionName(graphics, (start.X + end.X) / 2, (start.Y + end.Y) / 2 + chainFont.Height / 2, connectionName);
                    break;
                case 1:
                    start = new Point(0, connectionLength + cellSize / 3);
                    end = new Point(connectionLength, connectionLength + cellSize / 3);
                    DrawConnectionName(graphics, (start.X + end.X) / 2, (start.Y + end.Y) / 2 - chainFont.Height / 2, connectionName);
                    break;
                case 2:
                    start = new Point(connectionLength + cellSize / 3, 0);
                    end = new Point(connectionLength + cellSize / 3, connectionLength);
                    DrawConnectionName(graphics, (start.X + end.X) / 2 - (int)chainFont.Size, (start.Y + end.Y) / 2, connectionName);
                    break;
                case 3:
                    start = new Point(connectionLength + cellSize * 2 / 3, 0);
                    end = new Point(connectionLength + cellSize * 2 / 3, connectionLength);
                    DrawConnectionName(graphics, (start.X + end.X) / 2 + (int)chainFont.Size, (start.Y + end.Y) / 2, connectionName);
                    break;
                case 4:
                    start = new Point(connectionLength + cellSize, connectionLength + cellSize / 3);
                    end = new Point(connectionLength * 2 + cellSize, connectionLength + cellSize / 3);
                    DrawConnectionName(graphics, (start.X + end.X) / 2, (start.Y + end.Y) / 2 - chainFont.Height / 2, connectionName);
                    break;
                case 5:
                    start = new Point(connectionLength + cellSize, connectionLength + cellSize * 2 / 3);
                    end = new Point(connectionLength * 2 + cellSize, connectionLength + cellSize * 2 / 3);
                    DrawConnectionName(graphics, (start.X + end.X) / 2, (start.Y + end.Y) / 2 + chainFont.Height / 2, connectionName);
                    break;
                case 6:
                    start = new Point(connectionLength + cellSize * 2 / 3, connectionLength + cellSize);
                    end = new Point(connectionLength + cellSize * 2 / 3, connectionLength * 2 + cellSize);
                    DrawConnectionName(graphics, (start.X + end.X) / 2 + (int)chainFont.Size, (start.Y + end.Y) / 2, connectionName);
                    break;
                case 7:
                    start = new Point(connectionLength + cellSize / 3, connectionLength + cellSize);
                    end = new Point(connectionLength + cellSize / 3, connectionLength * 2 + cellSize);
                    DrawConnectionName(graphics, (start.X + end.X) / 2 - (int)chainFont.Size, (start.Y + end.Y) / 2, connectionName);
                    break;
                default:
                    throw new ArgumentException(tooMachChainsMessage);
            }

            graphics.DrawLine(new Pen(Color.Black, lineWidth), start, end);
        }

        private void DrawConnectionName(Graphics graphics, int x, int y, string name)
        {
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            graphics.DrawString(name, chainFont, new SolidBrush(Color.Black), x, y, format);
        }

        public void AddCalculations(List<string> calculations, int block)
        {
            Height = cellSize + connectionLength * 2 + shift * 3 + (calculations.Count - 1) * chainFont.Height;
            lbCalculation.Size = new Size(cellSize + connectionLength * 2, (calculations.Count - 1) * chainFont.Height - chainFont.Height / 2);
            lbCalculation.Location = new Point(shift, pbCell.Height + shift * 2);

            lbCalculation.Items.Clear();
            lbCalculation.Items.AddRange(calculations.ToArray());

            pbNumber.Location = new Point(shift, shift * 2 + pbCell.Height + lbCalculation.Height);
            pbNumber.Size = new Size(pbCell.Width, elementFont.Height);
            Bitmap bitmap = new Bitmap(pbCell.Width, elementFont.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            DrawFieldNumber(graphics, block);

            pbNumber.Image = bitmap;
        }

        public void DrawFieldNumber(Graphics graphics, int fieldNumber)
        {
            int x = pbNumber.Width / 2;
            int y = pbNumber.Height / 2;
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            graphics.DrawString(fieldNumber.ToString(), elementFont, new SolidBrush(Color.Black), x, y, format);
        }
    }
}
