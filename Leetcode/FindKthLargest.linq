<Query Kind="Program" />

void Main()
{
	FindKthLargest(new int[]{3,2,1,5,6,4}, 3).Dump();
}

public int FindKthLargest(int[] nums, int k) 
{
	for (int i = 0; i < k; i++)
	{
		for (int j = nums.Length - 1; j > i; j--)
		{
			if(nums[j] > nums[j-1])
			{
				Exchange(nums, j-1, j);
			}
		}
	}
	return nums[k-1];
}

private void Exchange(int[] nums, int i, int j)
{
	int temp = nums[i];
	nums[i] = nums[j];
	nums[j] = temp;
}