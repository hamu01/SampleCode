using System;
using System.Collections.Generic;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            // IndexOfSample indexOf = new IndexOfSample();
            // indexOf.Run();

            // JoinSample join = new JoinSample();
            // join.Run();

            // SplitSample split = new SplitSample();
            // split.Run();

            // TrimSample trim = new TrimSample();
            // trim.Run();

            // CompareSample compare = new CompareSample();
            // compare.Run();
            Solution solution = new Solution();
            // solution.FindLadders("hit", "cog", new List<string>(){"hot","dot","dog","lot","log","cog"});
            solution.FindLadders("a", "c", new List<string>() { "a", "b", "c" });
        }
    }

    public class Solution
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            if (beginWord.Length > 1)
            {
                wordList.Add(beginWord);
                var g = GetGraph(wordList);
                return FindShortestPaths(g, beginWord, endWord);
            }
            else
            {
                IList<IList<string>> pathList = new List<IList<string>>();
                foreach (var word in wordList)
                {
                    if (word != endWord)
                    {
                        pathList.Add(new List<string>() { beginWord, word, endWord });
                    }
                }
                return pathList;
            }
        }

        private Dictionary<char, List<string>> GetDic(IList<string> wordList)
        {
            Dictionary<char, List<string>> dic = new Dictionary<char, List<string>>();
            foreach (var w in wordList)
            {
                foreach (var c in w)
                {
                    if (dic.ContainsKey(c))
                    {
                        dic[c].Add(w);
                    }
                    else
                    {
                        dic[c] = new List<string>() { w };
                    }
                }
            }
            return dic;
        }

        private Graph GetGraph(IList<string> wordList)
        {
            var dic = GetDic(wordList);
            Graph g = new Graph();
            foreach (var w in wordList)
            {
                Dictionary<string, int> countDic = new Dictionary<string, int>();
                foreach (var c in w)
                {
                    foreach (var ow in dic[c])
                    {
                        if (countDic.ContainsKey(ow))
                        {
                            countDic[ow]++;
                        }
                        else
                        {
                            countDic[ow] = 1;
                        }
                    }
                }
                foreach (var pair in countDic)
                {
                    if (pair.Value > 1 && pair.Key != w)
                    {
                        g.AddEdge(w, pair.Key);
                    }
                }
            }
            return g;
        }

        private IList<IList<string>> FindShortestPaths(Graph g, string s, string t)
        {
            IList<IList<string>> pathList = new List<IList<string>>();
            FindPaths(g, s, t, new List<string>(), pathList);
            if (pathList.Count == 0) return pathList;
            int min = pathList[0].Count;
            IList<IList<string>> shortestPaths = new List<IList<string>>() { pathList[0] };
            for (int i = 1; i < pathList.Count; i++)
            {
                if (pathList[i].Count < min)
                {
                    shortestPaths = new List<IList<string>>() { pathList[i] };
                    min = pathList[i].Count;
                }
                else if (pathList[i].Count == min)
                {
                    shortestPaths.Add(pathList[i]);
                }
            }
            return shortestPaths;
        }

        private void FindPaths(Graph g, string s, string t, List<string> path, IList<IList<string>> pathList)
        {
            path.Add(s);
            if (s == t)
            {
                pathList.Add(path);
                return;
            }
            foreach (var v in g.Adj(s))
            {
                if (!path.Contains(v))
                {
                    List<string> newPath = new List<string>(path);
                    FindPaths(g, v, t, newPath, pathList);
                }
            }
        }
    }
    public class Graph
    {
        public Dictionary<string, List<string>> Edges = new Dictionary<string, List<string>>();

        public void AddEdge(string s, string t)
        {
            if (Edges.ContainsKey(s))
            {
                if (!Edges[s].Contains(t))
                {
                    Edges[s].Add(t);
                }
            }
            else
            {
                Edges[s] = new List<string>() { t };
            }
            if (Edges.ContainsKey(t))
            {
                if (!Edges[t].Contains(s))
                {
                    Edges[t].Add(s);
                }
            }
            else
            {
                Edges[t] = new List<string>() { s };
            }
        }

        public List<string> Adj(string s)
        {
            return Edges[s];
        }
    }
}