using System.Collections.Generic;
using System.Linq;

namespace MultilayerTracing
{
    public static class TracingProcessor
    {
        public const char SourceCell = 'A';
        public const char TargetCell = 'B';
        public const char FreeCell = '.';
        public const char LockCell = 'X';

        public static List<PathCell> CalculatePath(List<char[,]> fields, Cell sourceCell, Cell targetCell)
        {
            List<List<Cell>> marked = new List<List<Cell>>();
            List<List<Cell>> L = new List<List<Cell>>();
            List<List<Cell>> M = new List<List<Cell>>();
            List<int> P = new List<int>();
            List<int> v = new List<int>();
            for (int i = 0; i < fields.Count; i++)
            {
                marked.Add(new List<Cell> { sourceCell });
                L.Add(new List<Cell> { sourceCell });
                M.Add(new List<Cell>());
                P.Add(0);
                v.Add(0);
            }

            List<PathCell> path = null;
            bool isFound = false;
            while (!isFound)
            {
                WaveFrontFormation(fields, ref marked, ref L, ref M, ref P, ref v);

                int index = CheckPathFound(L, targetCell);
                if (index >= 0)
                {
                    isFound = true;

                    targetCell.P = marked[index].Last().P;
                    path = GetResultPath(marked, index, sourceCell, targetCell);
                }
                else if (index == -2)
                {
                    isFound = true;
                }
            }

            return path;
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
        }

        private static List<Cell> GetFreeCells(char[,] field, List<Cell> marked, Cell cell, List<Cell> M, int P, int v)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            List<Cell> cells = new List<Cell>();
            if ((cell.Y - 1 >= 0) && (field[cell.Y - 1, cell.X] != LockCell)
                && (!marked.Any(n => (n.Y == cell.Y - 1) && (n.X == cell.X))))
            {
                cells.Add(new Cell(cell.Y - 1, cell.X, P, v));
            }
            if ((cell.X - 1 >= 0) && (field[cell.Y, cell.X - 1] != LockCell)
                && (!marked.Any(n => (n.Y == cell.Y) && (n.X == cell.X - 1))))
            {
                cells.Add(new Cell(cell.Y, cell.X - 1, P, v));
            }
            if ((cell.X + 1 < cols) && (field[cell.Y, cell.X + 1] != LockCell)
                && (!marked.Any(n => (n.Y == cell.Y) && (n.X == cell.X + 1))))
            {
                cells.Add(new Cell(cell.Y, cell.X + 1, P, v));
            }
            if ((cell.Y + 1 < rows) && (field[cell.Y + 1, cell.X] != LockCell)
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
                            && (fields[fieldIndex][L[i][j].Y, L[i][j].X] == FreeCell))
                        {
                            Cell cell = new Cell(L[i][j].Y, L[i][j].X, L[i][j].P, L[i][j].V + 1);
                            cells.Add(cell);
                        }
                    }
                }
            }

            return cells;
        }

        private static int CheckPathFound(List<List<Cell>> L, Cell targetCell)
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
                    if (L[i].Any(n => (n.Y == targetCell.Y) && (n.X == targetCell.X)))
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
    }
}
