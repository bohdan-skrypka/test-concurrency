using System;

namespace _02_AsyncBasic
{
    class Program
    {
        private const string Url = "http://google.com";

        static async void Main(string[] args)
        {
            await PausingForPeriodTime.DownloadStringWithRetries(Url);
            await PausingForPeriodTime.DownloadStringWithTimeout(Url);

            await PausingForPeriodTime.DelayResult<int>(4, TimeSpan.FromSeconds(1.0));

            Console.WriteLine("Hello World!");
        }
    }
}
