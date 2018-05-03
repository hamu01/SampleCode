using System;
using System.Collections.Generic;

namespace Graph
{
    public class Cycle
    {
        private Graph _g;
        private bool[] _marked;

        public Cycle(Graph g)
        {
            _g = g;
            _marked = new bool[g.Vertexes.Count];
            foreach (int v in g.Vertexes)
            {
                if (!_marked[v])
                {
                    _marked[v] = true;
                    Dfs(v);
                }
            }
        }

        private void Dfs(int v)
        {
            foreach (int w in _g.Adj(v))
            {
                if (!_marked[w])
                {
                    _marked[w] = true;
                    Dfs(w);
                }
            }
        }

        public bool HasCycle()
        {
            throw new NotImplementedException();
        }

        public Stack<int> GetCycle()
        {
            throw new NotImplementedException();
        }
    }
}