using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class TraverseSample
    {
        public void Run()
        {
            var root = BuildTree();

            Console.WriteLine("Recursive: ");
            RecurTraverse recurTraverse = new RecurTraverse();

            IEnumerable<Node> nodes = recurTraverse.Pre(root);
            PrintNodes(nodes, "Pre");
            nodes = recurTraverse.In(root);
            PrintNodes(nodes, "In");
            nodes = recurTraverse.Post(root);
            PrintNodes(nodes, "Post");

            Console.WriteLine("Loop: ");
            LoopTraverse loopTraverse = new LoopTraverse();
            nodes = loopTraverse.Pre(root);
            PrintNodes(nodes, "Pre");
            nodes = loopTraverse.InWithState(root);
            PrintNodes(nodes, "InWithState");
            nodes = loopTraverse.In(root);
            PrintNodes(nodes, "In");
            nodes = loopTraverse.Post(root);
            PrintNodes(nodes, "Post");
        }

        private void PrintNodes(IEnumerable<Node> nodes, string order)
        {
            Console.Write("{0}: ", order);
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
            root.Right.Left = new Node(9);
            root.Right.Right = new Node(10);
            root.Left.Left = new Node(4);
            root.Left.Left.Left = new Node(5);
            root.Left.Left.Right = new Node(7);
            // root.Left.Left.Left.Left = new Node(6);
            // root.Left.Left.Left.Right = new Node(8);

            return root;
        }
    }

    public class RecurTraverse
    {
        public Queue<Node> Pre(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            Pre(root, nodes);
            return nodes;
        }

        private void Pre(Node node, Queue<Node> nodes)
        {
            if (node == null)
            {
                return;
            }
            nodes.Enqueue(node);
            Pre(node.Left, nodes);
            Pre(node.Right, nodes);
        }

        public Queue<Node> In(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            In(root, nodes);
            return nodes;
        }

        private void In(Node node, Queue<Node> nodes)
        {
            if (node == null)
            {
                return;
            }
            In(node.Left, nodes);
            nodes.Enqueue(node);
            In(node.Right, nodes);
        }

        public Queue<Node> Post(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            Post(root, nodes);
            return nodes;
        }

        private void Post(Node node, Queue<Node> nodes)
        {
            if (node == null)
            {
                return;
            }
            Post(node.Left, nodes);
            Post(node.Right, nodes);
            nodes.Enqueue(node);
        }

        // public class Node
        // {
        //     public int V { get; set; }

        //     public Node Left { get; set; }

        //     public Node Right { get; set; }
        // }
    }

    public class LoopTraverse
    {
        public Queue<Node> Pre(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                nodes.Enqueue(node);
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
            return nodes;
        }

        public IEnumerable<Node> InWithState(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Peek();
                if (node.State == 0)
                {
                    if (node.Left != null)
                    {
                        stack.Push(node.Left);
                    }
                    node.State = 1;
                }
                else if (node.State == 1)
                {
                    nodes.Enqueue(node);
                    node.State = 2;
                }
                else if (node.State == 2)
                {
                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }
                    node.State = 3;
                }
                else if (node.State == 3)
                {
                    stack.Pop();
                    node.State = 0;
                }
            }
            return nodes;
        }

        public IEnumerable<Node> In(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            Stack<Node> stack = new Stack<Node>();
            Node current = root;
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                current = stack.Pop();
                nodes.Enqueue(current);
                current = current.Right;
            }
            return nodes;
        }

        public Queue<Node> Post(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                // nodes.Enqueue(node);
                // queue.Enqueue(node.Left);
                // queue.Enqueue(node.Right);
            }
            return nodes;
        }

        public Queue<Queue<Node>> Row(Node root)
        {
            Queue<Queue<Node>> rows = new Queue<Queue<Node>>();
            Queue<Node> row = new Queue<Node>();
            row.Enqueue(root);
            rows.Enqueue(row);
            while (row.Count > 0)
            {
                Queue<Node> nextRow = new Queue<Node>();
                while (row.Count > 0)
                {
                    var node = row.Dequeue();
                    if (node.Left != null)
                    {
                        nextRow.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        nextRow.Enqueue(node.Right);
                    }
                }
                row = nextRow;
                rows.Enqueue(row);
            }
            return rows;
        }

        public void Column()
        {

        }
    }
}