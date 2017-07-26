<Query Kind="Program" />

void Main()
{
	int[] nums = new int[]{2,3,3,2};
	(RemoveElement(nums, 2) == 2).Dump();
	nums.Dump();
	
	nums = new int[]{2,2,2,2};
	(RemoveElement(nums, 2) == 0).Dump();
	nums.Dump();
	
	nums = new int[]{2};
	(RemoveElement(nums, 2) == 0).Dump();
	nums.Dump();
	
	nums = new int[]{};
	(RemoveElement(nums, 2) == 0).Dump();
	nums.Dump();
	
	nums = new int[]{4, 5};
	(RemoveElement(nums, 5) == 1).Dump();
	nums.Dump();
	
	nums = new int[]{4, 5, 5};
	(RemoveElement(nums, 5) == 1).Dump();
	nums.Dump();
}

// Define other methods and classes here
public int RemoveElement1(int[] nums, int val) {
	int length = nums.Length;
	int i = 0;
	while(i < length){
		int num = nums[i];
		if(num == val) {
			int j = 1;
			int temp = 0;
			while(j <= length && length - j > i && (temp = nums[length - j]) == val) {
				j++;
			}
			if(j <= length && length - j > i) {
				nums[i] = temp;
				nums[length - j] = num;
			}
			length = length - j;
			if(length < 0) {
				length = 0;
			}
		}
		i++;
	}
	return length;
}

public int RemoveElement2(int[] nums, int val) {
	int m = 0;    
	for(int i = 0; i < nums.Length; i++){
		if(nums[i] != val){
			nums[m] = nums[i];
			m++;
		}
	}
   	return m;
}