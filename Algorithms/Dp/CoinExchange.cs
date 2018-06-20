using System;
using System.Collections.Generic;

namespace Dp
{
    public class CoinExchangeSample
    {
        public void Run()
        {
            CoinExchange exchange = new CoinExchange();
            int[] coins;
            coins = new int[] { 1, 3, 4 };
            Test(exchange, coins, 6);

            coins = new int[] { 9, 3, 8, 6, 5 };
            Test(exchange, coins, 10);

            for (int i = 0; i < 10; i++)
            {
                coins = GetNums(5);
                int money = 10;
                Test(exchange, coins, money);
            }
        }

        private void Test(CoinExchange exchange, int[] coins, int money)
        {
            int num = exchange.Exchange(coins, money);
            // num = exchange.ExchangeWithRecur(coins, money);
            Console.WriteLine($"coins of ({string.Join(",", coins)}), money of ({money}), the num is {num}");
        }

        private int[] GetNums(int n)
        {
            Random random = new Random();
            HashSet<int> set = new HashSet<int>();
            while (set.Count < n)
            {
                set.Add(random.Next(1, 10));
            }
            int[] nums = new int[n];
            int i = 0;
            foreach (int num in set)
            {
                nums[i++] = num;
            }
            return nums;
        }
    }

    public class CoinExchange
    {
        public int ExchangeWithRecur(int[] coins, int money)
        {
            if (money < 0) return 0;
            int count = 0;
            int min = int.MaxValue;
            foreach (int coin in coins)
            {
                int num = ExchangeWithRecur(coins, money - coin);
                min = Math.Min(min, num);
            }
            return count + min + 1;
        }

        public int Exchange(int[] coins, int money)
        {
            int[] matrix = new int[money + 1];
            for (int i = 1; i <= money; i++)
            {
                int min = int.MaxValue;
                for (int j = 0; j < coins.Length; j++)
                {
                    int num;
                    if (i >= coins[j])
                    {
                        num = matrix[i - coins[j]];
                    }
                    else
                    {
                        num = 0;
                    }
                    min = Math.Min(min, num);
                }
                matrix[i] = min + 1;
            }
            return matrix[money];
        }
    }
}