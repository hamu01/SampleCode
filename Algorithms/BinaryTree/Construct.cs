using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace BinaryTree
{
    public class ConstructSample
    {
        public void Run()
        {
            int[] inValues = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16 };
            int[] preValues = new int[] { 10, 6, 4, 3, 5, 8, 7, 9, 14, 12, 11, 13, 16 };
            int[] postValues = new int[] { 3, 5, 4, 7, 9, 8, 6, 11, 13, 12, 16, 14, 10 };
            Construct construct = new Construct();
            var root = construct.PreAndIn(preValues, inValues);
            LoopTraverse traverse = new LoopTraverse();
            var nodes = traverse.Pre(root).ToArray();
            for (int i = 0; i < nodes.Length; i++)
            {
                var node = nodes[i];
                if (node.V != preValues[i])
                {
                    Console.WriteLine("pre not match");
                    break;
                }
            }
            Console.WriteLine("pre match");

            root = construct.InAndPost(inValues, postValues);
            nodes = traverse.Post(root).ToArray();
            for (int i = 0; i < nodes.Length; i++)
            {
                var node = nodes[i];
                if (node.V != postValues[i])
                {
                    Console.WriteLine("post not match");
                    break;
                }
            }
            Console.WriteLine("post match");

            preValues = new int[] { 1, 2 };
            root = construct.Pre(preValues);
            nodes = traverse.Pre(root).ToArray();
            for (int i = 0; i < nodes.Length; i++)
            {
                var node = nodes[i];
                if (node.V != preValues[i])
                {
                    Console.WriteLine("bst pre not match");
                    break;
                }
            }
            Console.WriteLine("bst pre match");

            root = construct.Post(postValues);
            nodes = traverse.Post(root).ToArray();
            for (int i = 0; i < nodes.Length; i++)
            {
                var node = nodes[i];
                if (node.V != postValues[i])
                {
                    Console.WriteLine("bst post not match");
                    break;
                }
            }
            Console.WriteLine("bst post match");
        }
    }

    public class Construct
    {
        public Node PreAndIn(int[] preValues, int[] inValues)
        {
            if (preValues.Length < 1)
            {
                return null;
            }
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < inValues.Length; i++)
            {
                dic[inValues[i]] = i;
            }
            Node root = new Node(preValues[0]);
            for (int i = 1; i < preValues.Length; i++)
            {
                int v = preValues[i];
                Node n = root;
                while (true)
                {
                    if (dic[v] <= dic[n.V])
                    {
                        if (n.Left != null)
                        {
                            n = n.Left;
                        }
                        else
                        {
                            n.Left = new Node(v);
                            break;
                        }
                    }
                    else
                    {
                        if (n.Right != null)
                        {
                            n = n.Right;
                        }
                        else
                        {
                            n.Right = new Node(v);
                            break;
                        }
                    }
                }
            }
            return root;
        }

        public Node InAndPost(int[] inValues, int[] postValues)
        {
            if (postValues.Length < 1)
            {
                return null;
            }
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < inValues.Length; i++)
            {
                dic[inValues[i]] = i;
            }
            Node root = new Node(postValues[postValues.Length - 1]);
            for (int i = postValues.Length - 2; i >= 0; i--)
            {
                int v = postValues[i];
                Node n = root;
                while (true)
                {
                    if (dic[v] <= dic[n.V])
                    {
                        if (n.Left != null)
                        {
                            n = n.Left;
                        }
                        else
                        {
                            n.Left = new Node(v);
                            break;
                        }
                    }
                    else
                    {
                        if (n.Right != null)
                        {
                            n = n.Right;
                        }
                        else if (n.Left != null)
                        {
                            throw new InvalidOperationException("invalid post values");
                        }
                        else
                        {
                            n.Right = new Node(v);
                            break;
                        }
                    }
                }
            }
            return root;
        }

        public Node Pre(int[] preValues)
        {
            Node root = new Node(preValues[0]);
            for (int i = 1; i < preValues.Length; i++)
            {
                int v = preValues[i];
                Node n = root;
                while (true)
                {
                    if (v <= n.V)
                    {
                        if (n.Left != null)
                        {
                            n = n.Left;
                        }
                        else
                        {
                            n.Left = new Node(v);
                            break;
                        }
                    }
                    else
                    {
                        if (n.Right != null)
                        {
                            n = n.Right;
                        }
                        else if (n.Left == null)
                        {
                            throw new InvalidOperationException("invalid pre values");
                        }
                        else
                        {
                            n.Right = new Node(v);
                            break;
                        }
                    }
                }
            }
            return root;
        }

        public Node Post(int[] postValues)
        {
            Node root = new Node(postValues[postValues.Length - 1]);
            for (int i = postValues.Length - 2; i >= 0; i--)
            {
                int v = postValues[i];
                Node n = root;
                while (true)
                {
                    if (v <= n.V)
                    {
                        if (n.Left != null)
                        {
                            n = n.Left;
                        }
                        else
                        {
                            n.Left = new Node(v);
                            break;
                        }
                    }
                    else
                    {
                        if (n.Right != null)
                        {
                            n = n.Right;
                        }
                        else if (n.Left != null)
                        {
                            throw new InvalidOperationException("invalid post values");
                        }
                        else
                        {
                            n.Right = new Node(v);
                            break;
                        }
                    }
                }
            }
            return root;
        }
    }
}