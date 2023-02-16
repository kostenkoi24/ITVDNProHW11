using System;
using System.Threading;

namespace Homework11_4
{
    class Program
    {
        static int counter = 0;

        static object block = 0; 

        static void Function()
        {
            lock (block)
            {
                for (int i = 0; i < 50; ++i)
                {
                    Console.WriteLine(++counter);
                    Console.WriteLine("\t{0}",Thread.CurrentThread.GetHashCode());
                }
            }
            
        }

        static void Main()
        {
            Thread[] threads = { new Thread(Function), new Thread(Function), new Thread(Function) };

            foreach (Thread thread in threads)
                thread.Start();

            // Delay
            Console.ReadKey();
        }
    }
}
