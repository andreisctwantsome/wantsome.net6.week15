using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CompareHashsetList
{
    class Program
    {
        const int N = 100000;

        static void Main(string[] args)
        {
            List();
            HashSet();
        }

        static void List()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var list = new List<string>();

            for (int i = 0; i < N; i++)
            {
                var s = i.ToString();
                list.Add(s);
            }

            for (int i = 0; i < N; i++)
            {
                list.Remove(i.ToString());
            }

            stopwatch.Stop();

            Console.WriteLine($"List: elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }

        static void HashSet()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var list = new HashSet<string>();

            for (int i = 0; i < N; i++)
            {
                var s = i.ToString();
                list.Add(s);
            }

            for (int i = 0; i < N; i++)
            {
                list.Remove(i.ToString());
            }

            stopwatch.Stop();

            Console.WriteLine($"HashSet: elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
