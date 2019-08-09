using System;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            DualStackTest();
        }

        private static void DualStackTest()
        {
            DualStack dualStack = new DualStack(10);
            for (int i = 0; i < 10; i++)
            {
                dualStack.Push(i, 1);
            }

            try
            {
                dualStack.Push(0, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < 10; i++)
            {
                int num = dualStack.Pop(1);
                Console.Write(num + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                dualStack.Push(i, 2);
            }

            try
            {
                dualStack.Push(0, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < 10; i++)
            {
                int num = dualStack.Pop(2);
                Console.Write(num + " ");
            }
            Console.WriteLine();

            try
            {
                dualStack.Pop(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                dualStack.Pop(2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < 5; i++)
            {
                dualStack.Push(i, 1);
                dualStack.Push(i, 2);
            }
            try
            {
                dualStack.Push(0, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                dualStack.Push(0, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < 5; i++)
            {
                int num1= dualStack.Pop(1);
                int num2=dualStack.Pop(2);
                Console.Write($"{num1} {num2} ");
            }
        }
    }
}
