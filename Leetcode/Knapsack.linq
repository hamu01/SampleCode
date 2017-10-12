<Query Kind="Program" />

void Main()
{
	int n = 5;
	int[] prices = new int[] { 110, 110, 60, 100, 120 };
	int[] weights = new int[] { 60, 60, 10, 20, 30 };
	int W = 50;
	Solution solution = new Solution(weights, prices, n);
	solution.Knapsack(W).Dump();
}

public class Solution {	
	private int[] _weights;
	private int[] _prices;
//	private int _totalWeight;
	private int _n;
	
	public Solution(int[] weights, int[] prices, int n)
	{
		_weights = weights;
		_prices = prices;
		_n = n;
	}
	   public int Knapsack(int totalWeight)
		{
			return F(_n - 1, totalWeight, 0);
		}

		private int F(int i, int totalWeight, int dent)
		{
			string dentStr = "";
			for (int k = 0; k < dent; k++)
			{
				dentStr += " ";
			}
			Console.WriteLine("{2}i = {0}, totalWeight = {1}", i, totalWeight, dentStr);
			int price;
			if (totalWeight <= 0)
			{
				price = 0;
			}
			else if (i == 0)
			{
				if (_weights[i] <= totalWeight)
				{
					price = _prices[0];
				}
				else
				{
					price = 0;
				}
			}
			else
			{
				dent++;
				int price1 = F(i - 1, totalWeight, dent);
				if(totalWeight >= _weights[i])
				{
					int price2 = F(i - 1, totalWeight - _weights[i], dent) + _prices[i];
					price = Math.Max(price1, price2);
				}
				else
				{
					price = price1;
				}
			}

			Console.WriteLine("{4}i = {0}, totalWeight = {1}, _prices[i]={2} total price={3}", i, totalWeight, _prices[i], price, dentStr);
			return price;
		}
}