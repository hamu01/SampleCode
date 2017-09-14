<Query Kind="Program" />

void Main()
{
//	Run();
//	Time("normal");
//	Time("reverse");
	Time("random", 1, 10000000);
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
	for (int i = 0; i < count; i++)
	{
		int[] a = GetArray(sortType, length);
		Stopwatch watch = Stopwatch.StartNew();
		Sort(a);
		total += watch.ElapsedMilliseconds;
	}
	string.Format("sort {0} elements need {1} ms in average of {2}", length, total/count, sortType).Dump();
}

public void MySort(int[] a) {
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

public void Sort(int[] a) {
	// Sort a[] into increasing order.
	int N = a.Length;
	int h = 1;
	// 1, 4, 13, 40, 121, 364, 1093, ...
	while (h < N/3) {
		h = 3*h + 1; 
	}
	while (h >= 1)
	{ 
		// h-sort the array.
		for (int i = h; i < N; i++) { 
			// Insert a[i] among a[i-h], a[i-2*h], a[i-3*h]... .
			for (int j = i; j >= h; j -= h) {
				if(a[j] > a[j-h]) {
					break;
				}
				else {
					int temp = a[j];
					a[j] = a[j-h];
					a[j-h] = temp;
				}
			}
		}
		h = h/3;
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