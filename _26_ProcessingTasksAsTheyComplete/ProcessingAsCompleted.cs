using Nito.AsyncEx;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _26_ProcessingTasksAsTheyComplete
{
    class ProcessingAsCompleted
    {
        /// <summary>
        /// Delay and return
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }

        static async Task<string> DelayAndReturnStringAsync(string str, int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return str;
        }

        /// <summary>
        /// Original solution with await of each time execution in line
        /// But we want to do processing of all tasks without waiting for the others complete
        /// </summary>
        /// <returns></returns>
        public static async Task ProcessTasksInLineAsync()
        {
            Task<int> taskA = DelayAndReturnAsync(1);
            Task<int> taskB = DelayAndReturnAsync(2);
            Task<int> taskC = DelayAndReturnAsync(2);
            Task<int> taskD = DelayAndReturnAsync(1);

            var tasks = new[] { taskA, taskB, taskC, taskD };

            foreach (var task in tasks)
            {
                var res = await task;
                Trace.WriteLine(res);
            }
        }

        /// <summary>
        /// High-level await method with awaiting its result
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private static async Task AwaitAndProcessAsync(Task<int> task)
        {
            var res = await task;
            Trace.WriteLine(res);
        }

        public static async Task ProcessTasksAsync()
        {
            Task<int> taskA = DelayAndReturnAsync(2);
            Task<int> taskB = DelayAndReturnAsync(1);
            Task<int> taskC = DelayAndReturnAsync(2);
            var tasks = new[] { taskA, taskB, taskC };

            var processingTasks = (from t in tasks
                                   select AwaitAndProcessAsync(t)).ToArray();

            await Task.WhenAll(processingTasks);
        }

        public static async Task ProcessTasksWithLinqAsync()
        {
            Task<int> taskA = DelayAndReturnAsync(1);
            Task<int> taskB = DelayAndReturnAsync(1);
            Task<int> taskC = DelayAndReturnAsync(1);
            var tasks = new[] { taskA, taskC, taskB };

            var processingTasks = tasks.Select(async t =>
            {
                Console.WriteLine("StartThread:" + Thread.CurrentThread.ManagedThreadId.ToString());
                var res = await t;
                Console.WriteLine("Value" + res.ToString());
                Console.WriteLine("EndThread:" + Thread.CurrentThread.ManagedThreadId.ToString());
            });

            await Task.WhenAll(processingTasks);

            await taskA;
            await taskB;
            await taskC;
        }

        /// <summary>
        /// Version with ordered tasks in row by completion time
        /// </summary>
        /// <returns></returns>
        public static async Task UseOrderByCompletionAsync()
        {
            Task<string> taskA = DelayAndReturnStringAsync("b", 4);
            Task<string> taskB = DelayAndReturnStringAsync("a", 3);

            Task<int> taskC = DelayAndReturnAsync(5);
            Task<int> taskD = DelayAndReturnAsync(1);
            var tasksWithStr = new[] { taskA, taskB };
            var tasks = new[] { taskC, taskD };

            foreach (var item in tasksWithStr.OrderByCompletion())
            {
                var result = await item;
                Console.WriteLine(result);
            }

            foreach (var item in tasks.OrderByCompletion())
            {
                var result = await item;
                Console.WriteLine(result);
            }
        }
    }
}
