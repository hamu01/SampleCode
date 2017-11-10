<Query Kind="Program" />

void Main()
{
	var nums = new int[]{-4, -2, -1, -1, 0, 1, 1, 2};
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
	var sumList = ThreeSum(nums);
	foreach(var sums in sumList)
	{
		Console.WriteLine(string.Join(" ", sums));
	}
}

public IList<IList<int>> ThreeSum(int[] nums) {
	List<IList<int>> res = new List<IList<int>>();
	Array.Sort(nums);
	for (int i = 0; i + 2 < nums.Length; i++) {
		if (i > 0 && nums[i] == nums[i - 1]) {              // skip same result
			continue;
		}
		int j = i + 1, k = nums.Length - 1;  
//		int target = -nums[i];
		while (j < k) {
			if (nums[i] + nums[j] + nums[k] == 0) {
				res.Add(new List<int>(){nums[i], nums[j], nums[k]});
				j++;
				k--;
				while (j < k && nums[j] == nums[j - 1]) j++;  // skip same result
				while (j < k && nums[k] == nums[k + 1]) k--;  // skip same result
			} else if (nums[i] + nums[j] + nums[k] > 0) {
				k--;
			} else {
				j++;
			}
		}
	}
	return res;
}

public IList<IList<int>> ThreeSum2(int[] nums)
{
	List<IList<int>> sumList = new List<IList<int>>();
	HashSet<Tuple<int, int, int>> sumHash = new HashSet<Tuple<int, int, int>>();
	List<int> negativeList = new List<int>();
	List<int> positiveList = new List<int>();
	HashSet<int> positive = new HashSet<int>();
	HashSet<int> negative = new HashSet<int>();
	int zeroCount = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if(nums[i] < 0)
		{
			negative.Add(nums[i]);
			negativeList.Add(nums[i]);
		}
		else if(nums[i] > 0)
		{
			positive.Add(nums[i]);
			positiveList.Add(nums[i]);
		}
		else
		{
			zeroCount++;
		}
	}
	negativeList.Sort();
	positiveList.Sort();
	if(zeroCount >= 3)
	{
		sumList.Add(new List<int>(){0, 0, 0});
	}
	if(zeroCount > 0)
	{
		for (int i = 0; i < negativeList.Count; i++)
		{
			if(i > 1 && negativeList[i] == negativeList[i-1])
			{
				continue;
			}
			var num = negativeList[i];
			AddToList(num, 0, positive, sumHash, sumList);
		}
	}
	AddToList(positiveList, negative, sumHash, sumList);
	AddToList(negativeList, positive, sumHash, sumList);
	return sumList;
}

private void AddToList(List<int> list, HashSet<int> hashSet, HashSet<Tuple<int, int, int>> sumHash, List<IList<int>> sumList)
{
	for (int i = 0; i < list.Count; i++)
	{
		for (int j = i+1; j < list.Count; j++)
		{
			if(j> i+1 && list[j] == list[j-1])
			{
				continue;
			}
			int num = list[i] + list[j];
			AddToList(list[i], list[j], hashSet, sumHash, sumList);
		}
	}
}

private void AddToList(int num1, int num2, HashSet<int> hashSet, HashSet<Tuple<int, int, int>> sumHash, List<IList<int>> sumList)
{
	int num = num1 + num2;
	if (hashSet.Contains(-num))
	{
		List<int> sums = new List<int>();
		sums.Add(num1);
		sums.Add(num2);
		sums.Add(-num);
		sums.Sort();
		Tuple<int, int, int> tuple = new Tuple<int, int, int>(sums[0], sums[1], sums[2]);
		if (!sumHash.Contains(tuple))
		{
			sumHash.Add(tuple);
			sumList.Add(sums);
		}
	}
}

public IList<IList<int>> ThreeSum1(int[] nums) {
	List<IList<int>> sumList = new List<IList<int>>();
	HashSet<Tuple<int, int, int>> sumHash = new HashSet<Tuple<int, int, int>>();
	Dictionary<int, int> hashSet = new Dictionary<int, int>();
	for (int i = 0; i < nums.Length; i++)
	{
		hashSet[nums[i]] = i;
	}
	for (int i = 0; i < nums.Length; i++)
	{
		for (int j = i + 1; j < nums.Length; j++)
		{
			int num = nums[i] + nums[j];
			if (hashSet.ContainsKey(-num))
			{
				var index = hashSet[-num];
				if (index != i && index != j)
				{
					List<int> sums = new List<int>();
					sums.Add(nums[i]);
					sums.Add(nums[j]);
					sums.Add(-num);
					sums.Sort();
					Tuple<int, int, int> tuple = new Tuple<int, int, int>(sums[0], sums[1], sums[2]);
					if (!sumHash.Contains(tuple))
					{
						sumHash.Add(tuple);
						sumList.Add(sums);
					}
				}
			}
		}
	
	}
	return sumList;
}