<Query Kind="Program" />

void Main()
{
//	var heights = new int[]{1,3,7,8,2};
	int h = 100000;
	var heights = new int[h];
	for (int i = 0; i < h; i++)
	{
		heights[i] = i;
	}
	MaxArea(heights).Dump();
//	MaxArea1(heights).Dump();
}

public int MaxArea(int[] height) {
	int maxarea = 0;
	int lo = 0;
	int hi = height.Length - 1;
	while (lo < hi) {
		maxarea = Math.Max(maxarea, Math.Min(height[lo], height[hi]) * (hi - lo));
		if (height[lo] < height[hi])
		{
			lo++;
		}
		else
		{
			hi--;
		}
	}
	return maxarea;
}

public int MaxArea1(int[] height) {
	var max = 0;
	for (int i = 1; i < height.Length; i++)
	{
		for (int j = 1; j <= i; j++)
		{
			var h = Math.Min(height[i],height[i-j]);
			var area = h*j;
			if(max < area)
			{
				max = area;
			}
		}
	}
	return max;
}