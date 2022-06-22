using System;
using System.Collections.Generic;
using System.Linq;

namespace TempUI
{
    class Program
    {
        const char source = 'A';
        const char destination = 'B';
        const char freeCell = '.';
        const char lockCell = 'x';

        struct Cell
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

        class PathCell
        {
            public Cell Cell { get; private set; }
            public int FieldIndex { get; private set; }

            public PathCell(Cell cell, int fieldIndex)
            {
                Cell = cell;
                FieldIndex = fieldIndex;
            }
        }

        static void Main(string[] args)
        {
            char[,] field1 =
            {
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', 'B', '.', '.' },
                { '.', '.', '.', 'x', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', 'x', '.', '.', '.', '.', 'x', '.' },
                { '.', '.', '.', 'x', '.', '.', '.', '.', 'x', '.' },
                { '.', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                { 'x', 'x', 'x', 'x', 'x', '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', 'x', '.', '.', '.', '.', '.' },
                { '.', 'A', '.', '.', 'x', '.', '.', '.', '.', '.' }
            };

            char[,] field2 =
            {
                { '.', '.', '.', '.', '.', 'x', '.', '.', '.', '.' },
                { '.', '.', '.', 'x', '.', 'x', '.', 'B', '.', '.' },
                { '.', '.', '.', 'x', '.', 'x', '.', '.', '.', '.' },
                { '.', '.', '.', 'x', '.', 'x', 'x', 'x', 'x', 'x' },
                { '.', '.', '.', 'x', '.', '.', '.', '.', '.', '.' },
                { '.', '.', '.', 'x', '.', 'x', 'x', 'x', 'x', 'x' },
                { '.', '.', '.', 'x', '.', 'x', '.', '.', '.', '.' },
                { '.', '.', '.', 'x', '.', 'x', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.', 'x', 'x', 'x', 'x', '.' },
                { '.', 'A', '.', '.', '.', '.', '.', '.', 'x', '.' }
            };

            Cell sourceCell = new Cell(9, 1, 0, 0);
            Cell destinationCell = new Cell(1, 7);

            List<Cell> L1 = new List<Cell> { sourceCell };
            List<Cell> M1 = new List<Cell>();
            int P1 = 0;
            int v1 = 0;
            List<Cell> marked1 = new List<Cell> { sourceCell };

            List<Cell> L2 = new List<Cell> { sourceCell };
            List<Cell> M2 = new List<Cell>();
            int P2 = 0;
            int v2 = 0;
            List<Cell> marked2 = new List<Cell> { sourceCell };

            List<char[,]> fields = new List<char[,]> { field1, field2 };
            List<List<Cell>> L = new List<List<Cell>> { L1, L2 };
            List<List<Cell>> M = new List<List<Cell>> { M1, M2 };
            List<int> P = new List<int> { P1, P2 };
            List<int> v = new List<int> { v1, v2 };
            List<List<Cell>> marked = new List<List<Cell>> { marked1, marked2 };

            int step = 1;
            bool isFound = false;
            while (!isFound)
            {
                Console.WriteLine("Шаг " + step);
                WaveFrontFormation(fields, ref marked, ref L, ref M, ref P, ref v);

                int index = CheckPathFound(L, destinationCell);
                if (index >= 0)
                {
                    isFound = true;
                    Console.WriteLine("Путь найден в слое " + (index + 1));

                    destinationCell.P = marked[index].Last().P;
                    List<PathCell> path = GetResultPath(marked, index, sourceCell, destinationCell);
                    ShowPath(path);
                }
                else if (index == -2)
                {
                    isFound = true;
                    Console.WriteLine("Пути не существует");
                }

                step++;
            }
        }

        private static List<PathCell> GetResultPath(List<List<Cell>> marked, int fieldIndex, Cell sourceCell, Cell destinationCell)
        {
            List<PathCell> path = new List<PathCell> { new PathCell(destinationCell, fieldIndex) };

            int currentField = fieldIndex;
            Cell currentCell = destinationCell;
            while (!((currentCell.Y == sourceCell.Y) && (currentCell.X == sourceCell.X)))
            {
                List<Cell> nextCells = GetNextPathCells(currentCell, marked[fieldIndex], currentCell.P);
                if (nextCells.Count == 0)
                {
                    fieldIndex = (fieldIndex == marked.Count - 1) ? 0 : fieldIndex + 1;
                    path.Add(new PathCell(currentCell, fieldIndex));
                }
                else
                {
                    currentCell = nextCells.Where(n => n.V == nextCells.Min(t => t.V)).First();
                    path.Add(new PathCell(currentCell, fieldIndex));
                }
            }

            return path;
        }

        private static List<Cell> GetNextPathCells(Cell cell, List<Cell> marked, int P)
        {
            List<Cell> cells = new List<Cell>();
            cells.AddRange(marked.Where(n => (n.Y == cell.Y + 1) && (n.X == cell.X) && (n.P < P)));
            cells.AddRange(marked.Where(n => (n.Y == cell.Y) && (n.X == cell.X + 1) && (n.P < P)));
            cells.AddRange(marked.Where(n => (n.Y == cell.Y) && (n.X == cell.X - 1) && (n.P < P)));
            cells.AddRange(marked.Where(n => (n.Y == cell.Y - 1) && (n.X == cell.X) && (n.P < P)));

            return cells;
        }

        private static void WaveFrontFormation(List<char[,]> fields, ref List<List<Cell>> marked,
            ref List<List<Cell>> L, ref List<List<Cell>> M, ref List<int> P, ref List<int> v)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                P[i]++; //1
                foreach (Cell cell in L[i]) //2-4
                {
                    List<Cell> freeCells = GetFreeCells(fields[i], marked[i], cell, M[i], P[i], v[i]);
                    marked[i].AddRange(freeCells);
                    M[i].AddRange(freeCells);
                }

                L[i] = M[i].Select(n => n).ToList(); //5
                M[i].Clear();

                List<Cell> transitionCells = GetTransitionCells(fields, marked, L, i); //6-7
                if (transitionCells.Count > 0)
                {
                    v[i]++;
                    marked[i].AddRange(transitionCells);
                    L[i].AddRange(transitionCells);
                }


            }

            ShowFieldsData(fields, L, M);
        }

        private static List<Cell> GetFreeCells(char[,] field, List<Cell> marked, Cell cell, List<Cell> M, int P, int v)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            List<Cell> cells = new List<Cell>();
            if ((cell.Y - 1 >= 0) && (field[cell.Y - 1, cell.X] != lockCell)
                && (!marked.Any(n => (n.Y == cell.Y - 1) && (n.X == cell.X))))
            {
                cells.Add(new Cell(cell.Y - 1, cell.X, P, v));
            }
            if ((cell.X - 1 >= 0) && (field[cell.Y, cell.X - 1] != lockCell)
                && (!marked.Any(n => (n.Y == cell.Y) && (n.X == cell.X - 1))))
            {
                cells.Add(new Cell(cell.Y, cell.X - 1, P, v));
            }
            if ((cell.X + 1 < rows) && (field[cell.Y, cell.X + 1] != lockCell)
                && (!marked.Any(n => (n.Y == cell.Y) && (n.X == cell.X + 1))))
            {
                cells.Add(new Cell(cell.Y, cell.X + 1, P, v));
            }
            if ((cell.Y + 1 < cols) && (field[cell.Y + 1, cell.X] != lockCell)
                && (!marked.Any(n => (n.Y == cell.Y + 1) && (n.X == cell.X))))
            {
                cells.Add(new Cell(cell.Y + 1, cell.X, P, v));
            }

            return cells;
        }

