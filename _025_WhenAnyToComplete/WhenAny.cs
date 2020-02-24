using System.Net.Http;
using System.Threading.Tasks;

namespace _025_WhenAnyToComplete
{
    class WhenAny
    {
        /// <summary>
        /// WhenAny not throw original exception that mean to get errorMessage you need to
        /// await firstCompletedTask or evalueate Result of any tasks
        /// </summary>
        /// <param name="urlA"></param>
        /// <param name="urlB"></param>
        /// <returns></returns>
        public static async Task<int> FirstRespondingUrlAsync(string urlA, string urlB)
        {
            var httpClient = new HttpClient();

            Task<byte[]> downloadTaskA = httpClient.GetByteArrayAsync(urlA);
            Task<byte[]> downloadTaskB = httpClient.GetByteArrayAsync(urlB);

            Task<byte[]> completedTask = await Task.WhenAny(downloadTaskA, downloadTaskB);
            byte[] data = await completedTask;
            return data.Length;
        }
    }
}
