<Query Kind="Program" />

void Main()
{
	int length = 20;
	int[] a = new int[length];
	Random random = new Random();
	for (int i = 0; i < length; i++)
	{
		a[i] = random.Next(10, 1000);
	}
	string.Join(",", a).Dump();
	Sort(a);
	Assert(a).Dump();
	string.Join(",", a).Dump();
}

public void Sort(int[] a) {
	int n=1;
	while(2*n + 1 < a.Length) {
		if(a[n-1] > a[2*n-1]) {
		
		}
		if(a[n-1] > a[2*n]) {
		
		}
		n++;
	}
}

public bool Assert(int[] a) {
	for (int i = 1; i < a.Length-1; i++)
	{
		if(a[i-1] > a[i] || a[i] > a[i+1]) {
			return false;
		}
	}
	return true;
}