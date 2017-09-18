using System.Collections.Generic;

using Basic;

namespace GraphResearch
{
    public class AdjacencyListGraph : Graph
    {
        private Bag<int>[] _adjacencies;

        public AdjacencyListGraph(int V)
            : base(V)
        {
        }

        public AdjacencyListGraph(string path)
            : base(path)
        {
            int c = 0;
            foreach (var adjacency in _adjacencies)
            {
                c += adjacency.Size();
            }
        }

        public override void AddEdge(int v, int w)
        {
            base.AddEdge(v, w);
            _adjacencies[v].Add(w);
            _adjacencies[w].Add(v);
        }

        public override IEnumerable<int> Adj(int v)
        {
            List<int> adjacencies = new List<int>();
            adjacencies.Add(v);
            adjacencies.AddRange(_adjacencies[v]);
            return adjacencies;
        }

        protected override void BuildGraph(int v)
        {
            _adjacencies = new Bag<int>[v];
            for (int i = 0; i < v; i++)
            {
                _adjacencies[i] = new Bag<int>();
            }
        }
    }
}