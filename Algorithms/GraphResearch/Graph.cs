using System.Collections.Generic;

namespace GraphResearch
{
    public abstract class Graph
    {
        public Graph(int V)
        {

        }

        public abstract int V();

        public abstract int E();

        public abstract void AddEdge(int v, int w);

        public abstract IEnumerable<int> Adj(int v);

        public static int Degree(Graph G, int v)
        {
            int degree = 0;
            foreach (int w in G.Adj(v))
            {
                degree++;
            }
            return degree;
        }

        public static int MaxDegree(Graph G)
        {
            int max = 0;
            for (int v = 0; v < G.V(); v++)
            {
                if (Degree(G, v) > max)
                {
                    max = Degree(G, v);
                }
            }

            return max;
        }

        public static int NumberOfSelfLoops(Graph G)
        {
            int count = 0;
            for (int v = 0; v < G.V(); v++)
            {
                foreach (int w in G.Adj(v))
                {
                    if (v == w) count++;
                }
            }

            return count / 2;
        }

        public override string ToString()
        {
            string s = V() + " vertices, " + E() + " edges\n";
            for (int v = 0; v < V(); v++)
            {
                s += v + ": ";
                foreach (int w in this.Adj(v))
                    s += w + " ";
                s += "\n";
            }
            return s;
        }
    }
}