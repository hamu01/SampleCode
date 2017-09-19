namespace GraphResearch
{
    public abstract class SymbolGraph
    {
        public SymbolGraph(string filename, string delim)
        {
            
        }

        public abstract bool Contains(string key);

        public abstract int Index(string key);

        public abstract string Name(int v);

        public abstract Graph G();
    }
}