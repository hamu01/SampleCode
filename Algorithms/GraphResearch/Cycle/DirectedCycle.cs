﻿using System.Collections.Generic;

namespace GraphResearch
{
    public class DirectedCycle
    {
        public bool[] _marked;

        private bool _hasCycle;

        private int[] _edgeTo;

        private Stack<int> _cycle;

        public DirectedCycle(Digraph G)
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
            return _hasCycle;
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
                else if(i != w)
                {
                    _hasCycle = true;
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
}