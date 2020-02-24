using _024WaitingForSetOfTasksToComplete;
using System;

namespace WaitingForSetOfTasksToComplete
{
    class Program
    {
        static void Main(string[] args)
        {
            WhenAll.WaitAll().GetAwaiter().GetResult();
            WhenAll.WaitAllFromResult().GetAwaiter().GetResult();
            WhenAll.DownloadAllAsync(new string[] { "http://google.com", "http://google.com" }).GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");

            ExceptionsHandling.ObserveOneExceptionAsync().GetAwaiter().GetResult();
            ExceptionsHandling.ObserveAllExceptionsAsync().GetAwaiter().GetResult();
        }
    }
}
