using System;
using System.Collections;
using System.Diagnostics;

namespace Bit
{
    public class BitReverseSample
    {
        public void Run()
        {
            BitReverse reverse = new BitReverse();
            uint i = 10;
            uint j = reverse.Reverse(i);
            PrintBit(i);
            PrintBit(j);

            i = 43261596;
            j = reverse.Reverse(i);
            PrintBit(i);
            PrintBit(j);
            
            // PerfRun(reverse);
        }

        private void PerfRun(BitReverse reverse)
        {
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000 * 1000 * 100; i++)
            {
                reverse.Reverse(43261596);
            }
            System.Console.WriteLine(watch.Elapsed);

            watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000 * 1000 * 100; i++)
            {
                reverse.Reverse1(43261596);
            }
            System.Console.WriteLine(watch.Elapsed);
        }

        private void PrintBit(uint i)
        {
            var bytes = BitConverter.GetBytes(i);
            BitArray bits = new BitArray(bytes);
            Console.Write($"{i}: ");
            for (int k = bits.Length - 1; k >= 0; k--)
            {
                bool b = bits[k];
                Console.Write(b ? "1" : "0");
            }
            Console.WriteLine();
        }
    }

    public class BitReverse
    {
        public uint Reverse(uint i)
        {
            uint j = 0;
            int k = 31;
            while (i > 0)
            {
                if (i % 2 == 1)
                {
                    j |= (uint)1 << k;
                }
                i /= 2;
                k--;
            }
            return j;
        }

        public uint Reverse1(uint i)
        {
            var bytes = BitConverter.GetBytes(i);
            BitArray bits = new BitArray(bytes);
            int j = 0, k = bits.Length - 1;
            while (j < k)
            {
                Swap(bits, j++, k--);
            }
            byte[] newBytes = new byte[4];
            ((ICollection)bits).CopyTo(newBytes, 0);
            uint r = BitConverter.ToUInt32(newBytes, 0);
            return r;
        }

        private void Swap(BitArray bits, int i, int j)
        {
            bool temp = bits[i];
            bits[i] = bits[j];
            bits[j] = temp;
        }
    }
}