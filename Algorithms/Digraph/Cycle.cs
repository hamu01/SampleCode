using System;
using System.Collections.Generic;

namespace Digraph
{
    public class CycleSample
    {
        public void Run()
        {
            Digraph g = BuildGraph(true);
            Cycle cycle = new Cycle(g);
            bool hasCycle = cycle.HasCycle();
            if (hasCycle)
            {
                string cycleStr = string.Join(",", cycle.GetCycle());
                Console.WriteLine($"Has cycle, the cycle is : {cycleStr}");
            }
            else
            {
                Console.WriteLine("Hasn't cycle");
            }

            g = BuildGraph(false);
            cycle = new Cycle(g);
            hasCycle = cycle.HasCycle();
            if (hasCycle)
            {
                string cycleStr = string.Join(",", cycle.GetCycle());
                Console.WriteLine($"Has cycle, the cycle is : {cycleStr}");
            }
            else
            {
                Console.WriteLine("Hasn't cycle");
            }
        }

        private Digraph BuildGraph(bool hasCycle)
        {
            List<int> vertexes = new List<int>() { 0, 1, 2, 3 };
            Digraph g = new Digraph(vertexes);
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);
            if (hasCycle)
            {
                g.AddEdge(3, 0);
            }
            else
            {
                g.AddEdge(0, 3);
            }
            return g;
        }
    }

    public class Cycle
    {
        private Digraph _g;
        private bool[] _marked;
        private bool[] _onStack;
        private int[] _pathTo;
        private bool _hasCycle;
        private Stack<int> _cycle;

        public Cycle(Digraph g)
        {
            _g = g;
            int n = g.Vertexes.Count;
            _marked = new bool[n];
            _onStack = new bool[n];
            _pathTo = new int[n];
            foreach (var v in _g.Vertexes)
            {
                if (!_marked[v] && !_hasCycle)
                {
                    Dfs(v);
                }
            }
        }

        private void Dfs(int v)
        {
            _marked[v] = true;
            _onStack[v] = true;
            foreach (var w in _g.Adj(v))
            {
                if (_hasCycle)
                {
                    return;
                }
                if (!_marked[w])
                {
                    _pathTo[w] = v;
                    Dfs(w);
                }
                else if (_onStack[w])
                {
                    _hasCycle = true;
                    _cycle = new Stack<int>();
                    _cycle.Push(w);
                    while (v != w)
                    {
                        _cycle.Push(v);
                        v = _pathTo[v];
                    }
                    _cycle.Push(w);
                }
            }
            _onStack[v] = false;
        }

        public bool HasCycle()
        {
            return _hasCycle;
        }

        public IEnumerable<int> GetCycle()
        {
            return _cycle;
        }
    }
}