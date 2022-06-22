using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequentialDistribution
{
    public class CompositionProcessor
    {

        private readonly List<List<int>> elementsByChain;
        private readonly int elementsCount;
        private List<List<int>> blocks;
        const int fictitiousElement = 0;

        public List<List<string>> Steps { get; private set; }

        public CompositionProcessor(string fileName)
        {
            elementsByChain = FileProcessor.ReadList(fileName);
            elementsCount = elementsByChain.Select(n => n.Max()).Max() + 1;
        }

        public void Compose(int maxElementsCount, int maxPinsCount)
        {
            blocks = new List<List<int>>();
            Steps = new List<List<string>>();
            List<int> placedElements = new List<int> { fictitiousElement };

            while (placedElements.Count < elementsCount)
            {
                Steps.Add(new List<string>());

                Steps[blocks.Count].Add(string.Format("Компоновка {0}-го блока:", blocks.Count + 1));

                List<int> nextBlock = GetNextBlock(maxElementsCount, maxPinsCount, placedElements);
                blocks.Add(nextBlock);

                Steps[blocks.Count - 1].Add("Сформированный блок:");
                Steps[blocks.Count - 1].Add(GetBlockString(nextBlock, blocks.Count));
            }
        }

        private List<int> GetNextBlock(int maxElementsCount, int maxPinsCount, List<int> placedElements)
        {
            List<int> block = new List<int>();
            block.Add(GetBaseElement(placedElements));

            Steps[blocks.Count].Add(string.Empty);

            bool addElement = true;
            while ((block.Count < maxElementsCount) && (placedElements.Count < elementsCount) && addElement)
            {
                int addedElement = GetNextElement(block, placedElements, maxPinsCount, ref addElement);
                if (addElement)
                {
                    placedElements.Add(addedElement);
                    block.Add(addedElement);
                }

                Steps[blocks.Count].Add(string.Empty);
            }

            return block;
        }

        private int GetNextElement(List<int> block, List<int> placedElements, int maxPinsCount, ref bool addElement)
        {
            Steps[blocks.Count].Add(GetUnplacedElementsString(placedElements));
            Steps[blocks.Count].Add("Добавляем следующий элемент:");

            int[] L2 = GetL2Ratings(block, placedElements);

            List<int> unplacedElements = GetUnplacedElements(placedElements);
            List<int> suitableElements = L2.Select((s, i) => new { i, s })
                .Where(n => (n.s <= maxPinsCount) && (unplacedElements.Contains(n.i))).Select(n => n.i).ToList();

            int addedElement = -1;
            if (suitableElements.Count == 0)
            {
                Steps[blocks.Count].Add("Нет подходящих элементов");

                addElement = false;
            }
            else if (suitableElements.Count > 1)
            {
                Steps[blocks.Count].Add(GetElementsString(suitableElements, "Допустимые элементы: "));

                int[] L3 = GetL3Ratings(block, suitableElements);

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

                Steps[blocks.Count].Add(string.Format("Добавляем элемент e{0}", addedElement));
            }
            else
            {
                Steps[blocks.Count].Add(string.Format("Добавляем единственный подходящий элемент e({0})", suitableElements[0]));

                addedElement = suitableElements.First();
            }

            return addedElement;
        }

        private int[] GetL3Ratings(List<int> block, List<int> suitableElements)
        {
            int[] ratings = new int[elementsCount];
            for (int i = 0; i < suitableElements.Count; i++)
                ratings[suitableElements[i]] = GetL3Rating(suitableElements[i], block);

            Steps[blocks.Count].AddRange(GetRatingsStrings(ratings, "L3", suitableElements));

            return ratings;
        }

        private int GetL3Rating(int element, List<int> block)
        {
            List<int> elementChains = elementsByChain.Select((s, i) => new { i, s })
                .Where(t => t.s.Contains(element)).Select(t => t.i).ToList();

            List<int> blockElements = block.Select(n => n).ToList();
            int rating = 0;
            foreach (int chainIndex in elementChains)
            {
                List<int> chainElements = elementsByChain[chainIndex];

                List<int> intersectElements = chainElements.Intersect(blockElements).ToList();
                List<int> exceptElements = chainElements.Except(blockElements).ToList();
                if ((intersectElements.Count > 0) && (exceptElements.Count > 0))
                {
                    rating++;
                }
            }

            return rating;
        }

        private int[] GetL2Ratings(List<int> block, List<int> placedElements)
        {
            List<int> unplacedElements = GetUnplacedElements(placedElements);
            int[] ratings = new int[elementsCount];
            for (int i = 0; i < unplacedElements.Count; i++)
                ratings[unplacedElements[i]] = GetL2Rating(unplacedElements[i], block);

            Steps[blocks.Count].AddRange(GetRatingsStrings(ratings, "L2", unplacedElements));

            return ratings;
        }

        private int GetL2Rating(int element, List<int> block)
        {
            List<int> elementChains = elementsByChain.Select((s, i) => new { i, s })
                .Where(t => t.s.Contains(element)).Select(t => t.i).ToList();
            for (int i = 0; i < block.Count; i++)
            {
                List<int> blockElementChains = elementsByChain.Select((s, i) => new { i, s })
                    .Where(t => t.s.Contains(block[i])).Select(t => t.i).ToList();
                elementChains = elementChains.Union(blockElementChains).ToList();
            }

            List<int> currentElements = block.Select(n => n).ToList();
            currentElements.Add(element);
            int rating = 0;
            foreach (int chainIndex in elementChains)
            {
                List<int> chainElements = elementsByChain[chainIndex];

                List<int> exceptElements = chainElements.Except(currentElements).ToList();
                if (exceptElements.Count > 0)
                {
                    rating++;
                }
            }

            return rating;
        }

        private int GetBaseElement(List<int> placedElements)
        {
            Steps[blocks.Count].Add(GetUnplacedElementsString(placedElements));
            Steps[blocks.Count].Add("Выбор базового элемента:");

            int[] L1 = GetL1Ratings(placedElements);

            int baseElement = L1.Select((s, i) => new { i, s })
                .Where(n => n.s == L1.Max()).Select(n => n.i).Last();

            Steps[blocks.Count].Add(string.Format("Добавляем элемент e{0}\n", baseElement));

            placedElements.Add(baseElement);
            return baseElement;
        }

        private int[] GetL1Ratings(List<int> placedElements)
        {
            List<int> unplacedElements = GetUnplacedElements(placedElements);
            int[] ratings = new int[elementsCount];

            for (int i = 0; i < unplacedElements.Count; i++)
                ratings[unplacedElements[i]] = GetL1Rating(unplacedElements[i]);

            Steps[blocks.Count].AddRange(GetRatingsStrings(ratings, "L1", unplacedElements));

            return ratings;
        }

        private int GetL1Rating(int element)
        {
            List<int> elementChains = elementsByChain.Select((s, i) => new { i, s })
                .Where(t => t.s.Contains(element)).Select(t => t.i).ToList();

            int rating = 0;
            foreach (int chainIndex in elementChains)
            {
                List<int> chainElements = elementsByChain[chainIndex];
                if (chainElements.Count > 1)
                {
                    if (chainElements.Contains(element))
                    {
                        rating++;
                    }
                }
            }

            return rating;
        }

        private List<int> GetUnplacedElements(List<int> placedElements)
        {
            List<int> elements = Enumerable.Range(0, elementsCount).ToList()
              .Except(placedElements).ToList();

            return elements;
        }

        public string[] GetComposedBlocksStrings()
        {
            List<string> composedBlocks = new List<string>();
            for (int i = 0; i < blocks.Count; i++)
                composedBlocks.Add(GetBlockString(blocks[i], i + 1));

            return composedBlocks.ToArray();
        }

        private static string GetBlockString(List<int> block, int number)
        {
            const string blockPattern = "B{0} = {{{1}}}";
            const string elementPattern = "e{0}";
            const char separator = ',';

            StringBuilder blockSB = new StringBuilder(string.Format(elementPattern, block[0]));
            for (int i = 1; i < block.Count; i++)
            {
                blockSB.Append(separator);
                blockSB.Append(string.Format(elementPattern, block[i]));
            }


            return string.Format(blockPattern, number, blockSB);
        }

        public string[] GetElementsByChainStrings()
        {
            const string chainElementsPattern = "E(v{0}) = {{{1}}}";
            const string elementPattern = "e{0}";
            const char separator = ',';

            List<string> elementsByChainStrings = new List<string>();
            for (int i = 0; i < elementsByChain.Count; i++)
            {
                StringBuilder chainElements = new StringBuilder(string.Format(elementPattern, elementsByChain[i][0]));
                for (int j = 1; j < elementsByChain[i].Count; j++)
                {
                    chainElements.Append(separator);
                    chainElements.Append(string.Format(elementPattern, elementsByChain[i][j]));
                }

                elementsByChainStrings.Add(string.Format(chainElementsPattern, i + 1, chainElements));
            }

            return elementsByChainStrings.ToArray();
        }

        public string[] GetChainsByElementStrings()
        {
            const string elementChainsPattern = "V(e{0}) = {{{1}}}";
            const string chainPattern = "v{0}";
            const char separator = ',';

            List<string> chainsByElementStrings = new List<string>();
            for (int i = 0; i < elementsCount; i++)
            {
                List<int> elementChains = elementsByChain.Select((s, i) => new { i, s })
                    .Where(t => t.s.Contains(i)).Select(t => t.i).ToList();
                StringBuilder chains = new StringBuilder(string.Format(chainPattern, elementChains[0] + 1));
                for (int j = 1; j < elementChains.Count; j++)
                {
                    chains.Append(separator);
                    chains.Append(string.Format(chainPattern, elementChains[j] + 1));
                }

                chainsByElementStrings.Add(string.Format(elementChainsPattern, i, chains.ToString()));
            }

            return chainsByElementStrings.ToArray();
        }

        private static string[] GetRatingsStrings(int[] ratings, string ratingName, List<int> elements)
        {
            const string ratingPattern = "{0}(e{1}) = {2}";

            List<string> ratingsStrings = new List<string>();
            for (int i = 0; i < elements.Count; i++)
                ratingsStrings.Add(string.Format(ratingPattern, ratingName, elements[i], ratings[elements[i]]));

            return ratingsStrings.ToArray();
        }

        private string GetUnplacedElementsString(List<int> placedElements)
        {
            const string unplacedElementsMessage = "Неразмещенные элементы: ";

            List<int> elements = GetUnplacedElements(placedElements);
            return GetElementsString(elements, unplacedElementsMessage);
        }

        private static string GetElementsString(List<int> elements, string message = null)
        {
            const string elementPattern = "e{0}";
            const char separator = ',';

            StringBuilder elementsSB = new StringBuilder();
            if (message != null)
                elementsSB.Append(message);

            elementsSB.Append(string.Format(elementPattern, elements[0]));
            for (int i = 1; i < elements.Count; i++)
            {
                elementsSB.Append(separator);
                elementsSB.Append(string.Format(elementPattern, elements[i]));
            }

            return elementsSB.ToString();
        }
    }
}
