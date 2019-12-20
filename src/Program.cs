using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RandomString
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<string, string> dicTest = new Dictionary<string, string>();
            var test1 = new AlphaNumericStringGenerator();
            var test2 = new Hashids("", 8);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            int i = 0;
            try
            {
                for (i = 0; i < 100000; i++)
                {
                    //var value = test1.GetRandomUppercaseAlphaNumericValue(8);
                    var value = test2.EncodeLong(DateTime.UtcNow.Ticks);
                    dicTest.Add(value, "");
                    Console.WriteLine($"Value: {value}, Pos: {i}");
                }
                sw.Stop();

                Console.WriteLine("Elapsed={0}", sw.Elapsed);
            }
            catch (Exception ex)
            {
                sw.Stop();

                Console.WriteLine("Elapsed={0}", sw.Elapsed);
                Console.WriteLine($"Error: {ex.Message}, Pos: {i}");
            }

            Console.ReadKey();
        }
    }
}
