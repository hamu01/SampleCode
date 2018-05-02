using System;

namespace Graph
{
    public class BipartiteSample
    {
        public void Run()
        {
            SimpleGraph g = GraphFactory.BuildSimpleGraph();
            Bipartite bipartite = new Bipartite();
            bool isBipartite = bipartite.IsBipartite(g);
            Console.WriteLine(isBipartite);
        }
    }

    public class Bipartite
    {
        public bool IsBipartite(SimpleGraph g)
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

        private bool Dfs(SimpleGraph g, int v, bool[] marked, bool[] color)
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