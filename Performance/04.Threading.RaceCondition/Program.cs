using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace _04.Threading.RaceCondition
{
    class Program
    {
        const decimal Number = 100000000;

        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            object lck = new object();

            List<int> list = new List<int>();

            decimal sum = 0;

            Thread t1 = new Thread(() => {
                decimal sum1 = 0;

                for (decimal i = 1; i < Number / 2; i++)
                {
                    sum1 = sum1 + i;
                }

                lock (lck)
                {
                    sum = sum + sum1;
                }

                lock(lck)
                {
                    list.Add(1);
                }
            });

            Thread t2 = new Thread(() => {
                decimal sum2 = 0;

                for (decimal i = Number / 2; i <= Number; i++)
                {
                    sum2 = sum2 + i;
                }

                lock (lck)
                {
                    sum = sum + sum2;
                }
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            stopwatch.Stop();

            Console.WriteLine($"Sum = {sum}");

            Console.WriteLine();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }

        static void MainV2(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal sum = 0;

            object lck = new object();

            Thread t1 = new Thread(()=> {
                for (decimal i = 1; i < Number/2; i++)
                {
                    // start
                    //Monitor.Enter(lck);
                    // sum = sum + i;
                    // end
                    //Monitor.Exit(lck);

                    lock (lck)
                    {
                        sum = sum + i;
                    }
                }
            });

            Thread t2 = new Thread(() => {
                for (decimal i = Number/2; i <= Number; i++)
                {
                    // start
                    //Monitor.Enter(lck);
                    // sum = sum + i;
                    // end
                    //Monitor.Exit(lck);

                    lock (lck)
                    {
                        sum = sum + i;
                    }
                }
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"Sum = {sum}");

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }

        static void MainV1(string[] args)
        {
            decimal sum = 0;

            for (decimal i = 1; i <= Number; i++)
            {
                sum += i;
            }

            Console.WriteLine($"Sum = {sum}");
        }
    }
}
