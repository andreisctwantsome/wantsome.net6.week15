using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace _05.Threading.Limitations
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(()=> {
                var sum = ProcessFile(@"data\file11.txt");
                Console.WriteLine(sum);
                // 01 - cannot return values;
                // return sum;
            });

            try
            {
                t.Start();
            }
            catch(Exception e) // 02 - cannot catch child exception execptions in caller thread
            {
                Console.WriteLine(e.Message);
            }
        }

        static decimal ProcessFile(string path)
        {
            decimal sum = 0;
            var lines = File.ReadAllLines(path).ToList();

            foreach(var line in lines)
            {
                sum += Decimal.Parse(line);
            }

            return sum;
        }
    }
}
