using System;
using System.Collections.Generic;

namespace Classic
{
    public class DanceLink
    {
        Dictionary<int, Node> _cache = new Dictionary<int, Node>();

        public List<int> Dance(int[,] matrix)
        {
            Node head = ConvertToNode(matrix);
            // Assert(head);
            return Dance(head);
        }

        public List<int> Dance(Node head)
        {
            List<int> rows = new List<int>();
            while (head.Right != null)
            {
                Node n = FindMinHead(head);
                if (n.Down == null)
                {
                    throw new Exception("no solution");
                }
                n = n.Down;
                rows.Add(n.Row);
                RemoveAll(n);
            }
            return rows;
        }

        private void RemoveAll(Node n)
        {
            Remove(n);
            if (n.Row == -1)
            {
                return;
            }
            Node left = n.Left;
            while (left != null)
            {
                RemoveAll(left);
                left = left.Left;
            }
            Node right = n.Right;
            while (right != null)
            {
                RemoveAll(right);
                right = right.Right;
            }
            Node up = n.Up;
            while (up != null)
            {
                RemoveAll(up);
                up = up.Up;
            }
            Node down = n.Down;
            while (down != null)
            {
                RemoveAll(down);
                down = down.Down;
            }
        }

        private void Remove(Node n)
        {
            if (n.Right != null)
            {
                n.Right.Left = n.Left;
            }
            if (n.Left != null)
            {
                n.Left.Right = n.Right;
            }
            if (n.Up != null)
            {
                n.Up.Down = n.Down;
            }
            if (n.Down != null)
            {
                n.Down.Up = n.Up;
            }
        }

        private void Add(Node n)
        {
            if (n.Left != null)
            {
                n.Left.Right = n;
            }
            if (n.Right != null)
            {
                n.Right.Left = n;
            }
            if (n.Up != null)
            {
                n.Up.Down = n;
            }
            if (n.Down != null)
            {
                n.Down.Up = n;
            }
        }

        private Node FindMinHead(Node head)
        {
            Node n = head.Right;
            Node min = n;
            while (n != null)
            {
                if (n.Count < min.Count)
                {
                    min = n;
                }
                n = n.Right;
            }
            return min;
        }

        private Node ConvertToNode(int[,] matrix)
        {
            Node head = new Node(-1, -1);
            Node hLink = head;
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);
            for (int column = 0; column < columnCount; column++)
            {
                Node headerNode = GetOrAdd(-1, column, columnCount);
                hLink.Right = headerNode;
                headerNode.Left = hLink;
                var vLink = headerNode;
                int count = 0;
                for (int row = 0; row < rowCount; row++)
                {
                    if (matrix[row, column] == 1)
                    {
                        Node downNode = GetOrAdd(row, column, columnCount);
                        vLink.Down = downNode;
                        downNode.Up = vLink;
                        int c = column;
                        while (++c < columnCount && matrix[row, c] != 1) { }
                        if (c < columnCount)
                        {
                            Node rightNode = GetOrAdd(row, c, columnCount);
                            downNode.Right = rightNode;
                            rightNode.Left = downNode;
                        }
                        vLink = vLink.Down;
                        count++;
                    }
                }
                headerNode.Count = count;
                hLink = hLink.Right;
            }
            return head;
        }

        private Node GetOrAdd(int row, int column, int columnCount)
        {
            int index = row * columnCount + column;
            if (!_cache.ContainsKey(index))
            {
                Node n = new Node(row, column);
                _cache.Add(index, n);
            }
            return _cache[index];
        }

        private void Assert(Node head)
        {
            Node link = head;
            var node = link.Right;
            Assert(node.Column == 0 && node.Row == -1);
            node = node.Down;
            Assert(node.Column == 0 && node.Row == 0);
            node = node.Right;
            Assert(node.Column == 3 && node.Row == 0);
            node = node.Left.Down;
            Assert(node.Column == 0 && node.Row == 4);

            link = link.Right;
            node = link.Right;
            Assert(node.Column == 1 && node.Row == -1);
            node = node.Down;
            Assert(node.Column == 1 && node.Row == 1);

            link = link.Right;
            node = link.Right;
            Assert(node.Column == 2 && node.Row == -1);
            node = node.Down;
            Assert(node.Column == 2 && node.Row == 2);

            link = link.Right;
            node = link.Right;
            Assert(node.Column == 3 && node.Row == -1);
            node = node.Down;
            Assert(node.Column == 3 && node.Row == 0);
            node = node.Down;
            Assert(node.Column == 3 && node.Row == 4);

            link = link.Right;
            node = link.Right;
            Assert(node.Column == 4 && node.Row == -1);
            node = node.Down;
            Assert(node.Column == 4 && node.Row == 3);

            link = link.Right;
            node = link.Right;
            Assert(node.Column == 5 && node.Row == -1);
            node = node.Down;
            Assert(node.Column == 5 && node.Row == 1);
        }

        private void Assert(bool b)
        {
            if (!b)
            {
                throw new Exception();
            }
        }
    }

    public class Node
    {
        public Node(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Node Up { get; set; }

        public Node Down { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Column { get; set; }

        public int Row { get; set; }

        public int Count { get; set; }
    }
}