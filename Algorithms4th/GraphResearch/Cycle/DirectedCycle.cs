using System.Collections.Generic;

namespace GraphResearch
{
    public class DirectedCycle_Simple
    {
        public bool[] _marked;

        private int[] _edgeTo;

        private Stack<int> _cycle;

        public DirectedCycle_Simple(Digraph G)
        {
            _marked = new bool[G.V()];
            _edgeTo = new int[G.V()];
            for (int v = 0; v < G.V(); v++)
            {
                if (!_marked[v] && !HasCycle())
                {
                    Dfs(G, v, v);
                }
            }
        }

        public bool HasCycle()
        {
            return _cycle != null;
        }

        public IEnumerable<int> Cycle()
        {
            return _cycle;
        }

        private void Dfs(Digraph G, int v, int w)
        {
            _marked[v] = true;
            foreach (var i in G.Adj(v))
            {
                if (HasCycle())
                {
                    return;
                }
                if (!_marked[i])
                {
                    _edgeTo[i] = v;
                    Dfs(G, i, v);
                }
                else if (i != w)
                {
                    _cycle = new Stack<int>();
                    _cycle.Push(i);
                    for (int j = v; j != i; j = _edgeTo[j])
                    {
                        _cycle.Push(j);
                    }
                    _cycle.Push(i);
                }
            }
        }
    }

    public class DirectedCycle
    {
        private bool[] _marked;
        
        private int[] _edgeTo;

        private Stack<int> _cycle;

        private bool[] _onStack;

        public DirectedCycle(Digraph G)
        {
            _marked = new bool[G.V()];
            _onStack = new bool[G.V()];
            _edgeTo = new int[G.V()];
            for (int v = 0; v < G.V(); v++)
            {
                if (!_marked[v] && !HasCycle())
                {
                    Dfs(G, v);
                }
            }
        }

        public bool HasCycle()
        {
            return _cycle != null;
        }

        public IEnumerable<int> Cycle()
        {
            return _cycle;
        }

        private void Dfs(Digraph G, int v)
        {
            _onStack[v] = true;
            _marked[v] = true;
            foreach (var w in G.Adj(v))
            {
                if (HasCycle())
                {
                    return;
                }
                else if (!_marked[w])
                {
                    _edgeTo[w] = v;
                    Dfs(G, w);
                }
                else if (_onStack[w])
                {
                    _cycle = new Stack<int>();
                    for (int x = v; x != w; x = _edgeTo[x])
                    {
                        _cycle.Push(x);
                    }
                    _cycle.Push(w);
                    _cycle.Push(v);
                }
            }
            _onStack[v] = false;
        }
    }
}