using _027_AvoidingContextForContinuations;
using System;
using System.Threading;

namespace AvoidingContextForContinuations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main" + Thread.CurrentThread.ManagedThreadId);

            AvoidContinueAwait.ResumeOnContextAsync().GetAwaiter().GetResult();
            AvoidContinueAwait.ResumeOnThreadPoolThread().GetAwaiter().GetResult();

            Console.WriteLine("Hello World!");
        }
    }
}
