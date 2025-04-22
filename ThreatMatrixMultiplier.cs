using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_MnozenieMacierzy
{
    internal class ThreatMatrixMultiplier
    {
        public static Matrix MultiplyWithThreads(Matrix A, Matrix B, int numThreads)
        {
            int size = A.Size;
            Matrix result = new Matrix(size);

            Thread[] threads = new Thread[numThreads];

            int rowsPerThread = size / numThreads;
            int remainingRows = size % numThreads;

            for (int t = 0; t < numThreads; t++)
            {
                int startRow = t * rowsPerThread;
                int endRow = (t == numThreads - 1) ? size : startRow + rowsPerThread;

                threads[t] = new Thread(() =>
                {
                    for (int i = startRow; i < endRow; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            int sum = 0;
                            for (int k = 0; k < size; k++)
                                sum += A.Data[i, k] * B.Data[k, j];
                            result.Data[i, j] = sum;
                        }
                    }
                });

                threads[t].Start();
            }

            foreach (var thread in threads)
                thread.Join();

            return result;
        }
    }
}
