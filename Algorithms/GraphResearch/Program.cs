using System;
using System.Diagnostics;

namespace GraphResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph G = GetGraph("tinyG.txt");
            //Graph G = GetGraph("mediumG.txt");

            SampleClient sampleClient = new SampleClient();
            sampleClient.Run(G);

            //PerfClient perfClient = new PerfClient();
            //perfClient.Run(G);

            Console.ReadKey();
        }

        private static Graph GetGraph(string path)
        {
            Graph G;
            //G = new AdjacencyMatricGraph(path);
            //G = new EdgeArrayGraph(path);
            G = new AdjacencyListGraph(path);
            return G;
        }
    }

    public class SampleClient
    {
        public void Run(Graph G)
        {
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
        }
    }

    public class PerfClient
    {
        public void Run(Graph G)
        {
            Stopwatch watch = Stopwatch.StartNew();
            for (int s = 0; s < G.V(); s++)
            {
                //Console.Write("{0}: ", s);
                Search search = new Search(G, s);
                for (int v = 0; v < G.V(); v++)
                {
                    if (search.Marked(v))
                    {
                        //Console.Write("{0} ", v);
                    }
                }
                //Console.WriteLine();

                if (search.Count() != G.V())
                {
                    //Console.Write("Not ");
                }
                //Console.WriteLine("Connected");
            }
            Console.WriteLine(watch.Elapsed);
        }
    }
}