using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace BinaryTree
{
    public class SymmetricTreeSample
    {
        public void Run()
        {
            SymmetricTree symmetric = new SymmetricTree();

            Node n = new Node(1);
            System.Console.WriteLine("IsSymmetricWithCol:{0}", symmetric.IsSymmetricWithCol(n));

            n = new Node(1);
            n.Left = new Node(2);
            n.Right = new Node(2);
            n.Left.Right = new Node(3);
            n.Right.Right = new Node(3);
            System.Console.WriteLine("IsSymmetricWithCol:{0}", symmetric.IsSymmetricWithCol(n));

            n = new Node(1);
            n.Left = new Node(2);
            n.Right = new Node(2);
            n.Left.Left = new Node(3);
            n.Right.Right = new Node(3);
            System.Console.WriteLine("IsSymmetricWithCol:{0}", symmetric.IsSymmetricWithCol(n));
        }
    }

    public class SymmetricTree
    {
        public bool IsSymmetricWithCol(Node n)
        {
            List<Node> row = new List<Node>();
            row.Add(n);
            while (row.Count > 0)
            {
                List<Node> newRow = new List<Node>();
                int total = 0;
                foreach (var node in row)
                {
                    total += node.Col;
                    if (node.Left != null)
                    {
                        node.Left.Col = node.Col - 1;
                        newRow.Add(node.Left);
                    }
                    if (node.Right != null)
                    {
                        node.Right.Col = node.Col + 1;
                        newRow.Add(node.Right);
                    }
                }
                if (total != 0) return false;
                row = newRow;
            }
            return true;
        }
    }
}