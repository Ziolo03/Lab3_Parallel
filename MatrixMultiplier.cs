using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_MnozenieMacierzy
{
    public class MatrixMultiplier
    {
        public static Matrix Multiply(Matrix A, Matrix B, int numThreads)
        {
            int size = A.Size;
            Matrix result = new Matrix(size);

            ParallelOptions options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = numThreads
            };

            Parallel.For(0, size, options, i =>
            {
                for (int j = 0; j < size; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < size; k++)
                        sum += A.Data[i, k] * B.Data[k, j];
                    result.Data[i, j] = sum;
                }
            });

            return result;
        }
    }

}
