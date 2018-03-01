using System;
using System.Text;

namespace Matrix
{
    public class Common
    {
        public static void Print(int[] values)
        {
            Console.WriteLine(string.Join(",", values));
        }

        public static void Print(int[,] values)
        {
            for (int i = 0; i < values.GetLength(0); i++)
            {
                StringBuilder builder = new StringBuilder();
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    builder.Append(values[i, j]).Append(",");
                }
                builder.Remove(builder.Length - 1, 0);
                Console.WriteLine(builder);
            }
        }
    }
}