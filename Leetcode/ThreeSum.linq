<Query Kind="Program" />

void Main()
{
	
//	int len = 10000;
//	var nums = new int[len];
//	Random random = new Random();
//	for (int i = 0; i < len/2; i++)
//	{
//		nums[i] = random.Next(0,1000);
//	}
//	for (int i = 0; i < len/2; i++)
//	{
//		nums[len/2+i] = random.Next(-1000, 0);
//	}
	var nums = new int[]{-4, -2, -1, -1, 0, 1, 1, 2};
//	var nums = new int[] {0,0,0,0};
	var sumList = ThreeSum(nums);
	foreach(var sums in sumList)
	{
		Console.WriteLine(string.Join(" ", sums));
	}
}

public IList<IList<int>> ThreeSum(int[] nums)
{
	List<IList<int>> sumList = new List<IList<int>>();
	Array.Sort(nums);
	for(int i = 0; i< nums.Length-2; i++)
	{
		if(i-1 >= 0 && nums[i] == nums[i-1]) {
			continue;
		}
		int j = i+1;
		int k = nums.Length - 1;
		while(j<k)
		{
			if(nums[j] + nums[k] == 0-nums[i])
			{
				List<int> sums = new List<int>();
				sums.Add(nums[i]);
				sums.Add(nums[k]);
				sums.Add(nums[j]);
				sumList.Add(sums);
				while(j<k && nums[j+1] == nums[j]) {
					j++;
				}
				while(j<k && nums[k] == nums[k-1]) {
					k--;
				}
				j++;
				k--;
			}
			else if(nums[j] + nums[k] < 0-nums[i])
			{
				j++;
			}
			else
			{
				k--;
			}
		}
	}
	return sumList;
}