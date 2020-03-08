using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace _31_Parallel
{
    /// <summary>
    /// PLinq is more expensive than Parallel, but code more shorter
    /// Plinq will use all CPU cores and resources
    /// Parallel will work together with existing processes in light mode
    /// </summary>
    class Sum
    {
        public static long SumValues(IEnumerable<long> source)
        {
            return source.AsParallel().Sum();
        }

        public static long SumForEach(IEnumerable<int> source)
        {
            object mutex = new object();
            long res = 0;
            Parallel.ForEach(source: source,
                localInit: () => (long)0,
                body: (item, state, local) => local + item,
                localFinally: local =>
                {
                    lock (mutex)
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
                        res += local;
                    }
                });

            return res;
        }

        public static int PLinqAggregate(IEnumerable<int> values)
        {
            return values.AsParallel().Aggregate(seed: 0,
                func: (sum, item) => sum + item);
        }
    }

    /// <summary>
    /// Parallel.invoke great fit when you need to run simple actions in parallel
    /// if you need iterate your cicle better to use Parallel.ForEach or Plinq
    /// </summary>
    class ParallelInvoication
    {
        static void ProcessArray(double[] array)
        {
            Parallel.Invoke(
                () => ProcessPartialArray(array, 0, array.Length / 2),
                () => ProcessPartialArray(array, 0, array.Length / 4)
               );
        }

        private static object ProcessPartialArray(double[] array, int begin, int end)
        {
            return new object();
        }

        public static void DoAction20Times(Action action)
        {
            Action[] actions = Enumerable.Repeat(action, 20).ToArray();
            Parallel.Invoke(actions);
        }

        public static void DoAction20Times(Action action, CancellationToken token)
        {
            Action[] actions = Enumerable.Repeat(action, 20).ToArray();
            Parallel.Invoke(new ParallelOptions { CancellationToken = token }, actions);
        }
    }
}
