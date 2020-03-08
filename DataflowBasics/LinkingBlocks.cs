using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataflowBasics
{
    class LinkingBlocks
    {
        public static async Task TestDataFlow()
        {
            var multBlock = new TransformBlock<int, int>(item => item * 2);
            var substractBlock = new TransformBlock<int, int>(item => item - 2);

            var options = new DataflowLinkOptions { PropagateCompletion = true };
            multBlock.LinkTo(substractBlock, options);

            try
            {
                var block = new TransformBlock<int, int>(item =>
                {
                    if (item == 1)
                    {
                        throw new System.Exception("Test");
                    }

                    return item * 2;
                });
                block.Post(1);
                block.Post(1);

                await block.Completion;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
