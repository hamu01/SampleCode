using System;

namespace StringResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            TrieTest();
        }

        private static void TrieTest()
        {
            StringST<int?> st = new TST<int?>();
            string[] keys = new string[] { "she", "shells", "sea", "shells", "by", "sea", "shore", "the" };
            for (int i = 0; i < keys.Length; i++)
            {
                st.Put(keys[i], i);
            }

            keys = new string[] { "shells", "she", "shell", "shore", "share" };
            foreach (var key in keys)
            {
                int? value = st.Get(key);
                System.Console.WriteLine("{0}: {1}", key, value);
            }

            // var allKeys = st.Keys();
            // System.Console.WriteLine(string.Join(",", allKeys));

            // var keysWithPrefix = st.keysWithPrefix("she");
            // System.Console.WriteLine(string.Join(",", keysWithPrefix));

            // var keysThatMatch = st.keysThatMatch(".he");
            // System.Console.WriteLine(string.Join(",", keysThatMatch));

            // var prefix = st.LongestPrefixOf("shellsort");
            // System.Console.WriteLine(prefix);

            // foreach (var key in keys)
            // {
            //     st.Delete(key);
            //     System.Console.WriteLine("{0}: {1}", key, st.Get(key));
            // }
        }
    }
}
