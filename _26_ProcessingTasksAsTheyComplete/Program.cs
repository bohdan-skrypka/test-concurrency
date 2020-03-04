using System;

namespace _26_ProcessingTasksAsTheyComplete
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessingAsCompleted.ProcessTasksInLineAsync().GetAwaiter().GetResult();
            ProcessingAsCompleted.ProcessTasksAsync().GetAwaiter().GetResult();
            ProcessingAsCompleted.ProcessTasksWithLinqAsync().GetAwaiter().GetResult();

            ProcessingAsCompleted.UseOrderByCompletionAsync().GetAwaiter().GetResult();


            Console.WriteLine("Hello World!");
        }
    }
}
