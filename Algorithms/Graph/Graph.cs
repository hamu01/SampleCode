using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public abstract class Graph
    {
        public Graph(List<Vertex> vertexes)
        {
            Vertexes = vertexes;
        }

        public List<Vertex> Vertexes { get; set; }

        public abstract void AddEdge(int sourceIndex, int targetIndex);

        public void AddEdge(string sourceName, string targetName)
        {
            int sourceIndex = Vertexes.First(x => x.Name == sourceName).Index;
            int targetIndex = Vertexes.First(x => x.Name == targetName).Index;
            AddEdge(sourceIndex, targetIndex);
        }

        public abstract List<Vertex> Adj(int vertexIndex);

        public List<Vertex> Adj(string vertexName)
        {
            int vertexIndex = Vertexes.First(x => x.Name == vertexName).Index;
            return Adj(vertexIndex);
        }
    }

    public class MatrixGraph : Graph
    {
        public bool[,] _matrix;

        public MatrixGraph(List<Vertex> vertexes) : base(vertexes)
        {
            _matrix = new bool[vertexes.Count, vertexes.Count];
        }

        public override void AddEdge(int sourceIndex, int targetIndex)
        {
            _matrix[sourceIndex, targetIndex] = true;
            _matrix[targetIndex, sourceIndex] = true;
        }

        public override List<Vertex> Adj(int vertexIndex)
        {
            List<Vertex> vertexes = new List<Vertex>();
            for (int i = 0; i < Vertexes.Count; i++)
            {
                if (_matrix[vertexIndex, i])
                {
                    Vertex v = Vertexes.First(x => x.Index == i);
                    vertexes.Add(v);
                }
            }
            return vertexes;
        }
    }

    public class AdjacencyListGraph : Graph
    {
        public List<int>[] _adjacencyList;
        public AdjacencyListGraph(List<Vertex> vertexes) : base(vertexes)
        {
            _adjacencyList = new List<int>[vertexes.Count];
            for (int i = 0; i < vertexes.Count; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        public override void AddEdge(int s, int t)
        {
            _adjacencyList[s].Add(t);
            _adjacencyList[t].Add(s);
        }

        public override List<Vertex> Adj(int vertexIndex)
        {
            List<Vertex> vertexes = new List<Vertex>();
            var adjIndics = _adjacencyList[vertexIndex];
            foreach (var i in adjIndics)
            {
                var vertex = Vertexes.First(x => x.Index == i);
                vertexes.Add(vertex);
            }
            return vertexes;
        }
    }

    public class Vertex
    {
        public int Index { get; set; }

        public string Name { get; set; }
    }

    public class SimpleGraph
    {
        private List<int>[] _adjacencyList;
        private List<int> _vertexes;

        public SimpleGraph(List<int> vertexes)
        {
            _vertexes = vertexes;
            _adjacencyList = new List<int>[vertexes.Count];
            for (int i = 0; i < vertexes.Count; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int s, int t)
        {
            _adjacencyList[s].Add(t);
            _adjacencyList[t].Add(s);
        }

        public List<int> Adj(int vertexIndex)
        {
            return _adjacencyList[vertexIndex];
        }

        public List<int> Vertexes
        {
            get
            {
                return _vertexes;
            }
        }
    }

    public static class GraphFactory
    {
        public static Graph BuildGraph()
        {
            List<Vertex> vertexes = new List<Vertex>();
            for (int i = 0; i <= 5; i++)
            {
                vertexes.Add(new Vertex() { Index = i, Name = $"Vertex {i + 1}" });
            }
            Graph g = new MatrixGraph(vertexes);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(1, 2);
            g.AddEdge(1, 4);
            g.AddEdge(2, 3);
            g.AddEdge(2, 5);
            g.AddEdge(3, 4);
            return g;
        }

        public static SimpleGraph BuildSimpleGraph()
        {
            List<int> vertexes = new List<int>() { 0, 1, 2, 3, 4, 5 };
            SimpleGraph g = new SimpleGraph(vertexes);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(1, 4);
            g.AddEdge(2, 3);
            g.AddEdge(2, 5);
            g.AddEdge(3, 4);
            return g;
        }
    }
}