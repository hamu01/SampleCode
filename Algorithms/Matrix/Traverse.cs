using System;

namespace Matrix
{
    public class TraverseSample
    {
        public void Run()
        {
            int[,] matrix = GetMatrix(10, 1);

            Console.WriteLine("Matrix: ");
            Common.Print(matrix);

            Traverse traverse = new Traverse();

            // Console.WriteLine("Row Order: ");
            // int[] rowValues = traverse.Row(matrix);
            // Common.Print(rowValues);

            // Console.WriteLine("Column Order: ");
            // int[] columnValues = traverse.Column(matrix);
            // Common.Print(columnValues);

            // Console.WriteLine("Diagonal Order: ");
            // int[] diagonalValues = traverse.Diagonal(matrix);
            // Common.Print(diagonalValues);

            // Console.WriteLine("Reverse Diagonal Order: ");
            // int[] reverseDiagonalValues = traverse.ReverseDiagonal(matrix);
            // Common.Print(reverseDiagonalValues);

            Console.WriteLine("Spiral Order: ");
            int[] spiralValues = traverse.Spiral(matrix);
            Common.Print(spiralValues);
        }

        private int[,] GetMatrix(int row, int col)
        {
            int[,] matrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = i * matrix.GetLength(0) + j + 1;
                }
            }
            return matrix;
        }
    }

    public class Traverse
    {
        public int[] Row(int[,] matrix)
        {
            int[] values = new int[matrix.Length];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    values[i * matrix.GetLength(1) + j] = matrix[i, j];
                }
            }
            return values;
        }

        public int[] Column(int[,] matrix)
        {
            int[] values = new int[matrix.Length];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    values[i * matrix.GetLength(0) + j] = matrix[j, i];
                }
            }
            return values;
        }

        public int[] Diagonal(int[,] matrix)
        {
            int[] values = new int[matrix.Length];
            int k = 0;
            int m = 0, n = matrix.GetLength(1) - 1;
            while (m < matrix.GetLength(0))
            {
                int i = m, j = n;
                while (i < matrix.GetLength(0) && j < matrix.GetLength(1))
                {
                    values[k++] = matrix[i++, j++];
                }
                if (--n < 0)
                {
                    m++;
                    n = 0;
                }
            }
            return values;
        }

        public int[] ReverseDiagonal(int[,] matrix)
        {
            int[] values = new int[matrix.Length];
            int k = 0;
            int m = 0, n = 0;
            while (m < matrix.GetLength(0))
            {
                int i = m, j = n;
                while (i < matrix.GetLength(0) && j >= 0)
                {
                    values[k++] = matrix[i++, j--];
                }
                if (++n >= matrix.GetLength(1))
                {
                    m++;
                    n = matrix.GetLength(1) - 1;
                }
            }
            return values;
        }

        public int[] Spiral(int[,] matrix)
        {
            int[] values = new int[matrix.Length];
            if (matrix.GetLength(0) == 1)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    values[i] = matrix[0, i];
                }
                return values;
            }
            if (matrix.GetLength(1) == 1)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    values[i] = matrix[i, 0];
                }
                return values;
            }
            int ox = 0, oy = 0, k = 0, len = 0, level = 0;
            do
            {
                len = 0;
                int i = ox, j = oy;
                while (j < matrix.GetLength(1) - level)
                {
                    values[k++] = matrix[i, j++];
                    len++;
                }
                j = matrix.GetLength(1) - level - 1;
                while (++i < matrix.GetLength(0) - level)
                {
                    values[k++] = matrix[i, j];
                    len++;
                }
                i = matrix.GetLength(0) - level - 1;
                while (--j >= level)
                {
                    values[k++] = matrix[i, j];
                    len++;
                }
                j = level;
                while (--i > ox)
                {
                    values[k++] = matrix[i, j];
                    len++;
                }
                level++;
                ox++;
                oy = j + 1;
            }
            while (len > 8);
            if (len == 8)
            {
                values[k++] = matrix[ox, oy];
            }
            return values;
        }
    }
}