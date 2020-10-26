using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace _01.Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            Thread t = new Thread(() => 
            {
                ProcessFile(@"data\file4.txt");
                ProcessFile(@"data\file5.txt");
            });

            t.Start();

            ProcessFile(@"data\file1.txt");
            ProcessFile(@"data\file2.txt");
            ProcessFile(@"data\file3.txt");

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }

        static void MainV2(string[] args)
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

        static void ProcessFile(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            var count = lines.Count;

            lines.RemoveAll(x => x == "3");

            var nrAp1 = lines.Where(x => x == "1").Count();
            var nrAp2 = lines.Where(x => x == "2").Count();
            var nrAp3 = lines.Where(x => x == "3").Count();

            Console.WriteLine($"{path}, {count} lines; NrAp of 1 = {nrAp1}; 2 = {nrAp2}; 3 = {nrAp3}");
        }
    }
}
