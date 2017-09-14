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
	int length = 20;
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

public void Sort(int[] a) {
//	IMinPQ pg = new MinUnorderArrayPQ(a.Length);
//	IMinPQ pg = new MinOrderArrayPQ(a.Length);
	IMinPQ pg = new MinHeapPQ(a.Length);
	for (int i = 0; i < a.Length; i++)
	{
		pg.Insert(a[i]);
	}
	for (int i = 0; i < a.Length; i++)
	{
		a[i] = pg.RemoveMin();
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

public interface IMinPQ
{
	void Insert(int i);

	int RemoveMin();

	int Size();

	bool IsEmpty();
}

public class MinHeapPQ : IMinPQ
{
	private int[] pq;

	private int len = 1;

	public MinHeapPQ(int max)
	{
		pq = new int[max + 1];
	}

	public void Insert(int i)
	{
		pq[len++] = i;
		Swim(len - 1);
	}

	public int RemoveMin()
	{
		if (len <= 1)
		{
			throw new InvalidOperationException("pq is empty, can not remove");
		}
		int min = pq[1];
		pq[1] = pq[len - 1];
		pq[len - 1] = min;
		pq[--len] = 0;
		Sink(1);
		return min;
	}

	public int Size()
	{
		return len-1;
	}

	public bool IsEmpty()
	{
		return len <= 1;
	}

	private void Swim(int k)
	{
		while (k > 1 && pq[k] < pq[k / 2])
		{
			int temp = pq[k];
			pq[k] = pq[k / 2];
			pq[k / 2] = temp;
			k = k / 2;
		}
	}

	private void Sink(int k)
	{
		while (2 * k < len)
		{
			int j = 2 * k;
			if (j + 1 < len && pq[j+1] < pq[j])
			{
				j = j + 1;
			}
			if (pq[k] > pq[j])
			{
				int temp = pq[k];
				pq[k] = pq[j];
				pq[j] = temp;
			}
			else
			{
				break;
			}
			k = j;
		}
	}
}

public class MinUnorderArrayPQ : IMinPQ
{
	private int[] a;

	private int len;

	public MinUnorderArrayPQ(int max)
	{
		a = new int[max];
	}

	public void Insert(int i)
	{
		a[len++] = i;
	}

	public int RemoveMin()
	{
		if (len <= 0)
		{
			throw new InvalidOperationException("pq is empty, can not remove");
		}
		int min = 0;
		for (int i = 1; i < len; i++)
		{
			if (a[i] < a[min])
			{
				min = i;
			}
		}
		int minValue = a[min];
		a[min] = a[len - 1];
		a[len - 1] = minValue;
		len--;
		return minValue;
	}

	public int Size()
	{
		return len;
	}

	public bool IsEmpty()
	{
		return len <= 0;
	}
}

public class MinOrderArrayPQ : IMinPQ
{
	private int[] a;

	private int len;

	public MinOrderArrayPQ(int max)
	{
		a = new int[max];
	}

	public void Insert(int i)
	{
		a[len++] = i;
		for (int j = len-1; j > 0; j--)
		{
			if (a[j] > a[j-1])
			{
				int temp = a[j];
				a[j] = a[j - 1];
				a[j - 1] = temp;
			}
			else
			{
				break;
			}
		}
		
	}

	public int RemoveMin()
	{
		return a[--len];
	}

	public int Size()
	{
		return len;
	}

	public bool IsEmpty()
	{
		return len <= 0;
	}
}