using System;
using System.Collections.Generic;
using System.Text;

namespace GraphResearch
{
    public abstract class SCC
    {
        public SCC(Digraph G)
        {

        }

        public abstract bool StronglyConnected(int v, int w);

        public abstract int Count();

        public abstract int Id(int v);
    }

    public class KosarajuSCC : SCC
    {
        private bool[] _marked;

        private int[] _id;

        private int _count;

        public KosarajuSCC(Digraph G)
            : base(G)
        {
            _marked = new bool[G.V()];
            _id = new int[G.V()];
            DepthFirstOrder order = new DepthFirstOrder(G.Reverse());
            foreach (var v in order.ReversePost())
            {
                if (!_marked[v])
                {
                    Dfs(G, v);
                    _count++;
                }
            }
        }

        public override bool StronglyConnected(int v, int w)
        {
            return _id[v] == _id[w];
        }

        public override int Count()
        {
            return _count;
        }

        public override int Id(int v)
        {
            return _id[v];
        }

        private void Dfs(Digraph G, int v)
        {
            _marked[v] = true;
            _id[v] = _count;
            foreach (var w in G.Adj(v))
            {
                if (!_marked[w])
                {
                    Dfs(G, w);
                }
            }
        }
    }

    public class TransitiveClosure
    {
        private DirectedDFS[] _dfs;

        public TransitiveClosure(Digraph G)
        {
            _dfs = new DirectedDFS[G.V()];
            for (int i = 0; i < G.V(); i++)
            {
                _dfs[i] = new DirectedDFS(G, i);
            }
        }

        public bool Reachable(int v, int w)
        {
            return _dfs[v].Marked(w);
        }
    }
}