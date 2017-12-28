<Query Kind="Program" />

void Main()
{
	Test();
//	PerfTest(30);
}

private void Test()
{
	int n = 5;
	int[] prices = new int[] { 110, 110, 60, 200, 1200 };
	int[] weights = new int[] { 60, 60, 10, 20, 30 };

	int W = 50;
	Solution solution = new Solution(weights, prices, n);
//	solution.Knapsack_Recur(W).Dump();
	solution.Knapsack(W).Dump();
}

private void PerfTest(int n)
{
	Random random = new Random();
	int[] prices = new int[n];
	for (int i = 0; i < n; i++)
	{
		prices[i] = random.Next(10, 1000);
	}
	int[] weights = new int[n];
	for (int i = 0; i < n; i++)
	{
		weights[i] = random.Next(1, 100)*10;
	}
	
	int total = random.Next(5,10);
	int totalWeight = 0;
	int totalPrice = 0;
	for (int i = 0; i < total; i++)
	{
		int index = random.Next(0,n);
		totalWeight += weights[index];
	}
	("Total Weight: " + totalWeight).Dump();
	Solution solution = new Solution(weights, prices, n);
//	solution.Knapsack(totalWeight).Dump();
	solution.Knapsack_Recur(totalWeight).Dump();
}

public class Solution {	
	private int[] _weights;
	private int[] _prices;
	private int _n;
	
	public Solution(int[] weights, int[] prices, int n)
	{
		_weights = weights;
		_prices = prices;
		_n = n;
	}
	
	public int Knapsack(int weight)
	{
		int[] bag = new int[weight+1];
		for (int w = 1; w < weight+1; w++)
		{
			int p1 = bag[w-1];
			int max = 0;
			for (int j = 0; j < _n; j++)
			{
				if(w >= _weights[j])
				{
					int p = bag[w-_weights[j]] + _prices[j];
					if(max < p)
					{
						max = p;
					}
				}
			}
			bag[w] = Math.Max(p1, max);
		}
		return bag[weight];
	}
	
	public int Knapsack_Recur(int w)
	{
		if(w <= 0)
		{
			return 0;
		}
		int k1 = Knapsack_Recur(w-1);
		int maxK=0;
		for (int i = 0; i < _n; i++)
		{
			if(w >= _weights[i])
			{
				int k2 = Knapsack_Recur(w - _weights[i]) + _prices[i];
				if(maxK < k2)
				{
					maxK = k2;
				}
			}
		}
		return Math.Max(k1, maxK);
	}
}