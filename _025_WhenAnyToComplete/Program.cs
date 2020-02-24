using System;

namespace _025_WhenAnyToComplete
{
    class Program
    {
        static void Main(string[] args)
        {
            WhenAny.FirstRespondingUrlAsync("http://google.com", "http://google.com").GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");
        }
    }
}
