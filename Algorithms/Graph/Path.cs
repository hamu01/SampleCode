using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class PathSample
    {
        public void Run()
        {
            var g = GraphFactory.BuildSimpleGraph();
            Path path = new Path();
            int s = 0, t = 4;
            bool hasPathTo = path.HasPathTo(g, s, t);
            if (hasPathTo)
            {
                Console.WriteLine($"{s} has path to {t}");
                var paths = path.PathTo(g, s, t);
                string pathStr = string.Join("->", paths);
                Console.WriteLine($"{s} to {t} path is : {pathStr}");
                var shortestPaths = path.ShortestPathTo(g, s, t);
                string shortestPathStr = string.Join("->", shortestPaths);
                Console.WriteLine($"{s} to {t} shortest path is : {shortestPathStr}");
            }
            else
            {
                Console.WriteLine($"{s} has not path to {t}");
            }
        }
    }

    public class Path
    {
        public bool HasPathTo(SimpleGraph g, int s, int t)
        {
            bool[] marked = new bool[g.Vertexes.Count];
            int[] pathTo = new int[g.Vertexes.Count];
            marked[s] = true;
            Dfs(g, s, marked, pathTo);
            return marked[t];
        }

        public Stack<int> PathTo(SimpleGraph g, int s, int t)
        {
            bool[] marked = new bool[g.Vertexes.Count];
            int[] pathTo = new int[g.Vertexes.Count];
            Dfs(g, s, marked, pathTo);
            Stack<int> stack = new Stack<int>();
            int v = t;
            while (v != s)
            {
                stack.Push(v);
                v = pathTo[v];
            }
            stack.Push(s);
            return stack;
        }

        private void Dfs(SimpleGraph g, int v, bool[] marked, int[] pathTo)
        {
            foreach (var w in g.Adj(v))
            {
                if (!marked[w])
                {
                    marked[w] = true;
                    pathTo[w] = v;
                    Dfs(g, w, marked, pathTo);
                }
            }
        }

        public Stack<int> ShortestPathTo(SimpleGraph g, int s, int t)
        {
            bool[] marked = new bool[g.Vertexes.Count];
            int[] pathTo = new int[g.Vertexes.Count];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            while (queue.Count > 0)
            {
                int q = queue.Dequeue();
                foreach (var w in g.Adj(q))
                {
                    if (!marked[w])
                    {
                        pathTo[w] = q;
                        queue.Enqueue(w);
                        marked[w] = true;
                    }
                }
            }

            Stack<int> stack = new Stack<int>();
            int v = t;
            while (v != s)
            {
                stack.Push(v);
                v = pathTo[v];
            }
            stack.Push(s);
            return stack;
        }
    }
}