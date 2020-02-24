using System;

namespace _23_ReportingProgress
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgressReport.CallMethodAsync().GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
