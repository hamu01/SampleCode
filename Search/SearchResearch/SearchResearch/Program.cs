using System;
using System.Diagnostics;
using System.IO;

namespace SearchResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //STBase<string, int> st = GetSt();
            //SampleClient sampleClient = new SampleClient();
            //sampleClient.Run(st);

            PerformanceClient perfClient = new PerformanceClient();
            perfClient.Run(GetSt(), "tinyTale.txt", 1);
            perfClient.Run(GetSt(), "tale.txt", 1);
            perfClient.Run(GetSt(), "leipzig1M.txt", 1);

            Console.ReadLine();
        }

        private static STBase<string, int> GetSt()
        {
            STBase<string, int> st;
            //st = new SequentialSearchST<string, int>();
            st = new BinarySearchST<string, int>(10000000);
            return st;
        }
    }

    public class SampleClient
    {
        public void Run(STBase<string, int> st)
        {
            string s = "SEARCHEXAMPLE";
            var chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                st.Put(chars[i].ToString(), i);
            }
            foreach (string key in st.Keys())
            {
                Console.WriteLine("{0} {1}", key, st.Get(key));
            }
        }
    }

    public class PerformanceClient
    {
        public void Run(STBase<string, int> st, string path, int minlen)
        {
            int wordCount = 0;
            Stopwatch watch = Stopwatch.StartNew();
            using (Stream stream = new FileStream(path, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                string content = reader.ReadToEnd();
                string[] lines = content.Split('\n');
                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] words = line.Split(' ');
                        foreach (string word in words)
                        {
                            if (word.Length < minlen)
                            {
                                continue;
                            }
                            else
                            {
                                wordCount++;
                                if (st.Contains(word))
                                {
                                    st.Put(word, st.Get(word) + 1);
                                }
                                else
                                {
                                    st.Put(word, 1);
                                }
                            }
                        }
                    }
                }
            }

            string max = "";
            st.Put(max, 0);
            int keyCount = 0;
            foreach (string key in st.Keys())
            {
                keyCount++;
                if (st.Get(key) > st.Get(max))
                {
                    max = key;
                }
            }
            Console.WriteLine("Words: {0}, Keys: {1}", wordCount, keyCount);
            Console.WriteLine("{0} {1} ({2}ms)", max, st.Get(max), watch.ElapsedMilliseconds);
        }
    }
}