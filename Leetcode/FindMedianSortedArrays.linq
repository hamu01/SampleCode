<Query Kind="Program" />

void Main()
{
	FindMedianSortedArrays(new int[]{1, 3}, new int[]{2}).Dump();
	FindMedianSortedArrays(new int[]{1, 2}, new int[]{3, 4}).Dump();
	FindMedianSortedArrays(new int[]{}, new int[]{1}).Dump();
	FindMedianSortedArrays(new int[]{1,3,5,6,8}, new int[]{2,4,7,9}).Dump();
}

public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
{
	int m = nums1.Length;
	int n = nums2.Length;
	int total = m + n;  
	if (total % 2 == 1)  
	{
		return FindKth(nums1, 0, m, nums2, 0, n, total / 2 + 1);
	}
	else
	{
		return (FindKth(nums1, 0, m, nums2, 0, n, total / 2) + FindKth(nums1, 0, m, nums2, 0, n, total / 2 + 1)) / 2;
	}
}

public double FindKth(int[] nums1, int start1, int len1, int[] nums2, int start2, int len2, int k)  
{  
	//always assume that m is equal or smaller than n  
	if (len1 > len2)  
	{
		return FindKth(nums2, start2, len2, nums1, start1, len1, k);
	}
	if (len1 == 0)
	{
		return nums2[k - 1];
	}
	if (k == 1)
	{
		return Math.Min(nums1[start1], nums2[start2]);
	}
	//divide k into two parts  
	int pa = Math.Min(k / 2, len1), pb = k - pa;  
	if (nums1[start1 + pa - 1] < nums2[start2 + pb - 1])  
	{
		return FindKth(nums1, start1 + pa, len1 - pa, nums2, start2, len2, k - pa);
	}
	else if (nums1[start1 + pa - 1] > nums2[start2 + pb - 1])
	{
		return FindKth(nums1, start1, len1, nums2, start2 + pb, len2 - pb, k - pb);
	}
	else
	{
		return nums1[pa - 1];
	}
} 

public double FindMedianSortedArrays1(int[] nums1, int[] nums2) {
	int i = 0;
	int j = 0;
	int len1 = nums1.Length;
	int len2 = nums2.Length;
	int[] temp = new int[len1 + len2];
	
	for (int k = 0; k < temp.Length; k++)
	{
		if(i >= len1)
		{
			temp[k] = nums2[j++];
		}
		else if(j >= len2)
		{
			temp[k] = nums1[i++];
		}
		else if(nums1[i] < nums2[j])
		{
			temp[k] = nums1[i++];
		}
		else
		{
			temp[k] = nums2[j++];
		}
	}
	
	if(temp.Length % 2 == 0)
	{
		int n = temp.Length/2;
		return (double)(temp[n-1] + temp[n])/2;
	}
	else
	{
		int n = temp.Length/2;
		return temp[n];
	}
}