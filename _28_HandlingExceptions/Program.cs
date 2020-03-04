using _028_HandlingExceptions;
using System;

namespace _28_HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionsAsync.TestAsync().GetAwaiter().GetResult();
            ExceptionsAsync.TestAsyncExc().GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");
        }
    }
}
