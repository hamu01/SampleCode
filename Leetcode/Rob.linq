<Query Kind="Program" />

void Main()
{
	Rob(new int[]{10,12,13,4,5,6}).Dump();
	Rob(new int[]{2,1,10,100}).Dump();
	Rob(new int[]{}).Dump();
}

private int[] _maxNums;

public int Rob(int[] nums) 
{
	if(nums.Length <= 0)
	{
		return 0;
	}
	_maxNums = new int[nums.Length];
	for (int i = 0; i < nums.Length; i++)
	{
		int p1 = i>=1 ? Math.Max(_maxNums[i-1], nums[i]) : nums[i];
		int p2 = i>=2 ? _maxNums[i-2] + nums[i] : nums[i];
		int p3 = i>=3 ? _maxNums[i-3] + nums[i] : nums[i];
		_maxNums[i] = Max(p1, p2, p3);
	}
	return _maxNums[nums.Length-1];
}

public int Rob1(int[] nums) 
{
	_maxNums = new int[nums.Length];
	return Rob(nums, nums.Length-1);
}

private int Rob(int[] nums, int i)
{
	if(i < 0)
	{
		return 0;
	}
	int p1 = Math.Max(Rob(nums, i-1), nums[i]);
	int p2 = Rob(nums, i-2) + nums[i];
	int p3 = Rob(nums, i-3) + nums[i];
	return Max(p1, p2, p3);
}

private int Max(int p1, int p2, int p3)
{
	return Math.Max(p1, Math.Max(p2, p3));
}