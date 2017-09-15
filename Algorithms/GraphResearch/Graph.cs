using System;
using System.Collections.Generic;
using System.IO;

namespace GraphResearch
{
    public abstract class Graph
    {
        protected int _V;

        protected int _E;

        public Graph(int V)
        {
            _V = V;
            BuildGraph();
        }

        public Graph(string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                string content = reader.ReadToEnd();
                var lines = content.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int v;
                if (int.TryParse(lines[0], out v))
                {
                    _V = v;
                }
                int e;
                if (int.TryParse(lines[1], out e))
                {
                    _E = e;
                }
                BuildGraph();
                for (int i = 2; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var vertices = line.Split(' ');
                    int v1, v2;
                    if (int.TryParse(vertices[0], out v1) && int.TryParse(vertices[1], out v2))
                    {
                        AddEdge(v1, v2);
                    }
                }
            }
        }

        public abstract int V();

        public abstract int E();

        public abstract void AddEdge(int v, int w);

        public abstract IEnumerable<int> Adj(int v);

        protected abstract void BuildGraph();

        public static int Degree(Graph G, int v)
        {
            int degree = 0;
            foreach (int w in G.Adj(v))
            {
                degree++;
            }
            return degree;
        }

        public static int MaxDegree(Graph G)
        {
            int max = 0;
            for (int v = 0; v < G.V(); v++)
            {
                if (Degree(G, v) > max)
                {
                    max = Degree(G, v);
                }
            }

            return max;
        }

        public static int NumberOfSelfLoops(Graph G)
        {
            int count = 0;
            for (int v = 0; v < G.V(); v++)
            {
                foreach (int w in G.Adj(v))
                {
                    if (v == w) count++;
                }
            }

            return count / 2;
        }

        public override string ToString()
        {
            string s = V() + " vertices, " + E() + " edges\n";
            for (int v = 0; v < V(); v++)
            {
                s += v + ": ";
                foreach (int w in this.Adj(v))
                    s += w + " ";
                s += "\n";
            }
            return s;
        }
    }

    public class AdjacencyMatricGraph : Graph
    {
        private bool[][] _edges;
        
        public AdjacencyMatricGraph(int V)
            : base(V)
        {
           
        }

        public AdjacencyMatricGraph(string path)
            : base(path)
        {
           
        }

        public override int V()
        {
            return _V;
        }

        public override int E()
        {
            return _E;
        }

        public override void AddEdge(int v, int w)
        {
            _edges[v][w] = true;
            _edges[w][v] = true;
        }

        public override IEnumerable<int> Adj(int v)
        {
            List<int> adjacencies = new List<int>();
            for (int i = 0; i < _edges[v].Length; i++)
            {
                if (_edges[v][i])
                {
                    adjacencies.Add(i);
                }
            }
            return adjacencies;
        }

        protected override void BuildGraph()
        {
            _edges = new bool[_V][];
            for (int i = 0; i < _V; i++)
            {
                _edges[i] = new bool[_V];
            }
            for (int i = 0; i < _V; i++)
            {
                _edges[i][i] = true;
            }
        }
    }

    public class EdgeArrayGraph : Graph
    {
        public EdgeArrayGraph(int V)
            : base(V)
        {
        }

        public EdgeArrayGraph(string path)
            : base(path)
        {
        }

        public override int V()
        {
            throw new System.NotImplementedException();
        }

        public override int E()
        {
            throw new System.NotImplementedException();
        }

        public override void AddEdge(int v, int w)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<int> Adj(int v)
        {
            throw new System.NotImplementedException();
        }

        protected override void BuildGraph()
        {
            throw new NotImplementedException();
        }
    }

    public class AdjacencyListGraph : Graph
    {
        public AdjacencyListGraph(int V)
            : base(V)
        {
        }

        public AdjacencyListGraph(string path)
            : base(path)
        {
        }

        public override int V()
        {
            throw new System.NotImplementedException();
        }

        public override int E()
        {
            throw new System.NotImplementedException();
        }

        public override void AddEdge(int v, int w)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<int> Adj(int v)
        {
            throw new System.NotImplementedException();
        }

        protected override void BuildGraph()
        {
            throw new NotImplementedException();
        }
    }
}