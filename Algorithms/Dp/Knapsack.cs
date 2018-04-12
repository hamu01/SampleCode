using System;

namespace Dp
{
    public class KnapsackSample
    {
        public void Run()
        {
            int n = 5;
            int[] prices = new int[] { 100, 50, 120, 30, 60 };
            int[] weights = new int[] { 10, 20, 50, 30, 20 };
            Console.WriteLine($"Weights: {string.Join(",", weights)}");
            Console.WriteLine($"Prices: {string.Join(",", prices)}");
            Knapsack knapsack = new Knapsack(prices, weights, n);
            int weight = knapsack.Pick01WithRecur(50);
            Console.WriteLine($"Pick01WithRecur: {weight}");
            weight = knapsack.Pick01(50);
            Console.WriteLine($"Pick01: {weight}");
            weight = knapsack.Pick01Exact(50);
            Console.WriteLine($"Pick01Exact: {weight}");

            prices = new int[] { 100, 50, 120, 30, 60 };
            weights = new int[] { 10, 20, 50, 30, 30 };
            Console.WriteLine($"Weights: {string.Join(",", weights)}");
            Console.WriteLine($"Prices: {string.Join(",", prices)}");
            knapsack = new Knapsack(prices, weights, n);
            weight = knapsack.Pick01WithRecur(50);
            Console.WriteLine($"Pick01WithRecur: {weight}");
            weight = knapsack.Pick01(50);
            Console.WriteLine($"Pick01: {weight}");
            weight = knapsack.Pick01Exact(50);
            Console.WriteLine($"Pick01Exact: {weight}");
        }
    }

    public class Knapsack
    {
        private int[] _prices;
        private int[] _weights;
        private int _n;

        public Knapsack(int[] prices, int[] weights, int n)
        {
            _prices = prices;
            _weights = weights;
            _n = n;
        }

        public int Pick01(int totalWeight)
        {
            int[,] matrix = new int[_n + 1, totalWeight / 10 + 1];
            for (int i = 1; i <= _n; i++)
            {
                for (int j = 1; j <= totalWeight / 10; j++)
                {
                    int w = _weights[i - 1] / 10;
                    if (w <= j)
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j - w] + _prices[i - 1], matrix[i - 1, j]);
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }
            return matrix[_n, totalWeight / 10];
        }

        public int Pick01WithRecur(int totalWeight)
        {
            return Pick01WithRecur(totalWeight, _n - 1);
        }

        private int Pick01WithRecur(int totalWeight, int i)
        {
            if (i < 0) return 0;
            if (_weights[i] > totalWeight)
            {
                return Pick01WithRecur(totalWeight, i - 1);
            }
            return Math.Max(Pick01WithRecur(totalWeight, i - 1), _prices[i] + Pick01WithRecur(totalWeight - _weights[i], i - 1));
        }

        public int Pick01Exact(int totalWeight)
        {
            //TODO
            int[,] matrix = new int[_n + 1, totalWeight / 10 + 1];
            for (int i = 1; i <= _n; i++)
            {
                for (int j = 1; j <= totalWeight / 10; j++)
                {
                    int w = _weights[i - 1] / 10;
                    if (w <= j)
                    {
                        int w1 = i >= 2 ? _weights[i - 2] / 10 : 0;
                        if (w + w1 == j)
                        {
                            matrix[i, j] = Math.Max(matrix[i - 1, j - w] + _prices[i - 1], matrix[i - 1, j]);
                        }
                        else if(w == j)
                        {
                            matrix[i, j] = _prices[i - 1];
                        }
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }
            return matrix[_n, totalWeight / 10];
        }

        public int PickLimited(int totalWeight, int max)
        {
            throw new NotImplementedException();
        }

        public int PickLimitedExact(int totalWeight, int max)
        {
            throw new NotImplementedException();
        }

        public int PickUnlimited(int totalWeight)
        {
            throw new NotImplementedException();
        }

        public int PickUnlimitedExact(int totalWeight)
        {
            throw new NotImplementedException();
        }
    }
}