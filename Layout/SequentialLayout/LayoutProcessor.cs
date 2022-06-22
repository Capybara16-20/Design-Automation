using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SequentialLayout
{
    public class LayoutProcessor
    {
        const string invalidFileMessage = "Некорректный файл";
        const string ratingPattern = "L{0} = {1}";
        const string emptyCalculation = "-";

        public List<List<int>> ChainsByElements { get; private set; }
        public List<List<int>> ElementsByChains { get; private set; }

        public LayoutProcessor(string filePath)
        {
            ChainsByElements = ReadFile(filePath);
            SetElementsByChains();
        }

        private void SetElementsByChains()
        {
            ElementsByChains = new List<List<int>>();
            int maxChainNumber = ChainsByElements.Max(n => n.Max(m => m));
            for (int i = 1; i <= maxChainNumber; i++)
            {
                ElementsByChains.Add(new List<int>());

                List<int> chainElements = ChainsByElements.Select((chains, index) => new { index, chains })
                    .Where(m => m.chains.Contains(i)).Select(m => m.index).ToList();
                ElementsByChains[i - 1].AddRange(chainElements);
            }
        }

        public List<List<int>> ArrangeBlocks(out List<List<string>> calculations, int maxElements, int maxPins)
        {
            const int fictitiousElement = 0;

            calculations = new List<List<string>>();
            for (int i = 0; i < ChainsByElements.Count; i++)
                calculations.Add(new List<string>());

            List<List<int>> blocks = new List<List<int>>();

            List<int> placedElements = new List<int> { fictitiousElement };
            while (placedElements.Count < ChainsByElements.Count)
            {
                List<int> nextBlock = GetNextBlock(maxElements, maxPins, placedElements, ref calculations);
                blocks.Add(nextBlock);
            }

            return blocks;
        }

        private List<int> GetNextBlock(int maxElements, int maxPins, 
            List<int> placedElements, ref List<List<string>> calculations)
        {
            List<int> block = new List<int>();
            block.Add(GetBaseElement(placedElements, ref calculations));

            bool addElement = true;
            while ((block.Count < maxElements) && (placedElements.Count < ChainsByElements.Count) && addElement)
            {
                int addedElement = GetNextElement(block, placedElements, maxPins, ref addElement, ref calculations);
                if (addElement)
                {
                    placedElements.Add(addedElement);
                    block.Add(addedElement);
                }
            }

            return block;
        }

        private int GetBaseElement(List<int> placedElements, ref List<List<string>> calculations)
        {
            int[] L1 = GetL1Ratings(placedElements, ref calculations);

            int baseElement = L1.Select((l1, index) => new { index, l1 })
                .Where(n => n.l1 == L1.Max()).Select(n => n.index).Last();

            placedElements.Add(baseElement);
            return baseElement;
        }

        private int[] GetL1Ratings(List<int> placedElements, ref List<List<string>> calculations)
        {
            List<int> unplacedElements = GetUnplacedElements(placedElements);
            int[] ratings = new int[ChainsByElements.Count];

            for (int i = 0; i < placedElements.Count; i++)
                ratings[placedElements[i]] = int.MinValue;

            for (int i = 0; i < unplacedElements.Count; i++)
            {
                int rating = GetL1Rating(unplacedElements, unplacedElements[i]);
                ratings[unplacedElements[i]] = rating;
                calculations[unplacedElements[i]].Add(string.Format(ratingPattern, 1, rating));
            }

            foreach (int element in placedElements)
                calculations[element].Add(emptyCalculation);

            return ratings;
        }

        private int GetL1Rating(List<int> unplacedElements, int element)
        {
            List<int> elementChains = ChainsByElements[element];
            int rating = 0;
            foreach (int chainIndex in elementChains)
            {
                List<int> chainElements = ElementsByChains[chainIndex - 1].Intersect(unplacedElements).ToList();
                if (chainElements.Count > 1)
                {
                    rating++;
                }
            }

            return rating;
        }

        private int GetNextElement(List<int> block, List<int> placedElements, int maxPinsCount, 
            ref bool addElement, ref List<List<string>> calculations)
        {
            int[] L2 = GetL2Ratings(block, placedElements, ref calculations);

            List<int> unplacedElements = GetUnplacedElements(placedElements);
            List<int> suitableElements = L2.Select((s, i) => new { i, s })
                .Where(n => (n.s <= maxPinsCount) && (unplacedElements.Contains(n.i))).Select(n => n.i).ToList();

            int addedElement = -1;
            if (suitableElements.Count == 0)
            {
                addElement = false;
            }
            else if (suitableElements.Count > 1)
            {
                int[] L3 = GetL3Ratings(block, suitableElements, ref calculations);

                List<int> maxL3 = L3.Select((s, i) => new { i, s })
                    .Where(n => (n.s == L3.Max()) && (suitableElements.Contains(n.i))).Select(n => n.i).ToList();
                if (maxL3.Count > 1)
                {
                    var maxL3L2 = L2.Select((s, i) => new { i, s }).Where(n => maxL3.Contains(n.i)).Select(n => n).ToList();
                    List<int> minL2 = maxL3L2.Select(n => n).Where(n => n.s == maxL3L2.Min(x => x.s)).Select(n => n.i).ToList();

                    List<int> elementsToAdd = maxL3.Intersect(minL2).ToList();
                    addedElement = elementsToAdd.Last();

                }
                else
                {
                    addedElement = maxL3.First();

                }
            }
            else
            {
                addedElement = suitableElements.First();
            }

            return addedElement;
        }

        private int[] GetL2Ratings(List<int> block, List<int> placedElements, ref List<List<string>> calculations)
        {
            List<int> unplacedElements = GetUnplacedElements(placedElements);
            int[] ratings = new int[ChainsByElements.Count];
            for (int i = 0; i < unplacedElements.Count; i++)
            {
                int rating = GetL2Rating(unplacedElements[i], block);
                ratings[unplacedElements[i]] = rating;
                calculations[unplacedElements[i]].Add(string.Format(ratingPattern, 2, rating));
            }

            foreach (int element in placedElements)
                calculations[element].Add(emptyCalculation);

            return ratings;
        }

        private int GetL2Rating(int element, List<int> block)
        {
            List<int> elementChains = ChainsByElements[element];
            for (int i = 0; i < block.Count; i++)
            {
                List<int> blockElementChains = ChainsByElements[block[i]];
                elementChains = elementChains.Union(blockElementChains).ToList();
            }

            List<int> currentElements = block.Select(n => n).ToList();
            currentElements.Add(element);

            int rating = 0;
            foreach (int chainIndex in elementChains)
            {
                List<int> chainElements = ElementsByChains[chainIndex - 1];

                List<int> exceptElements = chainElements.Except(currentElements).ToList();
                if (exceptElements.Count > 0)
                {
                    rating++;
                }
            }

            return rating;
        }

        private int[] GetL3Ratings(List<int> block, List<int> suitableElements, ref List<List<string>> calculations)
        {
            int[] ratings = new int[ChainsByElements.Count];
            for (int i = 0; i < suitableElements.Count; i++)
            {
                int rating = GetL3Rating(suitableElements[i], block);
                ratings[suitableElements[i]] = rating;
                calculations[suitableElements[i]].Add(string.Format(ratingPattern, 3, rating));
            }

            foreach (int element in Enumerable.Range(0, ChainsByElements.Count).ToList()
                .Except(suitableElements).ToList())
                calculations[element].Add(emptyCalculation);

            return ratings;
        }

        private int GetL3Rating(int element, List<int> block)
        {
            List<int> elementChains = ChainsByElements[element];
            List<int> blockElements = block.Select(n => n).ToList();
            int rating = 0;
            foreach (int chainIndex in elementChains)
            {
                List<int> chainElements = ElementsByChains[chainIndex - 1];

                List<int> intersectElements = chainElements.Intersect(blockElements).ToList();
                List<int> exceptElements = chainElements.Except(blockElements).ToList();
                if ((intersectElements.Count > 0) && (exceptElements.Count > 0))
                {
                    rating++;
                }
            }

            return rating;
        }

        private List<int> GetUnplacedElements(List<int> placedElements)
        {
            return Enumerable.Range(0, ChainsByElements.Count).ToList()
              .Except(placedElements).ToList();
        }

        private static List<List<int>> ReadFile(string filePath)
        {
            const char separator = ',';

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length != 2)
                throw new ArgumentException(invalidFileMessage);

            string[] chainsPart = lines[0].Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] elementsPart = lines[1].Split(separator, StringSplitOptions.RemoveEmptyEntries);
            
            int[] chains = ParseStringArray(chainsPart, out bool isChainsParsed);
            if (!isChainsParsed)
                throw new ArgumentException(invalidFileMessage);

            int[] elements = ParseStringArray(elementsPart, out bool isElementsParsed);
            if (!isElementsParsed)
                throw new ArgumentException(invalidFileMessage);

            if (!CheckElements(elements))
                throw new ArgumentException(invalidFileMessage);

            if (elements.Last() != chains.Length)
                throw new ArgumentException(invalidFileMessage);

            List<List<int>> chainsByElements = new List<List<int>>();
            int currentStartIndex = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                chainsByElements.Add(new List<int>());
                for (int j = currentStartIndex; j < elements[i]; j++)
                {
                    chainsByElements[i - 1].Add(chains[j]);
                }

                currentStartIndex += (elements[i] - currentStartIndex);
            }

            return chainsByElements;
        }

        private static bool CheckElements(int[] elements)
        {
            if (elements[0] != 0)
                return false;

            int currentElement = -1;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > currentElement)
                {
                    currentElement = elements[i];
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
    }
}
