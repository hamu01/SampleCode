using System;
using System.Collections.Generic;

namespace Dp
{
    public class BalancePartitionSample
    {
        public void Test()
        {
            BalancePartition partition = new BalancePartition();
            int[] nums;
            int sum = 5;
            nums = new int[] { 1, 1, 1, 3, 2, 2 };
            Test(partition, nums, sum);
        }

        private void Test(BalancePartition partition, int[] nums, int sum)
        {
            bool isSubset = partition.IsSubsetSumWithRecur(nums, sum);
            Console.WriteLine($"{string.Join(",", nums)} for {sum} can be balance partition: {isSubset}");
        }
    }

    public class BalancePartition
    {
        public bool IsSubsetSumWithRecur(int[] nums, int sum)
        {
            return IsSubsetSumWithRecur(new List<int>(nums), sum, sum);
        }

        private bool IsSubsetSumWithRecur(List<int> nums, int sum, int originSum)
        {
            if (sum < 0)
            {
                return false;
            }
            if (sum == 0)
            {
                int total = 0;
                foreach (int num in nums)
                {
                    total += num;
                }
                return total == originSum;
            }
            for (int i = 0; i < nums.Count; i++)
            {
                int num = nums[i];
                nums.RemoveAt(i);
                bool isSubset = IsSubsetSumWithRecur(nums, sum - num, originSum);
                if (isSubset) return true;
                nums.Insert(i, num);
            }
            return false;
        }

        public bool IsSubsetSum(int[] nums, int sum)
        {
            throw new NotImplementedException();
        }
    }
}