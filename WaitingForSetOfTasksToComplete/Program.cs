using _024WaitingForSetOfTasksToComplete;
using System;

namespace WaitingForSetOfTasksToComplete
{
    class Program
    {
        static void Main(string[] args)
        {
            WhenAll.DownloadAllAsync(new string[] { "http://google.com", "http://google.com" }).GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");
        }
    }
}
