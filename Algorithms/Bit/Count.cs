using System;

namespace Bit
{
    public class CountSample
    {
        public void Run()
        {
            int[] values = new int[] { 5, 4, 3, 5, 4, 2, 3, 3, 4, 5 };
            Count count = new Count();
            int single = count.FindSingle(values);
            Console.WriteLine(single);
        }
    }

    public class Count
    {
        public int FindSingle(int[] values)
        {
            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                int sum = 0;
                int bit = 1 << i;
                foreach (var v in values)
                {
                    if ((bit & v) == bit)
                    {
                        sum++;
                    }
                }
                if (sum % 3 != 0)
                {
                    result |= bit;
                }
            }
            return result;
        }
    }
}