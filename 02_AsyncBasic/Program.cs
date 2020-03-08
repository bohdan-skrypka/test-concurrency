using System;
using System.Threading.Tasks;

namespace _02_AsyncBasic
{
    class Program
    {
        private const string Url = "http://google.com";

        public static void Main()
        {
            try
            {
                MainAsync(new string[] { }).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task MainAsync(string[] args)
        {
            await PausingForPeriodTime.DownloadStringWithRetries(Url);
            await PausingForPeriodTime.DownloadStringWithTimeout(Url);

            await PausingForPeriodTime.DelayResult<int>(4, TimeSpan.FromSeconds(1.0));

            Console.WriteLine("Hello World!");
        }
    }
}
