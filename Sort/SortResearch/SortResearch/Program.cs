using System;
using System.Diagnostics;

namespace SortResearch
{
    class Program
    {
        public static void Main()
        {
            ISort sort = new BubbleSort();
            Run(sort);
            Time(sort, "normal");
            Time(sort, "reverse");
            Time(sort, "random", 1, 1000000);
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

    public interface ISort
    {
        void Sort(int[] a);
    }

    public class BubbleSort : ISort
    {
        public void Sort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = a.Length - 1; j > i; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        int temp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }
    }

    public class InsertionSort : ISort
    {
        // 最好情况下：compare: n-1, exchange: 0
        public void Sort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        int temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        // 最好情况下：compare: 1+2+...+ (n-1) = (n-1)*(n-2)/2, exchange: 0
        public void MySort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (a[i] < a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

    }

    public class SelectionSort : ISort
    {
        public void Sort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }
                int temp = a[i];
                a[i] = a[min];
                a[min] = temp;
            }
        }
    }

    public class ShellSort : ISort
    {
        public void Sort(int[] a)
        {
            // Sort a[] into increasing order.
            int N = a.Length;
            int h = 1;
            // 1, 4, 13, 40, 121, 364, 1093, ...
            while (h < N / 3)
            {
                h = 3 * h + 1;
            }
            while (h >= 1)
            {
                // h-sort the array.
                for (int i = h; i < N; i++)
                {
                    // Insert a[i] among a[i-h], a[i-2*h], a[i-3*h]... .
                    for (int j = i; j >= h; j -= h)
                    {
                        if (a[j] > a[j - h])
                        {
                            break;
                        }
                        else
                        {
                            int temp = a[j];
                            a[j] = a[j - h];
                            a[j - h] = temp;
                        }
                    }
                }
                h = h / 3;
            }
        }

        public void MySort(int[] a)
        {
            int length = a.Length;
            while (length > 1)
            {
                length = length / 2;
                for (int i = 0; i < length; i++)
                {
                    for (int j = i + length; j < a.Length; j += length)
                    {
                        for (int k = i; k < j; k += length)
                        {
                            if (a[k] > a[j])
                            {
                                int temp = a[k];
                                a[k] = a[j];
                                a[j] = temp;
                            }
                        }
                    }
                }
            }
        }
    }

    public class MergeSort : ISort
    {
        private int[] aud;

        public void Sort(int[] a)
        {
            aud = new int[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(int[] a, int low, int high)
        {
            if (low >= high)
            {
                return;
            }
            int middle = (low + high) / 2;
            Sort(a, low, middle);
            Sort(a, middle + 1, high);
            if (a[middle] > a[middle + 1])
            {
                if (high - low > 5)
                {
                    Merge(a, low, middle, high);
                }
                else
                {
                    InsertionSort(a, low, high);
                }
            }
        }

        private void InsertionSort(int[] a, int low, int high)
        {
            for (int i = low+1; i < high+1; i++)
            {
                for (int j = i; j > low; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        int temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void Merge(int[] a, int low, int middle, int high)
        {
            int i = low;
            int j = middle + 1;
            for (int k = low; k <= high; k++)
            {
                aud[k] = a[k];
            }
            for (int k = low; k <= high; k++)
            {
                if (i > middle)
                {
                    a[k] = aud[j++];
                }
                else if (j > high)
                {
                    a[k] = aud[i++];
                }
                else if (aud[i] < aud[j])
                {
                    a[k] = aud[i++];
                }
                else
                {
                    a[k] = aud[j++];
                }
            }
        }
    }

    public class QuickSort : ISort
    {
        public void Sort(int[] a)
        {
            throw new NotImplementedException();
        }
    }

    public class HeapSort : ISort
    {
        public void Sort(int[] a)
        {
            throw new NotImplementedException();
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