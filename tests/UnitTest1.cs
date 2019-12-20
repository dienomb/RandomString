using RandomString;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace RandomStringTests
{
    public class UnitTest1
    {
        Dictionary<string, string> dicTest;
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            dicTest = new Dictionary<string, string>();
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            var test1 = new AlphaNumericStringGenerator();
            var test2 = new Hashids("", 8);
            var test5 = new RandomEx();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            int i = 0;
            try
            {
                for (i = 0; i < 10000000; i++)
                {
                    //var value = test1.GetRandomUppercaseAlphaNumericValue(8);
                    //var value = test2.EncodeLong(DateTime.UtcNow.Ticks);
                    //var value = KeyGenerator.GetUniqueKey(8);
                    //var value = linqId.RandomString(8);
                    var value = RandomEx.GetString(8);
                    dicTest.Add(value, "");
                    output.WriteLine($"Value: {value}, Pos: {i}");
                }
                sw.Stop();

                output.WriteLine("Elapsed={0}", sw.Elapsed);
            }
            catch (Exception ex)
            {
                sw.Stop();

                output.WriteLine("Elapsed={0}", sw.Elapsed);
                output.WriteLine($"Error: {ex.Message}, Pos: {i}");
            }
        }
    }
}
