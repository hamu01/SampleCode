using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            // CountSort countSort = new CountSort();
            // countSort.Run();

            // RadixSort radixSort = new RadixSort();
            // radixSort.Run();

            // RadixKSort radixKSort = new RadixKSort();
            // radixKSort.Run();

            // int[] A = new int[] {0,1,1,0,0,1,1,0};
            // Sort01(A);           
            // Console.WriteLine(string.Join(',', A));

            RadixVarSort radixVarSort = new RadixVarSort();
            radixVarSort.Run();
        }

        private static void Sort01(int[] A)
        {
            int i=0, j=A.Length-1;
            while (i< j)
            {
                while(A[i] == 0){
                    i++;
                }
                while(A[j] == 1){
                    j--;
                }
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
                i++;
                j--;
            }
        }
    }
}
