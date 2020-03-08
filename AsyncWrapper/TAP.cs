using System;
using System.Net;
using System.Threading.Tasks;
using Nito;

namespace AsyncWrapper
{
    public static class TAP
    {
        public static Task<string> AsyncWrapper(this WebClient webClient, Uri uri)
        {
            var tcs = new TaskCompletionSource<string>();

            DownloadStringCompletedEventHandler handler = null;
            handler = (_, e) =>
             {
                 webClient.DownloadStringCompleted -= handler;
                 if (e.Cancelled)
                 {
                     tcs.TrySetCanceled();
                 }
                 else if (e.Error != null)
                 {
                     tcs.TrySetException(e.Error);
                 }
                 else
                 {
                     tcs.TrySetResult(e.Result);
                 }
             };

            webClient.DownloadStringCompleted += handler;
            webClient.DownloadStringAsync(uri);

            return tcs.Task;
        }
    }
}
