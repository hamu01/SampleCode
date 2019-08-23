using System.Collections.Generic;

namespace Graph
{
    public abstract class DirectGraphBase : GraphBase
    {
        public DirectGraphBase(int v) : base(v)
        {
        }

        public DirectGraphBase Transpose()
        {
            DirectGraphBase g = new AdjacencyListDirectGraph(V);
            for (int i = 0; i < V; i++)
            {
                ICollection<int> adj = Adj(i);
                foreach (var j in adj)
                {
                    g.AddEdge(j, i);
                }
            }
            return g;
        }
    
        public List<int> UniversalSink()
        {
            List<int> universalSink = new List<int>();

            for (int i = 0; i < V; i++)
            {
                if (Adj(i).Count == 0)
                {
                    int indegree = 0;
                    for (int j = 0; j < V; j++)
                    {
                        if (Adj(j).Contains(i))
                        {
                            indegree++;
                        }
                    }
                    if (indegree == V - 1)
                    {
                        universalSink.Add(i);
                    }
                }
            }

            return universalSink;
        }
    }
}