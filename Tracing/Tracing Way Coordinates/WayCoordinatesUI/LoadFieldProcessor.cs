using System;
using System.Collections.Generic;
using System.IO;
using WayCoordinates;

namespace WayCoordinatesUI
{
    public static class LoadFieldProcessor
    {
        public const char EmptyCell = '-';
        public const char LockedCell = '#';
        public const char SourceCell = 'A';
        public const char DestinationCell = 'B';

        private const string notAvailableMessage = "Файл не доступен";
        private const string invalidFieldMessage = "Некорректное поле";

        public static char[,] ReadField(string filePath, out Cell source, 
            out Cell destination, out List<Cell> lockedCells)
        {
            source = null;
            destination = null;
            lockedCells = new List<Cell>();

            char[,] field;
            string[] lines = ReadLines(filePath);
            if (lines.Length == 0)
                throw new ArgumentException(invalidFieldMessage);

            field = GetField(lines, ref source, ref destination, ref lockedCells);

            return field;
        }

        private static char[,] GetField(string[] lines, ref Cell source, 
            ref Cell destination, ref List<Cell> lockedCells)
        {
            int rows = lines.Length;
            int cols = lines[0].Length;

            char[,] field = new char[rows, cols];
            int sourceCount = 0;
            int destinationCount = 0;
            for (int i = 0; i < rows; i++)
            {
                if (lines[i].Length == cols)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        switch(lines[i][j])
                        {
                            case EmptyCell:
                                field[i, j] = EmptyCell;
                                break;
                            case LockedCell:
                                field[i, j] = LockedCell;
                                lockedCells.Add(new Cell(i, j));
                                break;
                            case SourceCell:
                                sourceCount++;
                                field[i, j] = SourceCell;
                                source = new Cell(i, j);
                                break;
                            case DestinationCell:
                                destinationCount++;
                                field[i, j] = DestinationCell;
                                destination = new Cell(i, j);
                                break;
                            default:
                                throw new ArgumentException(invalidFieldMessage);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException(invalidFieldMessage);
                }
            }

            if ((sourceCount > 1) || (destinationCount > 1))
                throw new ArgumentException(invalidFieldMessage);

            if ((source == null) && (destination == null))
                throw new ArgumentException(invalidFieldMessage);

            return field;
        }

        private static string[] ReadLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
