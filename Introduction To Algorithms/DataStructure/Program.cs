using System;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            // DualStackTest();
            // QueueTest();
            // DualQueueTest();
            LinkedListTest();
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
                int num1 = dualStack.Pop(1);
                int num2 = dualStack.Pop(2);
                Console.Write($"{num1} {num2} ");
            }
        }

        private static void QueueTest()
        {
            Queue queue = new Queue(10);
            try
            {
                queue.Dequeue();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }
            try
            {
                queue.Enqueue(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write(queue.Dequeue() + " ");
            }
            Console.WriteLine();
            try
            {
                queue.Dequeue();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DualQueueTest()
        {
            DualQueue queue = new DualQueue(10);
            try
            {
                queue.DequeueStart();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                queue.DequeueEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < 10; i++)
            {
                queue.EnqueueEnd(i);
            }
            try
            {
                queue.EnqueueStart(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                queue.EnqueueEnd(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write(queue.DequeueEnd() + " ");
            }
            Console.WriteLine();
            try
            {
                queue.DequeueStart();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                queue.DequeueEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < 10; i++)
            {
                queue.EnqueueStart(i);
            }
            try
            {
                queue.EnqueueStart(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                queue.EnqueueEnd(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write(queue.DequeueStart() + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                queue.EnqueueStart(i);
            }
            for (int i = 5; i < 10; i++)
            {
                queue.EnqueueEnd(i);
            }
            try
            {
                queue.EnqueueStart(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                queue.EnqueueEnd(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.Write(queue.DequeueStart() + " ");
            }
            for (int i = 5; i < 10; i++)
            {
                Console.Write(queue.DequeueEnd() + " ");
            }
            Console.WriteLine();
        }
    
        private static void LinkedListTest()
        {
            LinkedList linkedList = new LinkedList();
            int[] nums = new int[] {1,2,3,4,5};
            Node n = linkedList.Build(nums);
            linkedList.Print(n);
            n = linkedList.Reverse(n);
            linkedList.Print(n);
        }
    }
}