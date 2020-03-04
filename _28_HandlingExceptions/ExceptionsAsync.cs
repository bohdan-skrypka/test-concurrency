using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _028_HandlingExceptions
{
    public class ExceptionsAsync
    {
        public static async Task ThrowExceptionAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            throw new InvalidOperationException("Test");
        }

        public static async Task TestAsync()
        {
            try
            {
                await ThrowExceptionAsync();
            }
            catch (InvalidOperationException inEx)
            {
                Console.WriteLine(inEx.Message);
            }
        }

        public static async Task TestAsyncExc()
        {
            var task = ThrowExceptionAsync();
            try
            {
                await task;
            }
            catch (InvalidOperationException inEx)
            {
                Console.WriteLine(inEx.Message);
            }
        }
    }
}
