using System;

namespace DevideConquer
{
    public class MajorityElements
    {
        public void Run()
        {
            int[] nums = new int[] { 3, 2, 3 };
            int majority = Find(nums);
            Console.WriteLine($"{string.Join(",", nums)}: {majority}");
            nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            majority = Find(nums);
            Console.WriteLine($"{string.Join(",", nums)}: {majority}");
        }

        public int Find(int[] nums)
        {
            Array.Sort(nums);

            int n = nums.Length;
            int mid = n / 2;
            int first = -1, second = -1;
            if (n % 2 == 0)
            {
                first = mid;
                second = mid - 1;
            }
            else
            {
                first = second = mid;
            }

            if (CheckSame(nums, 0, first))
            {
                return nums[0];
            }
            if (CheckSame(nums, second, n - 1))
            {
                return nums[n - 1];
            }
            return -1;
        }

        private bool CheckSame(int[] nums, int lo, int hi)
        {
            if (lo == hi)
            {
                return true;
            }
            int mid = (lo + hi) / 2;
            if (CheckSame(nums, lo, mid) && CheckSame(nums, mid + 1, hi))
            {
                return nums[lo] == nums[hi];
            }
            return false;
        }
    }
}