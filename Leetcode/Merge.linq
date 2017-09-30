<Query Kind="Program" />

void Main()
{
	int[] nums1 = new int[20];
	int[] nums2 = new int[5];
	for (int i = 0; i < 5; i++)
	{
		nums1[i] = i+1;
		nums2[i] = 2*(i+1);
	}
	Merge(nums1, 5, nums2, 5);
	for (int i = 0; i < 9; i++)
	{
		Console.Write(nums1[i] + ",");
	}
	Console.WriteLine(nums1[9]);
}

public void Merge(int[] nums1, int m, int[] nums2, int n) {
	int[] aud = new int[m+n];
	for (int i = 0; i < m; i++)
	{
		aud[i] = nums1[i];
	}
	for (int i = m; i < m + n; i++)
	{
		aud[i] = nums2[i -m];
	}
	int l = 0;
	int j = m;
	for (int k = 0; k < m+n; k++)
	{
		if(l >= m) {
			nums1[k] = aud[j++];
		}
		else if(j>=m+n) {
			nums1[k] = aud[l++];
		}
		else if(aud[l] < aud[j]) {
			nums1[k] = aud[l++];
		}
		else {
			nums1[k] = aud[j++];
		}
	}
}

public void Merge1(int[] nums1, int m, int[] nums2, int n) {
	for (int i = m; i < m + n; i++)
	{
		nums1[i] = nums2[i -m];
	}
	Sort(nums1, m+n);
}

private void Sort(int[] a, int N) {
	int h = 1;
	while (h < N / 3)
	{
		h = 3 * h + 1;
	}
	while (h >= 1)
	{
		for (int i = h; i < N; i++)
		{
			for (int j = i; j >= h; j -= h)
			{
				if (a[j] > a[j - h])
				{
					break;
				}
				else
				{
					int temp = a[j];
					a[j] = a[j - h];
					a[j - h] = temp;
				}
			}
		}
		h = h / 3;
	}
}