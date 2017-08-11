<Query Kind="Program" />

void Main()
{
//	Run();
//	Time("normal");
//	Time("reverse");
	Time("random", 1, 1000000);
}

public void Run() {
	int length = 10;
	int[] a = GetArray("random", length);
	string.Join(",", a).Dump();
	Sort(a);
	Assert(a).Dump();
	string.Join(",", a).Dump();
}

public void Time(string sortType, int count = 100, int length = 10000) {
	long total = 0;
	for (int j = 0; j < count; j++)
	{
		int[] a = GetArray(sortType, length);
		Stopwatch watch = Stopwatch.StartNew();
		Sort(a);
		long elapsed = watch.ElapsedMilliseconds;
		total += elapsed;
	}
	string.Format("sort {0} elements need {1} ms in average of {2}", length, total/count, sortType).Dump();
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