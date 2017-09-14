<Query Kind="Program" />

void Main()
{
//	Run();
//	Time("normal");
//	Time("reverse");
//	Time("random");
	Time("normal", 1, 10000000);
	Time("reverse", 1, 10000000);
	Time("random", 1, 10000000);
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

private int[] aud;

public void Sort(int[] a) {
	aud = new int[a.Length];
	Sort(a, 0, a.Length-1);
}

private void Sort(int[] a, int low, int high) {
	if(low >= high) {
		return;
	}
	int middle = (low+high) / 2;
	Sort(a, low, middle);
	Sort(a, middle+1, high);
	if(a[middle] > a[middle+1]) {
		if(high - low > 2) {
			Merge(a, low, middle, high);
		}
		else {
			InsertionSort(a, low, high);
		}
	}
}

private void Merge(int[] a, int low, int middle, int high) {
	int i = low;
	int j = middle + 1;
	for (int k = low; k <= high; k++)
	{
		aud[k] = a[k];
	}
	for (int k = low; k <= high; k++)
	{
		if(i > middle) {
			a[k] = aud[j++];
		}
		else if(j > high) {
			a[k] = aud[i++];
		}
		else if(aud[i] < aud[j]) {
			a[k] = aud[i++];
		}
		else {
			a[k] = aud[j++];
		}
	}
}

public void InsertionSort(int[] a, int low, int high) {
	for (int i = low+1; i < high+1; i++)
	{
		for (int j = i; j > low; j--)
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