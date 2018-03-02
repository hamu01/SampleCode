using System;

namespace Matrix
{
    public class SearchSample
    {
        public void Run()
        {
            Search search = new Search();
            // int[,] matrix = Common.GetMatrix(3, 3, "row");
            int[,] matrix = new int[1, 0];
            // Common.Print(matrix);
            int target = 1;
            var location = search.SearchInRowOrder(matrix, target);
            Console.WriteLine($"{target} in x={location.Item1}, y={location.Item2}");

            target = 3;
            location = search.SearchInRowOrder(matrix, target);
            Console.WriteLine($"{target} in x={location.Item1}, y={location.Item2}");
        }
    }

    public class Search
    {
        public Tuple<int, int> SearchInRowOrder(int[,] matrix, int target)
        {
            int x = BinarySearchInColumn(matrix, 0, matrix.GetLength(0) - 1, target);
            int y = -1;
            if (x >= 0)
            {
                y = BinarySearchInRow(matrix, x, 0, matrix.GetLength(1) - 1, target);
            }
            return new Tuple<int, int>(x, y);
        }

        private int BinarySearchInColumn(int[,] matrix, int startX, int endX, int target)
        {
            if (startX > endX || matrix.GetLength(1) == 0) return -1;
            int x = (startX + endX) / 2;
            int startY = 0;
            int endY = matrix.GetLength(1) - 1;
            if (target < matrix[x, startY])
            {
                return BinarySearchInColumn(matrix, startX, x - 1, target);
            }
            else if (target > matrix[x, endY])
            {
                return BinarySearchInColumn(matrix, x + 1, endX, target);
            }
            else
            {
                return x;
            }
        }

        private int BinarySearchInRow(int[,] matrix, int x, int startY, int endY, int target)
        {
            if (startY > endY) return -1;
            int y = (startY + endY) / 2;
            if (target > matrix[x, y])
            {
                return BinarySearchInRow(matrix, x, y + 1, endY, target);
            }
            else if (target < matrix[x, y])
            {
                return BinarySearchInRow(matrix, x, startY, y - 1, target);
            }
            else
            {
                return y;
            }
        }
    }
}