<Query Kind="Program" />

void Main()
{
	MajorityElement(new int[]{1,1,2,3,4,1,1}).Dump();
}

public int MajorityElement(int[] nums) {
	Dictionary<int, int> times = new Dictionary<int,int>();
	for (int i = 0; i < nums.Length; i++)
	{
		int num = nums[i];
		if(times.ContainsKey(num))
		{
			times[num] += 1;
		}
		else
		{
			times.Add(num, 1);
		}
		if(times[num] > nums.Length /2)
		{
			return num;
		}
	}
	return -1;
}