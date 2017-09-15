using System.Linq;

namespace GraphResearch
{
    public class Search
    {
        private Graph _G;

        private int _s;

        public Search(Graph G, int s)
        {
            _G = G;
            _s = s;
        }

        public bool Marked(int v)
        {
            bool adjacency = _G.Adj(_s).Any(x => x == v);
            return adjacency;
        }

        public int Count()
        {
            return _G.Adj(_s).Count();
        }
    }
}