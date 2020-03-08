using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _31_Parallel
{
    class ParallelClass
    {
        static int ParallelSum(IEnumerable<int> values)
        {
            object mutex = new object();
            int res = 0;
            Parallel.ForEach(
                source: values,
                localInit: () => 0,
                body: (item, state, localValue) => localValue + item,
                localFinally: localValue =>
                {
                    lock (mutex)
                    {
                        res += localValue;
                    }
                });
            return res;
        }
    }

    public class RotateMatrix
    {
        void RotateMatrices(IEnumerable<Matrix> matrices, float degree)
        {
            Parallel.ForEach(matrices, x => x.Rotate(degree));
        }
    }

    class Matrix
    {
        public void Rotate(float degree)
        {

        }
    }
}
