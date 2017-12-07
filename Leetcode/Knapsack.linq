<Query Kind="Program" />

void Main()
{
//	Test();
	PerfTest(30);
}

private void Test()
{
	int n = 5;
	int[] prices = new int[] { 110, 110, 60, 100, 120 };
	int[] weights = new int[] { 60, 60, 10, 20, 30 };

	int W = 50;
	Solution solution = new Solution(weights, prices, n);
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
	solution.Knapsack(totalWeight).Dump();
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
	
	public int MyKnapsack(int totalWeight)
	{
		return MyKnapsack(_n - 1, totalWeight, 0);
	}
	
	public int Knapsack(int totalWeight)
	{
		var bag = new int[_n+1,totalWeight/10+1];
//		for (int k = 0; k < _bag.GetLength(0); k++)
//		{
//			_bag[k, 0] = 0;
//		}
//		for (int k = 0; k < _bag.GetLength(1); k++)
//		{
//			_bag[0, k] = 0;
//		}
		for (int i = 1; i < bag.GetLength(0); i++)
		{
			for (int j = 1; j < bag.GetLength(1); j++)
			{
				int w = _weights[i-1]/10;
				if(w <= j) {
					bag[i,j] = Math.Max(bag[i-1, j], bag[i-1, j - w] + _prices[i-1]);
				}
				else {
					bag[i,j] = bag[i-1, j];
				}
			}
		}
//		bag.Dump();
		return bag[_n, totalWeight/10];
	}
	
	private int MyKnapsack(int i, int totalWeight, int dent)
	{
		string dentStr = GetDentStr(dent);
//		Console.WriteLine("{2}i = {0}, totalWeight = {1}", i, totalWeight, dentStr);
		int price;
		if (totalWeight <= 0)
		{
			price = 0;
		}
		else if (i == 0 && _weights[i] <= totalWeight)
		{
			price = _prices[0];
		}
		else if (i == 0)
		{
			price = 0;
		}
		else
		{
			dent++;
			int price1 = MyKnapsack(i - 1, totalWeight, dent);
			if(totalWeight >= _weights[i])
			{
				int price2 = MyKnapsack(i - 1, totalWeight - _weights[i], dent) + _prices[i];
				price = Math.Max(price1, price2);
			}
			else
			{
				price = price1;
			}
		}

//		Console.WriteLine("{4}i = {0}, totalWeight = {1}, _prices[i]={2} total price={3}", i, totalWeight, _prices[i], price, dentStr);
		return price;
	}
	
	private string GetDentStr(int dent)
	{
		string dentStr = "";
		for (int k = 0; k < dent; k++)
		{
			dentStr += " ";
		}
		return dentStr;
	}
}