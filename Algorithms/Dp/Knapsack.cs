using System;

namespace Dp
{
    public class KnapsackSample
    {
        public void Run()
        {
            int n = 5;
            int[] prices = new int[] { 100, 50, 120, 30, 60 };
            int[] weights = new int[] { 1, 2, 5, 3, 2 };
            Console.WriteLine($"Weights: {string.Join(",", weights)}");
            Console.WriteLine($"Prices: {string.Join(",", prices)}");
            Knapsack knapsack = new Knapsack(prices, weights, n);
            int totalWeight = 5;
            int totalPrice = knapsack.Pack01WithRecur(totalWeight);
            Console.WriteLine($"Pick01WithRecur: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01(totalWeight);
            Console.WriteLine($"Pick01: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01WithOpt(totalWeight);
            Console.WriteLine($"Pack01WithOpt: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01WithOpt1(totalWeight);
            Console.WriteLine($"Pack01WithOpt1: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01Exact(totalWeight);
            Console.WriteLine($"Pick01Exact: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01ExactWithOpt(totalWeight);
            Console.WriteLine($"Pack01ExactWithOpt: {totalWeight} - {totalPrice}");
            Console.WriteLine();

            prices = new int[] { 100, 50, 120, 30, 60 };
            weights = new int[] { 1, 2, 5, 3, 3 };
            Console.WriteLine($"Weights: {string.Join(",", weights)}");
            Console.WriteLine($"Prices: {string.Join(",", prices)}");
            knapsack = new Knapsack(prices, weights, n);
            totalPrice = knapsack.Pack01WithRecur(totalWeight);
            Console.WriteLine($"Pick01WithRecur: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01(totalWeight);
            Console.WriteLine($"Pick01: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01WithOpt(totalWeight);
            Console.WriteLine($"Pack01WithOpt: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01WithOpt1(totalWeight);
            Console.WriteLine($"Pack01WithOpt1: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01Exact(totalWeight);
            Console.WriteLine($"Pick01Exact: {totalWeight} - {totalPrice}");
            totalPrice = knapsack.Pack01ExactWithOpt(totalWeight);
            Console.WriteLine($"Pack01ExactWithOpt: {totalWeight} - {totalPrice}");
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

        public int Pack01(int totalWeight)
        {
            int[,] matrix = new int[_n + 1, totalWeight + 1];
            for (int i = 1; i <= _n; i++)
            {
                for (int j = 1; j <= totalWeight; j++)
                {
                    int w = _weights[i - 1];
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
            return matrix[_n, totalWeight];
        }

        public int Pack01WithRecur(int totalWeight)
        {
            return Pack01WithRecur(totalWeight, _n - 1);
        }

        private int Pack01WithRecur(int totalWeight, int i)
        {
            if (i < 0) return 0;
            if (_weights[i] > totalWeight)
            {
                return Pack01WithRecur(totalWeight, i - 1);
            }
            return Math.Max(Pack01WithRecur(totalWeight, i - 1), _prices[i] + Pack01WithRecur(totalWeight - _weights[i], i - 1));
        }

        public int Pack01WithOpt(int totalWeight)
        {
            int[] matrix = new int[totalWeight + 1];
            for (int i = 1; i <= _n; i++)
            {
                for (int j = totalWeight; j >= 0; j--)
                {
                    int w = _weights[i - 1];
                    if (w <= j)
                    {
                        matrix[j] = Math.Max(matrix[j - w] + _prices[i - 1], matrix[j]);
                    }
                }
            }
            return matrix[totalWeight];
        }

        public int Pack01WithOpt1(int totalWeight)
        {
            int[] matrix = new int[totalWeight + 1];
            for (int i = 1; i <= _n; i++)
            {
                int sum = Sum(_weights, i + 1, _n);
                int bound = Math.Max(totalWeight - sum, _weights[i - 1]);
                for (int j = totalWeight; j >= bound; j--)
                {
                    int w = _weights[i - 1];
                    if (w <= j)
                    {
                        matrix[j] = Math.Max(matrix[j - w] + _prices[i - 1], matrix[j]);
                    }
                }
            }
            return matrix[totalWeight];
        }

        private int Sum(int[] values, int lo, int hi)
        {
            int sum = 0;
            for (int i = lo; i <= hi; i++)
            {
                sum += values[i - 1];
            }
            return sum;
        }

        public int Pack01Exact(int totalWeight)
        {
            int[,] matrix = new int[_n + 1, totalWeight + 1];
            for (int i = 1; i < totalWeight + 1; i++)
            {
                matrix[0, i] = int.MinValue;
            }
            for (int i = 1; i <= _n; i++)
            {
                for (int j = 1; j <= totalWeight; j++)
                {
                    int w = _weights[i - 1];
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
            if (matrix[_n, totalWeight] > 0)
            {
                return matrix[_n, totalWeight];
            }
            return 0;
        }

        public int Pack01ExactWithOpt(int totalWeight)
        {
            int[] matrix = new int[totalWeight + 1];
            for (int i = 1; i < totalWeight + 1; i++)
            {
                matrix[i] = int.MinValue;
            }
            for (int i = 1; i <= _n; i++)
            {
                for (int j = totalWeight; j >= 0; j--)
                {
                    int w = _weights[i - 1];
                    if (w <= j)
                    {
                        matrix[j] = Math.Max(matrix[j - w] + _prices[i - 1], matrix[j]);
                    }
                }
            }
            if (matrix[totalWeight] > 0)
            {
                return matrix[totalWeight];
            }
            return 0;
        }

        public int PackLimited(int totalWeight, int max)
        {
            throw new NotImplementedException();
        }

        public int PackLimitedExact(int totalWeight, int max)
        {
            throw new NotImplementedException();
        }

        public int PackUnlimited(int totalWeight)
        {
            throw new NotImplementedException();
        }

        public int PackUnlimitedExact(int totalWeight)
        {
            throw new NotImplementedException();
        }
    }
}