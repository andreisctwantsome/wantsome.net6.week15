using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace _03.Threading.Files
{
    class Program
    {
        static void MainV1(string[] args)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            ProcessFile(@"data\file1.txt");
            ProcessFile(@"data\file2.txt");
            ProcessFile(@"data\file3.txt");
            ProcessFile(@"data\file4.txt");
            ProcessFile(@"data\file5.txt");

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }

        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            Thread t1 = new Thread(() =>
            {
                ProcessFile(@"data\file1.txt");
            });

            Thread t2 = new Thread(() =>
            {
                ProcessFile(@"data\file2.txt");
            });
            
            Thread t3 = new Thread(() =>
            {
                ProcessFile(@"data\file3.txt");
            });
            
            Thread t4 = new Thread(() =>
            {
                ProcessFile(@"data\file4.txt");
            });
            
            Thread t5 = new Thread(() =>
            {
                ProcessFile(@"data\file5.txt");
            });

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }


        static void ProcessFile(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            var count = lines.Count;

            Thread.Sleep(TimeSpan.FromSeconds(3));

            lines.RemoveAll(x => x == "3");

            var nrAp1 = lines.Where(x => x == "1").Count();
            var nrAp2 = lines.Where(x => x == "2").Count();
            var nrAp3 = lines.Where(x => x == "3").Count();

            Console.WriteLine($"{path}, {count} lines; NrAp of 1 = {nrAp1}; 2 = {nrAp2}; 3 = {nrAp3}");
        }
    }

}
