using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _06.Tasks.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // option 1
            //Task<decimal> t = new Task<decimal>(() => {
            //    var sum = ProcessFile(@"data\file1.txt");
            //    return sum;
            //});
            //t.Start();

            // option 2
            //var t = Task.Run(()=>{
            //    var sum = ProcessFile(@"data\file1.txt");
            //    return sum;
            //});

            // option 3
            var t = Task.Factory.StartNew(()=> {
                Console.WriteLine($"SUM: {Thread.CurrentThread.ManagedThreadId}");
                
                var sum = ProcessFile(@"data\file1.txt");
                return sum;
            });

            // 03 - continuation
            var t2 = t.ContinueWith(prev => {
                Console.WriteLine($"RES: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"Prev task finished. Result = {prev.Result}");
            });

            try
            {
                t2.Wait();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
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
