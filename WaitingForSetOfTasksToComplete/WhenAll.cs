using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace _024WaitingForSetOfTasksToComplete
{
    class WhenAll
    {
        public static async Task WaitAll()
        {
            Task task1 = Task.Delay(TimeSpan.FromSeconds(1));
            Task task2 = Task.Delay(TimeSpan.FromSeconds(2));
            Task task3 = Task.Delay(TimeSpan.FromSeconds(1));

            await Task.WhenAll(task1, task2, task3);
        }

        public static async Task WaitAllFromResult()
        {
            Task<int> t1 = Task.FromResult(1);
            Task<int> t2 = Task.FromResult(2);
            Task<int> t3 = Task.FromResult(3);

            int[] res = await Task.WhenAll(t1, t2, t3);
        }

        public static async Task<string> DownloadAllAsync(IEnumerable<string> urls)
        {
            var httpClient = new HttpClient();
            var download = urls.Select(url => httpClient.GetStringAsync(url));
            string[] htmlPages = await Task.WhenAll(download);

            return string.Concat(htmlPages);
        }
    }
}
