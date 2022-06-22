using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SequentialDistribution
{
    public static class FileProcessor
    {
        const string fileNotFoundErrorMessage = "Файл не найден.";
        const string invalidListsMessage = "Некорректные SP-RSP списки.";

        public static List<List<int>> ReadList(string filePath)
        {
            const char separator = ',';
            const int spIndex = 0;
            const int rspIndex = 1;

            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            string[] lines = ReadLines(filePath);

            if (lines.Length != 2)
                throw new ArgumentException(invalidListsMessage);

            string[] spLineParts = lines[spIndex].Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] rspLineParts = lines[rspIndex].Split(separator, StringSplitOptions.RemoveEmptyEntries);

            int[] spElements = ParseStringArray(spLineParts, out bool isSPParsed);
            if (!isSPParsed)
                throw new ArgumentException(invalidListsMessage);

            int[] rspElements = ParseStringArray(rspLineParts, out bool isRSPParsed);
            if (!isRSPParsed)
                throw new ArgumentException(invalidListsMessage);

            if (!CheckRSP(rspElements))
                throw new ArgumentException(invalidListsMessage);

            if (rspElements.Last() != spElements.Length)
                throw new ArgumentException(invalidListsMessage);

            List<List<int>> elements = new List<List<int>>();
            int currentStartIndex = rspElements[0];
            for (int i = 1; i < rspElements.Length; i++)
            {
                elements.Add(new List<int>());
                for (int j = currentStartIndex; j < rspElements[i]; j++)
                {
                    elements[i - 1].Add(spElements[j]);
                }

                currentStartIndex += (rspElements[i] - currentStartIndex);
            }

            return elements;
        }

        private static bool CheckRSP(int[] rspElements)
        {
            int currentElement = -1;
            for (int i = 0; i < rspElements.Length; i++)
            {
                if (rspElements[i] > currentElement)
                {
                    currentElement = rspElements[i];
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static int[] ParseStringArray(string[] array, out bool isParsed)
        {
            isParsed = true;
            int[] newArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (int.TryParse(array[i], out int element))
                {
                    newArray[i] = element;
                }
                else
                {
                    isParsed = false;
                    return null;
                }
            }

            return newArray;
        }

        private static string[] ReadLines(string filePath)
        {
            string[] lines;
            if (File.Exists(filePath))
                lines = File.ReadAllLines(filePath);
            else
                throw new FileNotFoundException(fileNotFoundErrorMessage);

            return lines;
        }
    }
}
