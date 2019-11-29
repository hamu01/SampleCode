using System;

namespace BinarySearch
{
    public class Search
    {
        public int SearchEqual(int[] numbers, int target)
        {
            int lo = 0, hi = numbers.Length - 1;
            while (lo <= hi)
            {
                int mid = (hi - lo) / 2 + lo;
                if (numbers[mid] == target) return mid;
                else if (numbers[mid] < target) lo = mid + 1;
                else hi = mid - 1;
            }
            return -1;
        }

        public int SearchEqual1(int[] numbers, int target)
        {
            int lo = 0, hi = numbers.Length;
            while (lo < hi)
            {
                int mid = (hi - lo) / 2 + lo;
                if (numbers[mid] == target) return mid;
                else if (numbers[mid] < target) lo = mid + 1;
                else hi = mid;
            }
            return -1;
        }
    }
}