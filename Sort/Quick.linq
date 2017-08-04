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
	int length = a.Length;
	int middle = length/2;
	while(length > 0) {
		for (int i = 0; i < middle; i++)
		{
			if(a[i] > a[middle]) {
				
			}
		}
		for (int i = middle+1; i < length; i++)
		{
			if(a[i] < a[middle]) {
				
			}
		}
		length = length / 2;
		middle = length - length/2;
		middle = length + length/2;
	}
}

private void Partition() {

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