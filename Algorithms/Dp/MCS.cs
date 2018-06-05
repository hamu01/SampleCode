using System;
using System.Collections.Generic;

namespace Dp
{
    public class MCSSample
    {
        public void Run()
        {
            MCS mcs = new MCS();
            int[] matrix;
            int min;
            matrix = new int[] { 10, 30, 5, 60 };
            min = mcs.MatrixChainOrderWithRecur(matrix);
            Console.WriteLine($"The min of {string.Join(",", matrix)} is {min}");
            matrix = new int[] { 4, 2, 3, 1, 3, 5, 6 };
            min = mcs.MatrixChainOrderWithRecur(matrix);
            Console.WriteLine($"The min of {string.Join(",", matrix)} is {min}");
        }
    }

    public class MCS
    {
        public int MatrixChainOrderWithRecur(int[] matrix)
        {
            int min = int.MaxValue;
            var matrixList = new List<int>(matrix);
            for (int i = 1; i < matrix.Length - 1; i++)
            {
                int times = MatrixChainOrderWithRecur(matrixList, i);
                if (times < min)
                {
                    min = times;
                }
            }
            return min;
        }

        private int MatrixChainOrderWithRecur(List<int> matrix, int i)
        {
            int times = matrix[i - 1] * matrix[i] * matrix[i + 1];
            if (matrix.Count == 3)
            {
                return times;
            }
            int temp = matrix[i];
            matrix.RemoveAt(i);
            int min = int.MaxValue;
            for (int j = 1; j < matrix.Count - 1; j++)
            {
                int val = MatrixChainOrderWithRecur(matrix, j);
                if (val < min)
                {
                    min = val;
                }
            }
            matrix.Insert(i, temp);
            return times + min;
        }

        public int MatrixChainOrder(int[] matrix)
        {
            throw new NotImplementedException();
        }
    }
}