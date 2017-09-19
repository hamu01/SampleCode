using System;
using System.Diagnostics;

using Basic;

namespace GraphResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleClient sampleClient = new SampleClient();
            //sampleClient.RunSearch("tinyG.txt");
            //sampleClient.RunPath("sample.txt");
            //sampleClient.RunCC("tinyG.txt");
            //sampleClient.RunCycle("cycle.txt");
            //sampleClient.RunTwoColor("cycle.txt");
            sampleClient.RunSymbolGraph("routes.txt", " ");

            //PerfClient perfClient = new PerfClient();
            //perfClient.Run("mediumG.txt");

            Console.ReadKey();
        }
    }

    public class SampleClient
    {
        public void RunSearch(string path)
        {
            Graph G = Factory.GetGraph(path);
            //for (int s = 0; s < G.V(); s++)
            {
                int s = 2;
                Console.Write("{0}: ", s);
                Search search = Factory.GetSearch(G, s);
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

        public void RunPath(string path)
        {
            Graph G = Factory.GetGraph(path);
            int s = 0;
            Paths search = Factory.GetPaths(G, s);
            for (int v = 0; v < G.V(); v++)
            {
                Console.Write(s + " to " + v + ": ");

                if (search.HasPathTo(v))
                {
                    foreach (int x in search.PathTo(v))
                    {
                        if (x == s)
                        {
                            Console.Write(x);
                        }
                        else
                        {
                            Console.Write("-" + x);
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public void RunCC(string path)
        {
            Graph G = Factory.GetGraph(path);
            CC cc = Factory.GetCC(G);
            int M = cc.Count();
            Console.WriteLine(M + " components");
            Bag<int>[] components = new Bag<int>[M];
            for (int i = 0; i < M; i++)
            {
                components[i] = new Bag<int>();
            }

            for (int v = 0; v < G.V(); v++)
            {
                components[cc.Id(v)].Add(v);
            }

            for (int i = 0; i < M; i++)
            {
                foreach (int v in components[i])
                {
                    Console.Write(v + " ");
                }
                Console.WriteLine();
            }
        }

        public void RunCycle(string path)
        {
            Graph G = Factory.GetGraph(path);
            Cycle c = Factory.GetCycle(G);
            Console.WriteLine(c.HasCycle());
        }

        public void RunTwoColor(string path)
        {
            Graph G = Factory.GetGraph(path);
            TwoColor c = Factory.GetTwoColor(G);
            Console.WriteLine(c.IsBipartite());
        }

        public void RunSymbolGraph(string filename, string delim)
        {
            SymbolGraph sg = Factory.GetSymbolGraph(filename, delim);
            Graph G = sg.G();
            string source;
            while (!string.IsNullOrEmpty(source = Console.ReadLine()))
            {
                foreach (int w in G.Adj(sg.Index(source)))
                {
                    Console.WriteLine(" " + sg.Name(w));
                }
            }
        }
    }

    public class PerfClient
    {
        public void Run(string path)
        {
            Graph G = Factory.GetGraph(path);
            Stopwatch watch = Stopwatch.StartNew();
            for (int s = 0; s < G.V(); s++)
            {
                //Console.Write("{0}: ", s);
                Search search = Factory.GetSearch(G, s);
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

    public class Factory
    {
        public static Graph GetGraph(string path)
        {
            Graph G;
            //G = new AdjacencyMatricGraph(path);
            //G = new EdgeArrayGraph(path);
            G = new AdjacencyListGraph(path);
            return G;
        }

        public static Search GetSearch(Graph G, int s)
        {
            Search search;
            //search = new NormalSearch(G, s);
            search = new DepthFirstSearch(G, s);
            return search;
        }

        public static Paths GetPaths(Graph G, int s)
        {
            Paths p;
            //p = new DepthFirstPaths(G, s);
            p = new BreadthFirstPaths(G, s);
            return p;
        }

        public static CC GetCC(Graph G)
        {
            CC c;
            c = new DepthFirstCC(G);
            //c = new BreadthFirstCC(G);
            return c;
        }

        public static Cycle GetCycle(Graph G)
        {
            Cycle c;
            c = new DepthFirstCycle(G);
            return c;
        }

        public static TwoColor GetTwoColor(Graph G)
        {
            TwoColor t;
            t = new DepthFirstTwoColor(G);
            return t;
        }

        public static SymbolGraph GetSymbolGraph(string filename, string delim)
        {
            SymbolGraph sg = null;
            return sg;
        }
    }
}