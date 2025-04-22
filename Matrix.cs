using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_MnozenieMacierzy
{
    public class Matrix
    {
        public int[,] Data { get; private set; }
        public int Size { get; private set; }

        public Matrix(int size, bool randomize = false)
        {
            Size = size;
            Data = new int[size, size];
            if (randomize)
                FillRandom();
        }

        private void FillRandom()
        {
            Random rand = new Random();
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Data[i, j] = rand.Next(1, 10);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    sb.Append(Data[i, j] + "\t");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }

}