        private static List<Cell> GetTransitionCells(List<char[,]> fields, List<List<Cell>> marked, 
            List<List<Cell>> L, int fieldIndex)
        {
            List<Cell> cells = new List<Cell>();
            for (int i = 0; i < L.Count; i++)
            {
                if (i != fieldIndex)
                {
                    for (int j = 0; j < L[i].Count; j++)
                    {
                        if (!marked[fieldIndex].Any(n => (n.Y == L[i][j].Y) && (n.X == L[i][j].X)) 
                            && (fields[fieldIndex][L[i][j].Y, L[i][j].X] == freeCell))
                        {
                            Cell cell = new Cell(L[i][j].Y, L[i][j].X, L[i][j].P, L[i][j].V + 1);
                            cells.Add(cell);
                        }
                    }
                }
            }

            return cells;
        }

        private static int CheckPathFound(List<List<Cell>> L, Cell destinationCell)
        {
            const int notExistIndex = -2;
            const int continueIndex = -1;

            bool isEmpty = true;
            foreach (List<Cell> l in L)
            {
                if (l.Count > 0)
                {
                    isEmpty = false;
                    break;
                }
            }

            if (isEmpty)
            {
                return notExistIndex;
            }
            else
            {
                bool isFound = false;
                int fieldIndex = -1;
                for (int i = 0; i < L.Count; i++)
                {
                    if (L[i].Any(n => (n.Y == destinationCell.Y) && (n.X == destinationCell.X)))
                    {
                        fieldIndex = i;
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    return fieldIndex;
                }
                else
                {
                    return continueIndex;
                }
            }
        }

        private static void ShowFieldsData(List<char[,]> fields, List<List<Cell>> L, List<List<Cell>> M)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                Console.Write("L" + (i + 1) + ": ");
                foreach (Cell cell in L[i])
                {
                    Console.Write((cell.Y + 1) + ":" + (cell.X + 1) + " " + cell.P + " " + cell.V + "   ");
                }
                Console.Write("\nM" + (i + 1) + ": ");
                foreach (Cell cell in M[i])
                {
                    Console.Write((cell.Y + 1) + ":" + (cell.X + 1) + " " + cell.P + " " + cell.V + "   ");
                }
                Console.WriteLine();
            }
        }

        private static void ShowPath(List<PathCell> path)
        {
            foreach(PathCell cell in path)
                Console.WriteLine((cell.FieldIndex + 1) + " " + (cell.Cell.Y + 1) + ":" + (cell.Cell.X + 1));
        }
    }
}
