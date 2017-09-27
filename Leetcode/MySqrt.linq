<Query Kind="Program" />

void Main()
{
	Sqrt(10).Dump();
	MySqrt(10).Dump();
	Math.Sqrt(10).Dump();
}

public double MySqrt(int x) {
	double g=x;
	while(Math.Abs(g*g-x)>0.000001)
	{
		g=(g+x/g)/2;
	}
	return g;		
}

public int Sqrt(int x) {
	if (x == 0) {
		return 0;
	}
	int left = 1, right = int.MaxValue;
	while (true) {
		int mid = left + (right - left)/2;
		if (mid > x/mid) {
			right = mid - 1;
		} else {
			if (mid + 1 > x/(mid + 1)) {
				return mid; 
			}
			left = mid + 1;
		}
	}
}