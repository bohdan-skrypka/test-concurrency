using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _024WaitingForSetOfTasksToComplete
{
    class ExceptionsHandling
    {
        static async Task ThrowNotImplementedExceptionAsync()
        {
            throw new NotImplementedException();
        }

        static async Task ThrowinvalidOperationExceptionAsync()
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// will be catch first exception from the tasks
        /// </summary>
        /// <returns></returns>
        public static async Task ObserveOneExceptionAsync()
        {
            var t1 = ThrowinvalidOperationExceptionAsync();
            var t2 = ThrowNotImplementedExceptionAsync();

            try
            {
                await Task.WhenAll(t1, t2);
            }
            catch (Exception ex)
            {
                var e1 = t1.Exception;
                var e2 = t2.Exception;
            }
        }

        /// <summary>
        /// will be handled all exceptions from the tasks
        /// </summary>
        /// <returns></returns>
        public static async Task ObserveAllExceptionsAsync()
        {
            var t1 = ThrowNotImplementedExceptionAsync();
            var t2 = ThrowinvalidOperationExceptionAsync();

            var allTasks = Task.WhenAll(t1, t2);
            try
            {
                await allTasks;
            }
            catch
            {
                AggregateException aggregateException = allTasks.Exception;

                foreach (var item in aggregateException.InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                }
            }
        }
    }
}
