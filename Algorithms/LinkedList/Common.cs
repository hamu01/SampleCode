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
            if (start == null)
            {
                Console.WriteLine(pre + "null");
                return;
            }
            StringBuilder builder = new StringBuilder();
            builder.Append(pre);
            Node n = start;
            while (n != null)
            {
                builder.Append(n.V).Append("->");
                n = n.Next;
            }
            builder.Remove(builder.Length - 2, 2);
            Console.WriteLine(builder);
        }
    }
}