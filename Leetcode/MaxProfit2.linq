<Query Kind="Program" />

void Main()
{
	MaxProfit(new int[]{}).Dump();
	MaxProfit(new int[]{1}).Dump();
	MaxProfit(new int[]{2, 1}).Dump();
	MaxProfit(new int[]{2, 1, 2, 0, 1}).Dump();
	MaxProfit(new int[]{2, 1, 2, 0, 5, 3, 2}).Dump();
	MaxProfit(new int[]{7, 1, 5, 3, 6, 4}).Dump();
	MaxProfit(new int[]{1, 2, 4}).Dump();
}

public int MaxProfit(int[] prices)
{
	int maxProfit = 0;
	for (int i = prices.Length - 1; i > 0; i--)
	{
		if(prices[i] > prices[i-1])
		{
			maxProfit += prices[i] - prices[i-1];
		}
	}
	return maxProfit;
}