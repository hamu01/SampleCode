using System;
using System.Collections.Generic;

namespace Bit
{
    public class MaxXorSample
    {
        public void Run()
        {
            MaxXor maxXor = new MaxXor();
            // RunTwo(maxXor);
            RunAny(maxXor);
        }

        private void RunAny(MaxXor maxXor)
        {
            int[] values;
            int max;
            values = new int[] { 1, 2, 3, 4 };
            max = maxXor.FindAny(values);
            Console.WriteLine($"The max xor of {string.Join(",", values)} is {max}");

            values = new int[] { 8, 1, 2, 12, 7, 6 };
            max = maxXor.FindAny(values);
            Console.WriteLine($"The max xor of {string.Join(",", values)} is {max}");

            values = new int[] { 4, 6 };
            max = maxXor.FindAny(values);
            Console.WriteLine($"The max xor of {string.Join(",", values)} is {max}");
        }

        private void RunTwo(MaxXor maxXor)
        {
            int[] values;
            int max;
            values = new int[] { 3, 10, 5, 25, 2, 8 };
            max = maxXor.FindTwo(values);
            Console.WriteLine($"The max xor of {string.Join(",", values)} is {max}");

            values = new int[] { 3, 10, 5, 25 };
            // max = maxXor.FindTwo(values);
            max = maxXor.FindTwoWithTrie(values);
            Console.WriteLine($"The max xor of {string.Join(",", values)} is {max}");

            values = new int[] { 3, 10, 5 + 16, 25 };
            // max = maxXor.FindTwo(values);
            max = maxXor.FindTwoWithTrie(values);
            Console.WriteLine($"The max xor of {string.Join(",", values)} is {max}");

            values = new int[] { 16 + 3, 16 + 10, 16 + 5, 25 };
            // max = maxXor.FindTwo(values);
            max = maxXor.FindTwoWithTrie(values);
            Console.WriteLine($"The max xor of {string.Join(",", values)} is {max}");

            values = new int[] { 10, 2, 8 };
            // max = maxXor.FindTwo(values);
            max = maxXor.FindTwoWithTrie(values);
            Console.WriteLine($"The max xor of {string.Join(",", values)} is {max}");
        }
    }

    public class MaxXor
    {
        public int FindTwo(int[] nums)
        {
            int max = 0, mask = 0;
            for (int i = 4; i >= 0; i--)
            {
                mask = mask | (1 << i);
                HashSet<int> set = new HashSet<int>();
                foreach (var num in nums)
                {
                    set.Add(num & mask);
                }
                int temp = max | (1 << i);
                foreach (var prefix in set)
                {
                    if (set.Contains(prefix ^ temp))
                    {
                        max = temp;
                    }
                }
            }
            return max;
        }

        public int FindTwoWithTrie(int[] nums)
        {
            Node root = new Node();
            int count = 31;
            foreach (int num in nums)
            {
                Node n = root;
                for (int i = count; i >= 0; i--)
                {
                    int bit = (num >> i) & 1;
                    if (n.Next[bit] == null)
                    {
                        n.Next[bit] = new Node() { V = bit };
                    }
                    n = n.Next[bit];
                }
            }
            int max = -1;
            foreach (int num in nums)
            {
                Node n = root;
                int cur = 0;
                for (int i = count; i >= 0; i--)
                {
                    int bit = (num >> i) & 1;
                    if (n.Next[bit ^ 1] != null)
                    {
                        cur |= 1 << i;
                        n = n.Next[bit ^ 1];
                    }
                    else
                    {
                        n = n.Next[bit];
                    }
                }
                if (cur > max) max = cur;
            }
            return max;
        }

        public int FindAny(int[] nums)
        {
            int max = 0, mask = 0;
            int count = 31;
            for (int i = count; i >= 0; i--)
            {
                mask |= 1 << i;
                HashSet<int> set = new HashSet<int>();
                foreach (var num in nums)
                {
                    set.Add(num & mask);
                }
                int temp = max | (1 << i);
                if (set.Contains(max ^ temp))
                {
                    max = temp;
                }
                else
                {
                    foreach (var prefix in set)
                    {
                        if (set.Contains(prefix ^ temp) || (prefix ^ temp) == 0)
                        {
                            max = temp;
                            break;
                        }
                    }
                }
            }
            return max;
        }

        public int FindThree(int[] nums)
        {
            throw new NotImplementedException();
        }

        private class Node
        {
            public int V;

            public Node[] Next = new Node[2];
        }
    }
}