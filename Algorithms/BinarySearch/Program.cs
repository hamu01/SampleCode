using System;

namespace BinarySearch
{
    class Program
    {
        private static Random random = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {
            Search search = new Search();
            int[] numbers = GetNumbers(10);
            int target = numbers[random.Next(0, numbers.Length - 1)];
            int index = search.SearchEqual(numbers, target);
            Print(numbers, target, index);

            numbers = GetNumbers(10);
            target = numbers[random.Next(0, numbers.Length - 1)];
            index = search.SearchEqual(numbers, target);
            Print(numbers, target, index);
        }

        private static void Print(int[] numbers, int target, int index)
        {
            string s = string.Join(",", numbers);
            Console.WriteLine($"{target} in [{s}] is {index}");
        }

        private static int[] GetNumbers(int n)
        {
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = random.Next(10, 1000);
            }
            Array.Sort(numbers);
            return numbers;
        }
    }
}