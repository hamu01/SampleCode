using System;

namespace LinkedList
{
    public class Insertion
    {
        public Node InsertLast(Node p, Node n)
        {
            if (p == null) return n;
            Node pn = p;
            while (pn.Next != null)
            {
                pn = pn.Next;
            }
            pn.Next = n;
            return p;
        }
    }
}