using System;
using System.Collections.Generic;
using SequentialLayout;

namespace SequentialLayoutTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            LayoutProcessor processor = new LayoutProcessor(@"C:\Users\capyb\Desktop\Папка\Cash\Сергей Рязанцев\АКиТП\цепи по элементам.txt");


            for (int i = 0; i < processor.ChainsByElements.Count; i++)
            {
                Console.Write("V(e" + i + "): ");
                for (int j = 0; j < processor.ChainsByElements[i].Count; j++)
                {
                    Console.Write("v" + processor.ChainsByElements[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < processor.ElementsByChains.Count; i++)
            {
                Console.Write("E(v" + (i + 1) + "): ");
                for (int j = 0; j < processor.ElementsByChains[i].Count; j++)
                {
                    Console.Write("e" + processor.ElementsByChains[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            List<List<int>> blocks = processor.ArrangeBlocks(out List<List<string>> calculations, 4, 6);
            for (int i = 0; i < blocks.Count; i++)
            {
                Console.Write("Блок " + (i + 1) + ": { ");
                for (int j = 0; j < blocks[i].Count; j++)
                {
                    Console.Write(blocks[i][j] + " ");
                }
                Console.WriteLine("}");
            }
            Console.WriteLine();

            for (int i = 0; i < calculations.Count; i++)
            {
                Console.Write("e" + i + ":\t");
                for (int j = 0; j < calculations[i].Count; j++)
                {
                    Console.Write(calculations[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
