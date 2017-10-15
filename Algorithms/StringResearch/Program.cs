using System;

namespace StringResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            StringST<int?> st =new TrieST<int?>();
            string[] keys = new string[]{"she", "shells", "sea","shells","by","sea","shore"};
            for (int i = 0; i < keys.Length; i++)
            {
                st.Put(keys[i], i);
            }
            
            keys = new string[]{"shells","she","shell","shore","share"};
            foreach (var key in keys)
            {
                int? value = st.Get(key);
                System.Console.WriteLine("{0}: {1}", key, value);
            }

            var trieKeys = st.Keys();
            System.Console.WriteLine(string.Join(",", trieKeys));

            var keysWithPrefix = st.keysWithPrefix("she");
            System.Console.WriteLine(string.Join(",", keysWithPrefix));

            var keysThatMatch = st.keysThatMatch(".he");
            System.Console.WriteLine(string.Join(",", keysThatMatch));
        }
    }
}
