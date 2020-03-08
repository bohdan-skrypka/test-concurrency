using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nito.AsyncEx;
using System.Threading.Tasks;

namespace UtestAsyncMethods
{
    class Unittests
    {
        /// <summary>
        /// Test of normal async method
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task UtestMethdod()
        {
            var res = await AsyncMthod();
            Assert.IsFalse(res);
        }

        /// <summary>
        /// Nito.AsyncContex.Run  method will wait until all tasks completed; nice to test Async VOid methods with it
        /// </summary>
        /// <returns></returns>
        public void MyMethodAsync()
        {
            AsyncContext.Run(async () =>
            {
                var res = await AsyncMthod();
                Assert.IsFalse(res);
            });
        }

        public Task<bool> AsyncMthod() => Task.FromResult(true);
    }
}
