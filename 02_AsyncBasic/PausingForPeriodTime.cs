using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _02_AsyncBasic
{
    class PausingForPeriodTime
    {
        /// <summary>
        /// Simple delay implementation 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static async Task<T> DelayResult<T>(T result, TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }

        public static async Task<string> DownloadStringWithRetries(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var nextDelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i != 3; i++)
                {
                    try
                    {
                        return await httpClient.GetStringAsync(url);
                    }
                    catch
                    {
                    }

                    await Task.Delay(nextDelay);
                    nextDelay = nextDelay + nextDelay;
                }

                return await httpClient.GetStringAsync(url);
            }
        }

        public static async Task<string> DownloadStringWithTimeout(string url)
        {
            using (var client = new HttpClient())
            {
                var downloadTask = client.GetStringAsync(url);
                var timeOut = Task.Delay(3000);

                var completedTask = await Task.WhenAny(downloadTask, timeOut);
                if (completedTask == timeOut)
                {
                    return null;
                }

                return await downloadTask;
            }
        }
    }
}
