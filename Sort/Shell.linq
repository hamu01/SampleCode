<Query Kind="Program" />

void Main()
{
	Run();
	Time("normal");
	Time("reverse");
	Time("random");
}

public void Run() {
	int length = 20;
	int[] a = GetArray("random", length);
	string.Join(",", a).Dump();
	Sort(a);
	Assert(a).Dump();
	string.Join(",", a).Dump();
}

public void Time(string sortType) {
	long total = 0;
	int count = 100;
	int length = 10000;
	for (int i = 0; i < count; i++)
	{
		int[] a = GetArray(sortType, length);
		Stopwatch watch = Stopwatch.StartNew();
		Sort(a);
		total += watch.ElapsedMilliseconds;
	}
	string.Format("sort {0} elements need {1} ms in average of {2}", length, total/count, sortType).Dump();
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