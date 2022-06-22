using System.Linq;
using System.Collections.Generic;

namespace WayCoordinates
{
    public static class TracingProcessor
    {
        public static List<Cell> GetShortestPath(char[,] field, Cell source, Cell destination, 
            List<Cell> lockedCells, out List<Cell> marked)
        {
            marked = new List<Cell> { source };
            List<Cell> wayCoordinates = new List<Cell>();
            Cell currentCell = source;
            bool isFound = false;
            while (!isFound)
            {
                FrontFormation(field, currentCell, ref marked, lockedCells, destination);
                wayCoordinates.Add(currentCell);

                if (marked.Last() == destination)
                {
                    destination = marked.Last();
                    isFound = true;
                }
                else
                {
                    List<Cell> availableCells = marked.Where(n => !wayCoordinates.Any(m => (m.Y == n.Y) && (m.X == n.X))).ToList();
                    if (availableCells.Count > 0)
                    {
                        currentCell = availableCells.First();
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            List<Cell> path = CreatePath(marked, source, destination);
            return path;
        }

        private static void FrontFormation(char[,] field, Cell currentCell, 
            ref List<Cell> marked, List<Cell> lockedCells, Cell destination)
        {
            if (currentCell.Y - 1 >= 0)
            {
                Cell upCell = new Cell(currentCell.Y - 1, currentCell.X, Cell.UpIndex);
                if (!marked.Any(n => (n.Y == upCell.Y) && (n.X == upCell.X)) 
                    && !lockedCells.Any(n => (n.Y == upCell.Y) && (n.X == upCell.X)))
                {
                    marked.Add(upCell);

                    if (upCell == destination)
                        return;
                }
            }
            if (currentCell.X + 1 < field.GetLength(1))
            {
                Cell rightCell = new Cell(currentCell.Y, currentCell.X + 1, Cell.RightIndex);
                if (!marked.Any(n => (n.Y == rightCell.Y) && (n.X == rightCell.X)) 
                    && !lockedCells.Any(n => (n.Y == rightCell.Y) && (n.X == rightCell.X)))
                {
                    marked.Add(rightCell);

                    if (rightCell == destination)
                        return;
                }
            }
            if (currentCell.Y + 1 < field.GetLength(0))
            {
                Cell downCell = new Cell(currentCell.Y + 1, currentCell.X, Cell.DownIndex);
                if (!marked.Any(n => (n.Y == downCell.Y) && (n.X == downCell.X))
                    && !lockedCells.Any(n => (n.Y == downCell.Y) && (n.X == downCell.X)))
                {
                    marked.Add(downCell);

                    if (downCell == destination)
                        return;
                }
            }
            if (currentCell.X - 1 >= 0)
            {
                Cell leftCell = new Cell(currentCell.Y, currentCell.X - 1, Cell.LeftIndex);
                if (!marked.Any(n => (n.Y == leftCell.Y) && (n.X == leftCell.X))
                    && !lockedCells.Any(n => (n.Y == leftCell.Y) && (n.X == leftCell.X)))
                {
                    marked.Add(leftCell);

                    if (leftCell == destination)
                        return;
                }
            }
        }

        private static List<Cell> CreatePath(List<Cell> marked, Cell source, Cell destination)
        {
            Cell currentCell = destination;
            List<Cell> path = new List<Cell> { source };
            while (currentCell != source)
                AddPathCell(ref path, ref currentCell, marked);

            return path;
        }

        private static void AddPathCell(ref List<Cell> path, ref Cell currentCell, List<Cell> marked)
        {
            Cell currentPathCell = currentCell;
            Cell newPathCell = null;
            switch (currentCell.Parent)
            {
                case Cell.UpIndex:
                    newPathCell = marked.Where(n => (n.Y == currentPathCell.Y + 1) && (n.X == currentPathCell.X)).First();
                    break;
                case Cell.RightIndex:
                    newPathCell = marked.Where(n => (n.Y == currentPathCell.Y) && (n.X == currentPathCell.X - 1)).First();
                    break;
                case Cell.DownIndex:
                    newPathCell = marked.Where(n => (n.Y == currentPathCell.Y - 1) && (n.X == currentPathCell.X)).First();
                    break;
                case Cell.LeftIndex:
                    newPathCell = marked.Where(n => (n.Y == currentPathCell.Y) && (n.X == currentPathCell.X + 1)).First();
                    break;
                default:
                    break;
            }

            path.Add(newPathCell);
            currentCell = newPathCell;
        }
    }
}
