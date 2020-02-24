using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _23_ReportingProgress
{
    class ProgressReport
    {
        private static bool isDone = false;

        public static async Task MethodAsync(IProgress<int> progress = null)
        {
            int percentComplete = 0;

            while (!isDone)
            {
                if (progress != null)
                {
                    progress.Report(percentComplete);
                }

                await Task.Delay(100);
                percentComplete += 10;

                if (percentComplete == 100)
                {
                    isDone = true;
                }
            }
        }

        public static async Task CallMethodAsync()
        {
            var progress = new Progress<int>();
            progress.ProgressChanged += (sender, obj) =>
            {
                Console.WriteLine($"Complete: {obj}");
            };

            await MethodAsync(progress);
        }
    }
}
