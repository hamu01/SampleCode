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
	int length = a.Length;
	while(length > 1) {
		length = length / 2;
		for (int i = 0; i < length; i++)
		{
			for (int j = i+length; j < a.Length; j+=length)
			{
				for (int k = i; k < j; k+=length)
				{
					if(a[k] > a[j]) {
						int temp = a[k];
						a[k] = a[j];
						a[j] = temp;
					}
				}
			}
		}
//		string.Join(",", a).Dump();
	}
}