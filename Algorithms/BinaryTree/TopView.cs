using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class TopViewSample
    {
        public void Run()
        {
            TopView topView = new TopView();
            Node root = BuildTree();
            var nodes = topView.View(root);
            foreach (var node in nodes)
            {
                Console.Write(node.V + " ");
            }
            Console.WriteLine();
        }

        private Node BuildTree()
        {
            // Node root = new Node(1);
            // root.Left = new Node(2);
            // root.Right = new Node(3);
            // root.Left.Right = new Node(4);
            // root.Left.Right.Right = new Node(5);
            // root.Left.Right.Right.Right = new Node(6);

            // Node root = new Node(1);
            // root.Left = new Node(2);
            // root.Right = new Node(3);
            // root.Left.Left = new Node(4);
            // root.Left.Right = new Node(5);
            // root.Right.Left = new Node(6);
            // root.Right.Right = new Node(7);

            Node root = new Node(1);
            root.Left = new Node(2);
            root.Right = new Node(3);
            root.Left.Left = new Node(4);
            root.Left.Left.Left = new Node(5);
            root.Left.Left.Right = new Node(7);
            root.Left.Left.Left.Left = new Node(6);
            root.Left.Left.Left.Right = new Node(8);

            return root;
        }
    }

    public class TopView
    {
        public List<Node> View(Node root)
        {
            List<Node> nodes = new List<Node>();
            nodes.Add(root);
            int left = 0, right = 0;
            Queue<Node> row = new Queue<Node>();
            if (root.Left != null)
            {
                root.Left.Col = root.Col - 1;
                row.Enqueue(root.Left);
            }
            if (root.Right != null)
            {
                root.Right.Col = root.Col + 1;
                row.Enqueue(root.Right);
            }
            while (row.Count > 0)
            {
                Queue<Node> nextRow = new Queue<Node>();
                int i = 0;
                int count = row.Count;
                while (row.Count > 0)
                {
                    var node = row.Dequeue();
                    if (node.Col < left || node.Col > right)
                    {
                        nodes.Add(node);
                    }
                    if (i == 0 && node.Col < left)
                    {
                        left = node.Col;
                    }
                    if (i == count - 1 && node.Col > right)
                    {
                        right = node.Col;
                    }
                    if (node.Left != null)
                    {
                        node.Left.Col = node.Col - 1;
                        nextRow.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        node.Right.Col = node.Col + 1;
                        nextRow.Enqueue(node.Right);
                    }
                    i++;
                }
                row = nextRow;
            }
            return nodes;
        }
    }

    public class Node
    {
        public Node()
        {
        }

        public Node(int v)
        {
            V = v;
        }

        public int V { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Col { get; set; }

        public int State { get; set; }
    }
}