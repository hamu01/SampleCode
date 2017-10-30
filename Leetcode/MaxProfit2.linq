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

public int MaxProfit(int[] prices) {
	if(prices.Length <= 1)
	{
		return 0;
	}
	int totalProfit = 0;
	int min = 0;
	int max = 0;
	for (int i = 1; i < prices.Length; i++)
	{
		if(prices[i] < prices[min])
		{
			min = i;
		}
		if(prices[i] > prices[max])
		{
			max = i;
		}
		else
		{
			min = i;
		}
		if(max < min) 
		{
			max = min;
		}
		else
		{
			totalProfit += prices[max] - prices[min];
		}
	}
	return totalProfit;
}