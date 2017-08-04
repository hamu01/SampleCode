<Query Kind="Program" />

void Main()
{
	int length = 10;
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

// Define other methods and classes here
public bool Assert(int[] a) {
	for (int i = 1; i < a.Length-1; i++)
	{
		if(a[i-1] > a[i] || a[i] > a[i+1]) {
			return false;
		}
	}
	return true;
}

public void Sort(int[] a) {
	for (int i = 0; i < a.Length; i++)
	{
		for (int j = a.Length-1; j > i; j--)
		{
			if(a[j] < a[j-1]) {
				int temp = a[j-1];
				a[j-1] = a[j];
				a[j] = temp;
			}
		}
	}
}