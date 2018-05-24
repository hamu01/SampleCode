using System;

namespace Dp
{
    public class LISSample
    {
        public void Run()
        {
            // int[] nums = new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
            int[] nums = new int[] { 0, 8, 4, 12, 2, 10 };
            LIS lis = new LIS();
            int len = lis.FindWithRecur(nums);
            Console.WriteLine($"FindWithRecur: {string.Join(",", nums)} lis is {len}");
        }
    }

    public class LIS
    {
        public int FindWithRecur(int[] nums)
        {
            return FindWithRecur(nums, nums.Length - 1);
        }

        private int FindWithRecur(int[] nums, int i)
        {
            if (nums[i] >= nums[i - 1])
            {
                return FindWithRecur(nums, i - 1) + 1;
            }
            else
            {
                 return FindWithRecur(nums, i - 1);
            }
        }
    }
}