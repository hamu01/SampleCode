<Query Kind="Program" />

void Main()
{
//	Run();
	Time("normal");
	Time("reverse");
	Time("random");
//	Time("normal", 1, 10000000);
//	Time("reverse", 1, 10000000);
//	Time("random", 1, 10000000);
}

public void Run() {
	int length = 16;
	int[] a = GetArray("random", length);
	string.Join(",", a).Dump();
	Sort(a);
	Assert(a).Dump();
	string.Join(",", a).Dump();
}

public void Time(string sortType, int count = 100, int length=10000) {
	long total = 0;
	for (int i = 0; i < count; i++)
	{
		int[] a = GetArray(sortType, length);
		Stopwatch watch = Stopwatch.StartNew();
		Sort(a);
		total += watch.ElapsedMilliseconds;
	}
	string.Format("sort {0} elements need {1} ms in average of {2}", length, total/count, sortType).Dump();
}

private int[] temp;
  
public void Sort(int[] a)
{
 	temp = new int[a.Length];
	for (int k = 0; k < a.Length; k++)
	{
		temp[k] = a[k];
	}
	Sort(a, 0, a.Length - 1);
}

private void Sort(int[] a, int low, int high)
{
	if (low >= high)
	{
		return;
	}
	int j = Partition(a, low, high);
	Sort(a, low, j - 1);
	Sort(a, j + 1, high);
}

private int Partition(int[] a, int low, int high)
{
	int i = low;
	int j = high + 1;
	int result = a[low];
	while (true)
	{
		while (a[++i] < result)
		{
			if (i == high)
			{
				break;
			}
		}
		while (a[--j] > result)
		{
//			if (j == low)
//			{
//				break;
//			}
		}
		if (i >= j)
		{
			break;
		}
		int temp = a[i];
		a[i] = a[j];
		a[j] = temp;
	}
	int temp1 = a[low];
	a[low] = a[j];
	a[j] = temp1;
	return j;
}

private int Partition_Bad(int[] a, int low, int high)
{
	for (int k = low; k < high + 1; k++)
	{
		temp[k] = a[k];
	}
	int result = a[low];
	int i = low;
	int j = high;
	for (int k = low + 1; k < high + 1; k++)
	{
		if(temp[k] <= result)
		{
			a[i++] = temp[k];
		}
		else if (temp[k] > result)
		{
			a[j--] = temp[k];
		}
	}
	a[j] = result;
	return j;
}

public int[] GetArray(string sortType, int length) {
	int[] a = new int[length];
	if(sortType == "random") {
		Random random = new Random();
		for (int i = 0; i < length; i++)
		{
			a[i] = random.Next(10, 1000);
		}
	}
	else if(sortType == "reverse") {
		for (int i = 0; i < length; i++)
		{
			a[i] = length - i;
		}
	}
	else if(sortType == "normal") {
		for (int i = 0; i < length; i++)
		{
			a[i] = i+1;
		}
	}
	return a;
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