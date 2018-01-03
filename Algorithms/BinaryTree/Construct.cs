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
            int[] values = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16 };
            Construct construct = new Construct();
            var root = construct.In(values);
            LoopTraverse traverse = new LoopTraverse();
            var nodes = traverse.In(root).ToArray();
            for (int i = 0; i < nodes.Length; i++)
            {
                var node = nodes[i];
                if (node.V != values[i])
                {
                    Console.WriteLine("not match");
                    break;
                }
            }
            Console.WriteLine("match");
        }
    }

    public class Construct
    {
        public Node PreAndIn(int[] values, int[] inValues)
        {
            Node root = new Node();
            return root;
        }

        public Node InAndPost(int[] inValues, int[] postValues)
        {
            Node root = new Node();
            return root;
        }
    }
}