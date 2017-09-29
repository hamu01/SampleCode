using System.Collections.Generic;

using Multiway;

namespace GraphResearch
{
    public abstract class MST
    {
        public MST(EdgeWeightedGraph G)
        {

        }

        public abstract IEnumerable<Edge> Edges();

        public abstract double Weight();
    }

    public class LazyPrimMST : MST
    {
        private bool[] _marked;

        private Queue<Edge> _mst;

        private MinPQ<Edge> _pq;

        public LazyPrimMST(EdgeWeightedGraph G)
            : base(G)
        {
            _marked = new bool[G.V()];
            _pq = new MinPQ<Edge>(G.E());
            Visit(G, 0);
            while (!_pq.IsEmpty())
            {
                Edge e = _pq.RemoveMin();
                var v = e.Either();
                var w = e.Other(v);
                if (_marked[v] && _marked[w])
                {
                    continue;
                }
                else if (_marked[v])
                {

                }
                else if (_marked[w])
                {

                }
            }
        }

        public override IEnumerable<Edge> Edges()
        {
            throw new System.NotImplementedException();
        }

        public override double Weight()
        {
            throw new System.NotImplementedException();
        }

        private void Visit(EdgeWeightedGraph G, int v)
        {
            _marked[v] = true;
            var adj = G.Adj(v);
            foreach (var e in adj)
            {
                
            }
        }
    }
}