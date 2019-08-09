using System;

namespace DataStructure
{
    public class DualQueue
    {
        private int[] _nums;

        public DualQueue(int n)
        {
            _nums = new int[n];
        }

        public void Enqueue(int num, int i)
        {
            if (i == 1)
            {

            }
            else if (i == 2)
            {

            }
            else
            {
                throw new Exception("only supoport 1 and 2");
            }
        }

        public int Dequeue(int i)
        {
            if (i == 1)
            {

            }
            else if (i == 2)
            {

            }
            else
            {
                throw new Exception("only supoport 1 and 2");
            }
        }
    }
}