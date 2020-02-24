using System;
using System.Threading.Tasks;

namespace _022_ReturningCompletedTasks
{
    interface IMyAsyncInterface
    {
        Task<int> GetValueAsync();
    }

    public class ReturningCompletedTasks : IMyAsyncInterface
    {
        /// <summary>
        /// if you are frequently use stub for some methods just make this one line
        /// and avoid additional heap allocation with new object on each method call 
        /// </summary>
        private static readonly Task<int> zeroTask = Task.FromResult(0);

        /// <summary>
        /// Stub with constant value
        /// </summary>
        /// <returns></returns>
        public Task<int> GetValueAsync()
        {
            return zeroTask;
        }

        /// <summary>
        /// Stub for the base method which one can throw one of the most exceptions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<T> NotImplementedAsync<T>(T value)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetException(new NotImplementedException());
            return tcs.Task;
        }
    }
}
