using System;
using System.Threading;

namespace _02.Threading.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello from thread. ID: {Thread.CurrentThread.ManagedThreadId}");

            Thread thread = new Thread(() => 
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                Console.WriteLine($"Hello from thread. ID: {Thread.CurrentThread.ManagedThreadId}");
            });

            thread.Start();
            thread.Join();   // blocant

            Console.WriteLine($"Finish on main thread");
        }
    }
}
