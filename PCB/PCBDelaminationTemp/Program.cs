using System;
using System.Collections.Generic;
using PCBDelamination;

namespace PCBDelaminationTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] matrix = new bool[,]
                {
                    { false, false, false, true, true, true, false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, true, false, false, false, false, false, false, false, false, false, false },
                    { false, false, false, true, false, false, false, false, true, true, false, false, false, false, false },
                    { true, false, true, false, true, true, false, false, false, false, false, false, false, false, false },
                    { true, true, false, true, false, false, false, false, true, false, false, false, false, false, false },
                    { true, false, false, true, false, false, false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false, false, false, false, true, false, false },
                    { false, false, false, false, false, false, false, false, false, false, true, true, true, true, false },
                    { false, false, true, false, true, false, false, false, false, true, true, true, true, true, false },
                    { false, false, true, false, false, false, false, false, true, false, true, true, false, false, true },
                    { false, false, false, false, false, false, false, true, true, true, false, true, true, false, true },
                    { false, false, false, false, false, false, false, true, true, true, true, false, false, true, true },
                    { false, false, false, false, false, false, true, true, true, false, true, false, false, true, false },
                    { false, false, false, false, false, false, false, true, true, false, false, true, true, false, false },
                    { false, false, false, false, false, false, false, false, false, true, true, true, false, false, false }
                };

            DelaminationProcessor processor = new DelaminationProcessor(matrix);

            int k = 3;

            List<List<int>> layers = processor.GetLayers(k, out List<List<int>> G, out List<List<int>> S, out List<int> extraS);
            
            for (int i = 0; i <= k; i++)
            {
                System.Console.WriteLine(i + ":");
                
                System.Console.Write("G: ");
                for (int j = 0; j < G[i].Count; j++)
                {
                    System.Console.Write(G[i][j] + 1 + " ");
                }
                System.Console.WriteLine();
                System.Console.Write("S: ");
                for (int j = 0; j < S[i].Count; j++)
                {
                    System.Console.Write(S[i][j] + 1 + " ");
                }
                System.Console.WriteLine();
                System.Console.WriteLine();
            }

            System.Console.Write("S*: ");
            for (int i = 0; i < extraS.Count; i++)
            {
                System.Console.Write(extraS[i] + 1 + " ");
            }
            System.Console.WriteLine();
            Console.WriteLine();
            

            System.Console.WriteLine("Layers:");
            for (int i = 0; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].Count; j++)
                {
                    System.Console.Write(layers[i][j] + 1 + " ");
                }
                System.Console.WriteLine();
            }
        }
    }
}
