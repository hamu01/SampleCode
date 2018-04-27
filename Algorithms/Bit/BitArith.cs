using System;

namespace Bit
{
    public class BitArithSample
    {
        public void Run()
        {
            BitArith bitArith = new BitArith();
            byte b = bitArith.Swap(6);
            Console.WriteLine(b);
        }
    }

    public class BitArith
    {
        public byte Swap(byte i)
        {
            byte n = (byte)(((i << 1) & 0xAA) | ((i >> 1) & 0x55));
            return n;
        }
    }
}