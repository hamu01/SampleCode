using System;

namespace Bit
{
    public class CountSample
    {
        public void Run()
        {
            Count count = new Count();
            int parity = count.ParityCheck(180);
            Console.WriteLine(parity);
            parity = count.ParityCheck(181);
            Console.WriteLine(parity);
            parity = count.ParityCheck(10);
            Console.WriteLine(parity);
            parity = count.ParityCheck(11);
            Console.WriteLine(parity);
        }
    }

    public class Count
    {
        public int ParityCheck(byte b)
        {
            int j = 0;
            for (int i = 7; i >= 0; i--)
            {
                j ^= (b & (1 << i)) >> i;
            }
            return j;
        }
    }
}