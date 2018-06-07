using System;
using System.Collections.Generic;

namespace Bit
{
    public class SingleNumberSample
    {
        public void Run()
        {
            SingleNumber singleNumber = new SingleNumber();
            Run1In2(singleNumber);
            Run1InN(singleNumber);
            Run2In2(singleNumber);
        }

        private void Run1In2(SingleNumber singleNumber)
        {
            int[] numbers = GetNumbers(1, 2, 6);
            string s = string.Join(",", numbers);

            int single = singleNumber.Find1In2WithXor(numbers);
            Console.WriteLine($"XOR: Single 1 in 2 of {s} is {single}");

            single = singleNumber.Find1In2WithBitCount(numbers);
            Console.WriteLine($"BitCount: Single 1 in 2 of {s} is {single}");
        }

        private void Run1InN(SingleNumber singleNumber)
        {
            int n = 4;
            int[] numbers = GetNumbers(1, n, 6);
            string s = string.Join(",", numbers);
            int single = singleNumber.Find1InNWithBitCount(numbers, n);
            Console.WriteLine($"BitCount: Single 1 in {n} of {s} is {single}");

            n = 5;
            numbers = GetNumbers(1, n, 6);
            s = string.Join(",", numbers);
            single = singleNumber.Find1InNWithBitCount(numbers, n);
            Console.WriteLine($"BitCount: Single 1 in {n} of {s} is {single}");

            n = 3;
            numbers = GetNumbers(1, n, 2);
            s = string.Join(",", numbers);
            single = singleNumber.Find1In3WithXor(numbers);
            Console.WriteLine($"Xor: Single 1 in {n} of {s} is {single}");
        }

        private void Run2In2(SingleNumber singleNumber)
        {
            int[] numbers = GetNumbers(2, 2, 6);
            string numbersString = string.Join(",", numbers);

            int[] singles = singleNumber.Find2In2WithXor(numbers);
            string singlesString = string.Join(",", singles);
            Console.WriteLine($"XOR: Single 2 in 2 of {numbersString} is {singlesString}");
        }

        private int[] GetNumbers(int m, int n, int c)
        {
            // int len = m + c * n;
            Random random = new Random();
            List<int> numbers = new List<int>();
            for (int i = 0; i < c; i++)
            {
                int item = random.Next(1, 100);
                for (int j = 0; j < n; j++)
                {
                    if (numbers.Count > 0)
                    {
                        int index = random.Next(0, numbers.Count - 1);
                        numbers.Insert(index, item);
                    }
                    else
                    {
                        numbers.Add(item);
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                int item = random.Next(1, 100);
                int index = random.Next(0, numbers.Count - 1);
                numbers.Insert(index, item);
            }

            return numbers.ToArray();
        }
    }

    public class SingleNumber
    {
        public int Find1In2WithXor(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new InvalidOperationException();
            }
            int single = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                single ^= numbers[i];
            }
            return single;
        }

        public int Find1In2WithBitCount(int[] numbers)
        {
            return Find1InNWithBitCount(numbers, 2);
        }

        public int Find1In3WithXor(int[] numbers)
        {
            int x1 = 0, x2 = 0;
            foreach (int num in numbers)
            {
                x2 = x2 ^ (x1 & num);
                x1 = x1 ^ num;
                int mask = ~(x1 & x2);
                x2 = x2 & mask;
                x1 = x1 & mask;
            }
            return x1;
        }

        public int Find1In3WithXor1(int[] numbers)
        {
            int ones = 0, twos = 0;
            foreach (var num in numbers)
            {
                ones = (ones ^ num) & ~twos;
                twos = (twos ^ num) & ~ones;
            }
            return ones;
        }

        public int Find1In3WithBitCount(int[] numbers)
        {
            return Find1InNWithBitCount(numbers, 3);
        }

        public int Find1InNWithBitCount(int[] numbers, int n)
        {
            int single = 0;
            for (int i = 0; i < 32; i++)
            {
                int count = 0;
                foreach (var num in numbers)
                {
                    if ((num & (1 << i)) > 0)
                    {
                        count++;
                    }
                }
                if (count % n != 0)
                {
                    single |= (1 << i);
                }
            }
            return single;
        }

        public int[] Find2In2WithXor(int[] numbers)
        {
            int xor = 0;
            foreach (int num in numbers)
            {
                xor ^= num;
            }
            int firstOneBit = xor & (~(xor - 1));
            int a = 0;
            foreach (int num in numbers)
            {
                if ((num & firstOneBit) > 0)
                {
                    a ^= num;
                }
            }
            int b = xor ^ a;
            return new int[] { a, b };
        }

        public int Find2In3(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public int FindMInN(int[] numbers, int m, int n)
        {
            throw new NotImplementedException();
        }
    }
}