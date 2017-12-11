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
            var rowNodes = Dance(head);
            List<int> rows = new List<int>();
            foreach (var n in rowNodes)
            {
                rows.Add(n.Row);
            }
            return rows;
        }

        public Stack<Node> Dance(Node head)
        {
            Stack<Node> rows = new Stack<Node>();
            int columnIndex = 0;
            int rowIndex = 0;
            while (head.Right != null)
            {
                var result = Search(head, rows, columnIndex, rowIndex);
                if (!result)
                {
                    var node = rows.Pop();
                    while (node != null)
                    {
                        AddColumn(node);
                        node = node.Right;
                    }
                    rowIndex++;
                }
                else
                {
                    rowIndex = 0;
                }
            }
            // throw new Exception("no solution");
            return rows;
        }

        private bool Search(Node head, Stack<Node> rows, int columnIndex, int rowIndex)
        {
            var columns = FindMinColumn(head);
            Node column = columns[columnIndex];
            var node = FindRow(column, rowIndex);
            if (node == null)
            {
                return false;
            }
            rows.Push(node);
            RemoveColumn(node);
            var right = node.Right;
            while (right != null)
            {
                RemoveColumn(right);
                right = right.Right;
            }
            var left = node.Left;
            while (left != null)
            {
                RemoveColumn(left);
                left = left.Left;
            }
            return true;
        }

        private Node FindRow(Node column, int rowIndex)
        {
            int i = 0;
            var n = column;
            while (i++ < rowIndex && n.Down != null)
            {
                n = n.Down;
            }
            return n.Down;
        }

        private void RemoveColumn(Node n)
        {
            var column = GetColumn(n);
            RemoveColumnNode(column);
            Node down = column.Down;
            while (down != null)
            {
                RemoveDataNode(down);
                Node right = down.Right;
                while (right != null)
                {
                    RemoveDataNode(right);
                    right = right.Right;
                }
                Node left = down.Left;
                while (left != null)
                {
                    RemoveDataNode(left);
                    left = left.Left;
                }
                down = down.Down;
            }
        }

        private void AddColumn(Node n)
        {
            var column = GetColumn(n);
            AddColumnNode(column);
            do
            {
                AddDataNode(n);
                Node right = n.Right;
                while (right != null)
                {
                    AddDataNode(right);
                    right = right.Right;
                }
                Node left = n.Left;
                while (left != null)
                {
                    AddDataNode(left);
                    left = left.Left;
                }
                n = n.Down;
            }
            while (n != null);
            // SetColumnCount(column);
        }

        private Node GetColumn(Node n)
        {
            Node link = n;
            while (link.Row != -1)
            {
                link = link.Up;
            }
            return link;
        }

        private void RemoveDataNode(Node n)
        {
            if (n.Up != null)
            {
                n.Up.Down = n.Down;
            }
            if (n.Down != null)
            {
                n.Down.Up = n.Up;
            }
            SetColumnCount(n);
        }

        private void SetColumnCount(Node n)
        {
            var column = GetColumn(n);
            int count = 0;
            var down = column.Down;
            while (down != null)
            {
                count++;
                down = down.Down;
            }
            column.Count = count;
        }

        private void RemoveColumnNode(Node n)
        {
            if (n.Right != null)
            {
                n.Right.Left = n.Left;
            }
            if (n.Left != null)
            {
                n.Left.Right = n.Right;
            }
        }

        private void AddDataNode(Node n)
        {
            if (n.Up != null)
            {
                n.Up.Down = n;
            }
            if (n.Down != null)
            {
                n.Down.Up = n;
            }
            SetColumnCount(n);
        }

        private void AddColumnNode(Node n)
        {
            if (n.Left != null)
            {
                n.Left.Right = n;
            }
            if (n.Right != null)
            {
                n.Right.Left = n;
            }
        }

        private List<Node> FindMinColumn(Node head)
        {
            List<Node> minNodes = new List<Node>();
            Node n = head.Right;
            Node min = n;
            while (n != null)
            {
                if (n.Count < min.Count)
                {
                    min = n;
                    minNodes.Clear();
                    minNodes.Add(min);
                }
                else if (n.Count == min.Count)
                {
                    minNodes.Add(n);
                }
                n = n.Right;
            }
            return minNodes;
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