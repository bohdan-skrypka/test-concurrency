using System;

namespace DataflowBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkingBlocks.TestDataFlow().Wait();
        }
    }
}
