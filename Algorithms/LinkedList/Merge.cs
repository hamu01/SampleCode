using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class MergeSample
    {
        public void Run()
        {
            Merge merge = new Merge();
            Node node1 = Common.BuildList(new int[] { 1, 3, 7, 12, 42 });
            Node node2 = Common.BuildList(new int[] { 7, 12, 18, 42, 53, 62, 97 });
            Node node3 = Common.BuildList(new int[] { 1, 30 });
            var n = merge.MergeKLists(new List<Node>() { node1, node2, node3 });
            Common.PrintList(n, "");
        }
    }

    public class Merge
    {
        public Node MergeKLists(List<Node> lists)
        {
            Node head = new Node(-1);
            Node n = head;
            while (lists.Count > 0)
            {
                int min = 0;
                for (int i = 1; i < lists.Count; i++)
                {
                    if (lists[i].V < lists[min].V)
                    {
                        min = i;
                    }
                }
                n.Next = lists[min];
                if (lists[min].Next == null)
                {
                    lists.RemoveAt(min);
                }
                else
                {
                    lists[min] = lists[min].Next;
                }
                n = n.Next;
            }
            return head.Next;
        }
    }
}