<Query Kind="Program" />

void Main()
{
	Run();
	Time("normal");
	Time("reverse");
	Time("random");
}

public void Run() {
	int length = 100;
	int[] a = GetArray("random", length);
	string.Join(",", a).Dump();
	Sort(a);
	Assert(a).Dump();
	string.Join(",", a).Dump();
}

public void Time(string sortType){
	long total = 0;
	int count = 100;
	int length = 10000;
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

// 最好情况下：compare: 1+2+...+ (n-1) = (n-1)*(n-2)/2, exchange: 0
public void MySort(int[] a) {
	for (int i = 1; i < a.Length; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if(a[i] < a[j]) {
				int temp = a[i];
				a[i] = a[j];
				a[j] = temp;
			}
		}
	}
}

// 最好情况下：compare: n-1, exchange: 0
public void Sort(int[] a) {
	for (int i = 1; i < a.Length; i++)
	{
		for (int j = i; j > 0; j--)
		{
			if(a[j] < a[j-1]) {
				int temp = a[j];
				a[j] = a[j-1];
				a[j-1] = temp;
			}
			else {
				break;
			}
		}
	}
}

public bool Assert(int[] a) {
	for (int i = 1; i < a.Length - 1; i++)
	{
		if(a[i-1] > a[i] || a[i] > a[i+1]) {
			return false;
		}
	}
	return true;
}