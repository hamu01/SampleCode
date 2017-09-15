using System;
using System.Collections;

namespace GraphResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph G = new AdjacencyMatricGraph("tinyG.txt");
            for (int s = 0; s < G.V(); s++)
            {
                Console.Write("{0}: ", s);
                Search search = new Search(G, s);
                for (int v = 0; v < G.V(); v++)
                {
                    if (search.Marked(v))
                    {
                        Console.Write("{0} ", v);
                    }
                }
                Console.WriteLine();

                if (search.Count() != G.V())
                {
                    Console.Write("Not ");
                }
                Console.WriteLine("Connected");
            }
           
            Console.ReadKey();
        }
    }
}