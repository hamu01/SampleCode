using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            // CountSort countSort = new CountSort();
            // countSort.Run();

            RadixSort radixSort = new RadixSort();
            radixSort.Run();
        }
    }
}
