using System;
using System.Collections.Generic;

namespace Graph
{
    public class BipartiteSample
    {
        public void Run()
        {
            Graph g = BuildGraph();
            Bipartite bipartite = new Bipartite();
            bool isBipartite = bipartite.IsBipartite(g);
            Console.WriteLine(isBipartite);
        }

        public Graph BuildGraph()
        {
            List<int> vertexes = new List<int>() { 0, 1, 2, 3, 4, 5 };
            Graph g = new Graph(vertexes);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(1, 4);
            g.AddEdge(2, 3);
            g.AddEdge(2, 5);
            g.AddEdge(3, 4);
            return g;
        }
    }

    public class Bipartite
    {
        public bool IsBipartite(Graph g)
        {
            bool[] marked = new bool[g.Vertexes.Count];
            bool[] color = new bool[g.Vertexes.Count];
            foreach (var v in g.Vertexes)
            {
                if (!marked[v])
                {
                    bool isBipartite = Dfs(g, v, marked, color);
                    if (!isBipartite)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool Dfs(Graph g, int v, bool[] marked, bool[] color)
        {
            marked[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (!marked[w])
                {
                    color[w] = !color[v];
                    bool isBipartite = Dfs(g, w, marked, color);
                    if (!isBipartite)
                    {
                        return false;
                    }
                }
                else if (color[w] == color[v])
                {
                    return false;
                }
            }
            return true;
        }
    }
}