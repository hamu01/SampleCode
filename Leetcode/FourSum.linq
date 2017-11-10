<Query Kind="Program" />

void Main()
{
	var sumList = FourSum(new int[]{-2, -2, -1, 0, 0, 4}, 0);
//	var sumList = FourSum(new int[]{-2, -1, 0, 0, 1, 2}, 0);
	foreach(var sums in sumList)
	{
		Console.WriteLine(string.Join(" ", sums));
	}
}

public IList<IList<int>> FourSum(int[] nums, int target) {
	List<IList<int>> ans = new List<IList<int>>();
	if (nums.Length < 4) return ans;
	Array.Sort(nums);
	for (int i = 0; i < nums.Length - 3; i++)
	{
		if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target)
		{
			break; //first candidate too large, search finished
		}
		if (nums[i] + nums[nums.Length - 1] + nums[nums.Length - 2] + nums[nums.Length - 3] < target)
		{
			continue; //first candidate too small
		}
		if (i > 0 && nums[i] == nums[i - 1])
		{
			continue; //prevents duplicate result in ans list
		}
		for (int j = i + 1; j < nums.Length - 2; j++)
		{
			if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target)
			{
				break; //second candidate too large
			}
			if (nums[i] + nums[j] + nums[nums.Length - 1] + nums[nums.Length - 2] < target)
			{
				continue; //second candidate too small
			}
			if (j > i + 1 && nums[j] == nums[j - 1])
			{
				continue; //prevents duplicate results in ans list
			}
			int low = j + 1, high = nums.Length - 1;
			while (low < high)
			{
				int sum = nums[i] + nums[j] + nums[low] + nums[high];
				if (sum == target)
				{
					ans.Add(new List<int>() { nums[i], nums[j], nums[low], nums[high] });
					while (low < high && nums[low] == nums[low + 1]) low++; //skipping over duplicate on low
					while (low < high && nums[high] == nums[high - 1]) high--; //skipping over duplicate on high
					low++;
					high--;
				}
				//move window
				else if (sum < target) 
				{ 
					low++; 
				}
				else
				{
					high--;
				}
			}
		}
	}
	return ans;
}