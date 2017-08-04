<Query Kind="Program" />

void Main()
{
	//Run();
	Time();
}

public void Run() {
	int length = 100;
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

public void Time(){
	long total = 0;
	int count = 100;
	for (int j = 0; j < count; j++)
	{
		int length = 10000;
		int[] a = new int[length];
		Random random = new Random();
		for (int i = 0; i < length; i++)
		{
			a[i] = random.Next(10, 1000);
		}
		Stopwatch watch = Stopwatch.StartNew();
		Sort(a);
		long elapsed = watch.ElapsedMilliseconds;
		total += elapsed;
	}
	(total/count).Dump();
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