namespace GraphResearch
{
    public class DepthFirstCycle : Cycle
    {
        private bool[] _marked;

        private bool _hasCycle;

        public DepthFirstCycle(Graph G)
            : base(G)
        {
            _marked = new bool[G.V()];
            for (int i = 0; i < G.V(); i++)
            {
                if (!_marked[i])
                {
                    Dfs(G, i, i);
                }
            }
        }

        private void Dfs(Graph G, int v, int u)
        {
            _marked[v] = true;
            foreach (int i in G.Adj(v))
            {
                if (!_marked[i])
                {
                    Dfs(G, i, v);
                }
                else if(i != u)
                {
                    //i已经访问过，且不是v的上一个节点
                    //那一定是访问了一圈回到了原点导致的，此时一定是cycle
                    _hasCycle = true;
                }
            }
        }

        public override bool HasCycle()
        {
            return _hasCycle;
        }
    }
}