
using System;
using System.Threading;
using System.Threading.Tasks;

namespace _027_AvoidingContextForContinuations
{
    public class AvoidContinueAwait
    {
        public static async Task ResumeOnContextAsync()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task ResumeOnThreadPoolThread()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
