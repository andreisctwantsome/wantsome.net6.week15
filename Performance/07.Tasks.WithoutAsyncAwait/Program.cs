using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _07.Tasks.WithoutAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Start calculation on thread: {Thread.CurrentThread.ManagedThreadId}");

            var t = GetSumAsync();

            t.Wait();
            var sum = t.Result;

            Console.WriteLine($"Result is {sum}");

            //Console.WriteLine($"Finish result on thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static Task<decimal> GetSumAsync()
        {
            return Task.Factory.StartNew(() => {
                Console.WriteLine($"Calculate sum on thread with ID: {Thread.CurrentThread.ManagedThreadId}");

                var sum = ProcessFile(@"data\file1.txt");
                return sum;
            });
        }

        static decimal ProcessFile(string path)
        {
            decimal sum = 0;
            var lines = File.ReadAllLines(path).ToList();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            foreach (var line in lines)
            {
                sum += decimal.Parse(line);
            }

            return sum;
        }

    }
}
