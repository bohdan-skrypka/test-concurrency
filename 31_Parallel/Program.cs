using System;
using System.Diagnostics;
using System.Linq;

namespace _31_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum1 = Sum.SumValues(new long[] { 2, 3, 555, 2, 1 });
            Console.WriteLine($"{sum1.ToString()}");
            var sum2 = Sum.SumForEach(new[] { 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 });
            Console.WriteLine($"{sum2.ToString()}");
            var sum3 = Sum.PLinqAggregate(new[] { 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 });


            Console.WriteLine("Perf test");
            Console.WriteLine("-------------------------------------------------");
            var sequenceOfElements = Enumerable.Range(1, 10000);
            long[] longArr = new long[sequenceOfElements.Count()];
            Array.Copy(sequenceOfElements.ToArray(), 0, longArr, 0, sequenceOfElements.Count());

            Stopwatch stopwatch = Stopwatch.StartNew();
            var sum1_1 = Sum.SumValues(longArr);
            stopwatch.Stop();
            Console.WriteLine(sum1_1.ToString() + ":" + stopwatch.ElapsedMilliseconds.ToString());

            stopwatch = Stopwatch.StartNew();
            var sum2_2 = Sum.SumForEach(sequenceOfElements);
            stopwatch.Stop();
            Console.WriteLine(sum2_2.ToString() + ":" + stopwatch.ElapsedMilliseconds.ToString());

            stopwatch = Stopwatch.StartNew();
            var sum3_3 = Sum.PLinqAggregate(sequenceOfElements);
            stopwatch.Stop();
            Console.WriteLine(sum3_3.ToString() + ":" + stopwatch.ElapsedMilliseconds.ToString());

            Console.WriteLine("Hello World!");
        }
    }
}
