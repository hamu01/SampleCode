using System;
using System.Diagnostics;

namespace SortResearch
{
    class Program
    {
        public static void Main()
        {
            //ISort sort = new BubbleSort();
            //ISort sort = new MergeBUSort();
            //ISort sort = new QuickSort();
            ISort sort = new HeapSort();
            Run(sort);
            //Time(sort, "normal");
            //Time(sort, "reverse");
            //Time(sort, "random", 1, 1000000);

            Console.ReadLine();
        }

        public static void Run(ISort sort)
        {
            int length = 10;
            int[] a = GetArray("random", length);
            string.Join(",", a).Dump();
            sort.Sort(a);
            Assert(a).Dump();
            string.Join(",", a).Dump();
        }

        public static void Time(ISort sort, string sortType, int count = 100, int length = 10000)
        {
            long total = 0;
            for (int j = 0; j < count; j++)
            {
                int[] a = GetArray(sortType, length);
                Stopwatch watch = Stopwatch.StartNew();
                sort.Sort(a);
                long elapsed = watch.ElapsedMilliseconds;
                total += elapsed;
            }
            string.Format("sort {0} elements need {1} ms in average of {2}", length, total / count, sortType).Dump();
        }

        public static int[] GetArray(string sortType, int length)
        {
            int[] a = new int[length];
            if (sortType == "random")
            {
                Random random = new Random();
                for (int i = 0; i < length; i++)
                {
                    a[i] = random.Next(10, 1000);
                }
            }
            else if (sortType == "reverse")
            {
                for (int i = 0; i < length; i++)
                {
                    a[i] = length - i;
                }
            }
            else if (sortType == "normal")
            {
                for (int i = 0; i < length; i++)
                {
                    a[i] = i + 1;
                }
            }
            return a;
        }

        public static bool Assert(int[] a)
        {
            for (int i = 1; i < a.Length - 1; i++)
            {
                if (a[i - 1] > a[i] || a[i] > a[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }

    public static class DumpHelper
    {
        public static void Dump(this string s)
        {
            Console.WriteLine(s);
        }

        public static void Dump(this bool b)
        {
            Console.WriteLine(b);
        }
    }
}