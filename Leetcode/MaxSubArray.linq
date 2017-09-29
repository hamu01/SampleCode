<Query Kind="Program" />

void Main()
{
	MaxSubArray2(new int[] {-2}).Dump();
	MaxSubArray(new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}).Dump();
//	MaxSubArray(new int[] {-2, 1, -3, 4, -1, 2, -1, -5, 4}).Dump();
//	MaxSubArray(new int[] {6, -7, 1}).Dump();
//	MaxSubArray(new int[] {6, -1, -7, 2, 1}).Dump();
//	MaxSubArray(new int[] {4, -1, 2, 1}).Dump();
}

public int MaxSubArray2(int[] nums) {
	int maxSoFar=nums[0], maxEndingHere=nums[0];
	for (int i=1;i<nums.Length;++i){
		maxEndingHere= Math.Max(maxEndingHere+nums[i],nums[i]);
		maxSoFar=Math.Max(maxSoFar, maxEndingHere);	
	}
	return maxSoFar;
}


public int MaxSubArray1(int[] nums) {
	int max = 0;
	int sum = 0;
	foreach (var num in nums)
	{
		sum += num;
		max = Math.Max(max, sum);
		if(sum < 0) {
			sum = 0;
		}
	}
	return max;
}

public int MaxSubArray(int[] nums) {
	return Devide(nums, 0, nums.Length-1, 0, 0);
}

private int Devide(int[] nums, int left, int right, int tmax, int dent){
	string empty="";
	for (int i = 0; i < dent; i++)
	{
		empty = empty + "  ";
	}
	if(left > right) {
		return tmax;
	}
//	Console.WriteLine ("{3}Devide begin: left={0}, right={1}, tmax={2}", left,right,tmax,empty);
	int mid = (left + right) / 2;
	dent++;
	int lmax = Devide(nums, left, mid-1, tmax, dent);
	int rmax = Devide(nums, mid+1, right, tmax, dent);
	
	tmax = Max(lmax, tmax, rmax);
	
	int sum = 0;
	int mlmax = 0;
	for(int i = mid - 1; i >= left; i--) {
		sum += nums[i];
		mlmax = Math.Max(mlmax, sum);
	}
	sum = 0;
	int mrmax = 0;
	for(int i = mid + 1; i <= right; i++) {
		sum += nums[i];
		mrmax = Math.Max(mrmax, sum);
	}
	
	tmax = Math.Max(tmax, nums[mid] + mlmax + mrmax);
//	Console.WriteLine ("{4}Devide end: left={0}, right={1}, tmax={2}, max={3}", left,right,tmax,tmax,empty);
	return tmax;
}

private int Max(int i, int j, int k) {
	return Math.Max(i, Math.Max(j, k));
}