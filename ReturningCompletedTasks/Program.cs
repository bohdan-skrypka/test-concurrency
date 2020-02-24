using System;
using _022_ReturningCompletedTasks;

namespace ReturningCompletedTasksT
{
    class Program
    {
        static void Main(string[] args)
        {
            var retComplTask = new ReturningCompletedTasks().NotImplementedAsync<int>(4);

            try
            {
                retComplTask.GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
