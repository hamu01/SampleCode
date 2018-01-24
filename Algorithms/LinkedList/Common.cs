using System;
using System.Text;

namespace LinkedList
{
    public static class Common
    {
        public static Node BuildList(int[] values)
        {
            if (values.Length == 0) return null;
            Node start = new Node(values[0]);
            Node n = start;
            for (int i = 1; i < values.Length; i++)
            {
                n.Next = new Node(values[i]);
                n = n.Next;
            }
            return start;
        }

        public static void PrintList(Node start, string pre)
        {
            string s = ToString(start);
            Console.WriteLine(pre + s);
        }

        public static string ToString(Node start)
        {
            if (start == null) return "null";
            StringBuilder builder = new StringBuilder();
            Node n = start;
            while (n != null)
            {
                builder.Append(n.V).Append("->");
                n = n.Next;
            }
            builder.Remove(builder.Length - 2, 2);
            return builder.ToString();
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(",", matrix[i]));
            }
        }
    }
}