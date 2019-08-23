using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = 6;
            var edges = GetEdges(v, "normal");

            // ExistTest(v, edges);
            // TransposeTest(v, edges);
            // DeduplicateTest(v);
            // SquareTest(v, edges);
            // UniversalSinkTest(v);
            // BfsTest(v, edges);
            DfsTest(v, edges);
        }

        private static void BfsTest(int v, Tuple<int, int>[] edges)
        {
            int s = 0;
            int t = 5;

            var g1 = GetAdjacencyListDirectGraph(v, edges);
            var bfs = g1.Bfs(s);
            Console.WriteLine($"bfs from {s}: {string.Join(",", bfs)}");
            var path = g1.BfsPath(s, t);
            Console.WriteLine($"bfs path from {s} to {t}: {string.Join(",", path)}");

            var g2 = GetAdjacencyMatrixDirectGraph(v, edges);
            bfs = g2.Bfs(s);
            Console.WriteLine($"bfs from {s}: {string.Join(",", bfs)}");
            path = g2.BfsPath(s, t);
            Console.WriteLine($"bfs path from {s} to {t}: {string.Join(",", path)}");

            var g3 = GetAdjacencyMatrixDirectGraph(v, edges);
            bfs = g3.Bfs(s);
            Console.WriteLine($"bfs from {s}: {string.Join(",", bfs)}");
            path = g3.BfsPath(s, t);
            Console.WriteLine($"bfs path from {s} to {t}: {string.Join(",", path)}");
        }

        private static void DfsTest(int v, Tuple<int, int>[] edges)
        {
            var g1 = GetAdjacencyListDirectGraph(v, edges);
            var dfs = g1.Dfs();
            Console.WriteLine($"dfs: {string.Join(",", dfs)}");

            var g2 = GetAdjacencyMatrixDirectGraph(v, edges);
            dfs = g2.Dfs();
            Console.WriteLine($"dfs: {string.Join(",", dfs)}");

            var g3 = GetAdjacencyMatrixDirectGraph(v, edges);
            dfs = g3.Dfs();
            Console.WriteLine($"dfs: {string.Join(",", dfs)}");
        }

        private static void ExistTest(int v, Tuple<int, int>[] edges)
        {
            int s = 2, t = 5;

            var g1 = GetAdjacencyListDirectGraph(v, edges);
            bool exist = g1.Exist1(s, t);
            Console.WriteLine($"Exist edge from {s} to {t} : {exist}");

            var g2 = GetAdjacencyMatrixDirectGraph(v, edges);
            exist = g2.Exist1(s, t);
            Console.WriteLine($"Exist edge from {s} to {t} : {exist}");

            var g3 = GetAdjacencyHashsetDirectGraph(v, edges);
            exist = g3.Exist1(s, t);
            Console.WriteLine($"Exist edge from {s} to {t} : {exist}");
        }

        private static void TransposeTest(int v, Tuple<int, int>[] edges)
        {
            var g1 = GetAdjacencyListDirectGraph(v, edges);
            Console.WriteLine(g1.Transpose1().ToString());

            var g2 = GetAdjacencyMatrixDirectGraph(v, edges);
            Console.WriteLine(g2.Transpose1().ToString());

            var g3 = GetAdjacencyHashsetDirectGraph(v, edges);
            Console.WriteLine(g3.Transpose().ToString());
        }

        private static void DeduplicateTest(int v)
        {
            var edges = GetEdges(v, "duplicate");

            var g1 = GetAdjacencyListDirectGraph(v, edges);
            Console.WriteLine(g1.Deduplicate1().ToString());

            var g2 = GetAdjacencyMatrixDirectGraph(v, edges);
            DuplicateGraph(g2);
            Console.WriteLine(g2.ToString());
            Console.WriteLine(g2.Deduplicate().ToString());

            var g3 = GetAdjacencyHashsetDirectGraph(v, edges);
            DuplicateGraph(g3);
            Console.WriteLine(g3.ToString());
            Console.WriteLine(g3.Deduplicate().ToString());
        }

        private static void DuplicateGraph(GraphBase g)
        {
            for (int i = 0; i < g.V; i++)
            {
                g.AddEdge(i, i);
                foreach (var v in g.Adj(i))
                {
                    g.AddEdge(i, v);
                }
            }
        }

        private static void SquareTest(int v, Tuple<int, int>[] edges)
        {
            var g1 = GetAdjacencyListDirectGraph(v, edges);
            Console.WriteLine(g1.Square().ToString());

            var g2 = GetAdjacencyMatrixDirectGraph(v, edges);
            Console.WriteLine(g2.Square().ToString());

            var g3 = GetAdjacencyHashsetDirectGraph(v, edges);
            Console.WriteLine(g3.Square().ToString());
        }

        private static void UniversalSinkTest(int v)
        {
            var edges = GetEdges(v, "universal");

            var g1 = GetAdjacencyListDirectGraph(v, edges);
            Console.WriteLine(string.Join(",", g1.UniversalSink()));

            var g2 = GetAdjacencyMatrixDirectGraph(v, edges);
            Console.WriteLine(string.Join(",", g2.UniversalSink()));

            var g3 = GetAdjacencyHashsetDirectGraph(v, edges);
            Console.WriteLine(string.Join(",", g3.UniversalSink()));
        }

        private static AdjacencyMatrixDirectGraph GetAdjacencyMatrixDirectGraph(int v, Tuple<int, int>[] edges)
        {
            AdjacencyMatrixDirectGraph g = new AdjacencyMatrixDirectGraph(v);
            foreach (var edge in edges)
            {
                g.AddEdge(edge.Item1, edge.Item2);
            }

            Console.WriteLine("Adjacency Matrix Direct Graph: ");
            Console.WriteLine(g.ToString());

            return g;
        }

        private static AdjacencyHashsetDirectGraph GetAdjacencyHashsetDirectGraph(int v, Tuple<int, int>[] edges)
        {
            AdjacencyHashsetDirectGraph g = new AdjacencyHashsetDirectGraph(v);
            foreach (var edge in edges)
            {
                g.AddEdge(edge.Item1, edge.Item2);
            }

            Console.WriteLine("Adjacency Hashset Direct Graph: ");
            Console.WriteLine(g.ToString());

            return g;
        }

        private static AdjacencyListDirectGraph GetAdjacencyListDirectGraph(int v, Tuple<int, int>[] edges)
        {
            AdjacencyListDirectGraph g = new AdjacencyListDirectGraph(v);
            foreach (var edge in edges)
            {
                g.AddEdge(edge.Item1, edge.Item2);
            }

            Console.WriteLine("Adjacency List Direct Graph: ");
            Console.WriteLine(g.ToString());
            return g;
        }

        private static Tuple<int, int>[] GetEdges(int v, string type)
        {
            List<Tuple<int, int>> edges = new List<Tuple<int, int>>();
            edges.Add(new Tuple<int, int>(0, 1));
            edges.Add(new Tuple<int, int>(0, 3));
            edges.Add(new Tuple<int, int>(1, 4));
            edges.Add(new Tuple<int, int>(3, 2));
            edges.Add(new Tuple<int, int>(4, 3));
            edges.Add(new Tuple<int, int>(2, 5));

            if (type == "duplicate")
            {
                for (int i = 0; i < v; i++)
                {
                    edges.Add(new Tuple<int, int>(i, i));
                }

                edges.Add(new Tuple<int, int>(0, 1));
                edges.Add(new Tuple<int, int>(0, 3));
                edges.Add(new Tuple<int, int>(1, 4));
                edges.Add(new Tuple<int, int>(3, 2));
                edges.Add(new Tuple<int, int>(4, 3));
                edges.Add(new Tuple<int, int>(2, 5));
            }
            else if (type == "universal")
            {
                edges.Add(new Tuple<int, int>(0, 5));
                edges.Add(new Tuple<int, int>(1, 5));
                edges.Add(new Tuple<int, int>(3, 5));
                edges.Add(new Tuple<int, int>(4, 5));
            }

            return edges.ToArray();
        }
    }
}