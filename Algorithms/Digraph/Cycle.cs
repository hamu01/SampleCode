using System;
using System.Collections.Generic;
using System.Linq;

namespace Digraph
{
    public class CycleSample
    {
        public void Run()
        {
            Digraph g = BuildGraph(true);
            Cycle cycle = GetCycle(g);
            bool hasCycle = cycle.HasCycle();
            if (hasCycle)
            {
                var cycles = cycle.GetCycle();
                string cycleStr = "";
                if (cycles != null)
                {
                    cycleStr = string.Join(",", cycles);
                }
                Console.WriteLine($"Has cycle, the cycle is : {cycleStr}");
            }
            else
            {
                Console.WriteLine("Hasn't cycle");
            }

            g = BuildGraph(false);
            cycle = GetCycle(g);
            hasCycle = cycle.HasCycle();
            if (hasCycle)
            {
                var cycles = cycle.GetCycle();
                string cycleStr = "";
                if (cycles != null)
                {
                    cycleStr = string.Join(",", cycles);
                }
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

        private Cycle GetCycle(Digraph g)
        {
            // return new DfsCycle(g);
            return new BfsCycle(g);
        }
    }

    public abstract class Cycle
    {
        public Cycle(Digraph g)
        {

        }

        public abstract bool HasCycle();

        public abstract IEnumerable<int> GetCycle();
    }

    public class DfsCycle : Cycle
    {
        private Digraph _g;
        private bool[] _marked;
        private bool[] _onStack;
        private int[] _pathTo;
        private bool _hasCycle;
        private Stack<int> _cycle;

        public DfsCycle(Digraph g) : base(g)
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

        public override bool HasCycle()
        {
            return _hasCycle;
        }

        public override IEnumerable<int> GetCycle()
        {
            return _cycle;
        }
    }

    public class BfsCycle : Cycle
    {
        Digraph _g;
        private int[] _inDegrees;
        private bool _hasCycle;

        public BfsCycle(Digraph g) : base(g)
        {
            _g = g.Reverse();
            int n = g.Vertexes.Count;
            _inDegrees = new int[n];
            foreach (var v in g.Vertexes)
            {
                _inDegrees[v] = g.Adj(v).Count;
            }
            Queue<int> queue = new Queue<int>();
            int count = 0;
            foreach (var v in _g.Vertexes)
            {
                if (_inDegrees[v] == 0)
                {
                    queue.Enqueue(v);
                    count++;
                }
            }
            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                foreach (var w in _g.Adj(v))
                {
                    if (--_inDegrees[w] == 0)
                    {
                        queue.Enqueue(w);
                        count++;
                    }
                }
            }
            _hasCycle = count != _g.Vertexes.Count;
        }

        private void Bfs(int v, Queue<int> queue)
        {
            foreach (var w in _g.Adj(v))
            {
                if (--_inDegrees[w] == 0)
                {
                    queue.Enqueue(w);
                }
            }
        }

        public override bool HasCycle()
        {
            return _hasCycle;
        }

        public override IEnumerable<int> GetCycle()
        {
            return null;
        }
    }

    public class DfsCycle_Slow : Cycle
    {
        private Digraph _g;
        private bool[] _marked;
        private int[] _pathTo;
        private bool _hasCycle;
        private Stack<int> _cycle;

        public DfsCycle_Slow(Digraph g) : base(g)
        {
            _g = g;
            int n = g.Vertexes.Count;
            _marked = new bool[n];
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
                else
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
            _marked[v] = false;
        }

        public override bool HasCycle()
        {
            return _hasCycle;
        }

        public override IEnumerable<int> GetCycle()
        {
            return _cycle;
        }
    }
}