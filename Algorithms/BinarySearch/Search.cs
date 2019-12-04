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

        // >=, 退出循环后一定满足lo=hi+1
        public int SearchNotLessThan(int[] numbers, int target)
        {
            int lo = 0, hi = numbers.Length - 1;
            while (lo <= hi)
            {
                int mid = (hi - lo) / 2 + lo;
                if (target <= numbers[mid])
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return lo; // or hi+1
        }

        // <
        public int SearchLessThan(int[] numbers, int target)
        {
            int lo = 0, hi = numbers.Length - 1;
            while (lo <= hi)
            {
                int mid = (hi - lo) / 2 + lo;
                if (target <= numbers[mid])
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return hi; // or lo-1
        }

        // <=
        public int SearchNotGreaterThan(int[] numbers, int target)
        {
            int lo = 0, hi = numbers.Length - 1;
            while (lo <= hi)
            {
                int mid = (hi - lo) / 2 + lo;
                if (target >= numbers[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            return hi; // or lo-1
        }

        // >
        public int SearchGreaterThan(int[] numbers, int target)
        {
            int lo = 0, hi = numbers.Length - 1;
            while (lo <= hi)
            {
                int mid = hi - lo / 2 + lo;
                if (target >= numbers[mid])
                {
                    lo = mid + 1;
                    
                }
                else
                {
                    hi = mid - 1;
                }
            }
            return lo; // or hi+1
        }
    }
}