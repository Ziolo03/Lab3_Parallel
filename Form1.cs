using System.Diagnostics;
using System.Windows.Forms;

namespace Lab3_MnozenieMacierzy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += btnStart_Click;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int size) || size <= 0)
            {
                MessageBox.Show("Podaj poprawny rozmiar macierzy > 0).");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int threads) || threads <= 0)
            {
                MessageBox.Show("Podaj poprawn¹ liczbê w¹tków > 0).");
                return;
            }

            Matrix A = new Matrix(size, true);
            Matrix B = new Matrix(size, true);

            const int iterations = 5;
            long totalTime = 0;

            for (int i = 0; i < iterations; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                Matrix result = MatrixMultiplier.Multiply(A, B, threads);

                sw.Stop();
                totalTime += sw.ElapsedMilliseconds;
            }

            long avgTime = totalTime / iterations;
            string entry = $"Rozmiar: {size}x{size}, W¹tki: {threads}, Œredni czas z {iterations} pomiarów: {avgTime} ms";

            listBox1.Items.Add(entry);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int size) || size <= 0)
            {
                MessageBox.Show("Podaj poprawny rozmiar macierzy > 0).");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int threads) || threads <= 0)
            {
                MessageBox.Show("Podaj poprawn¹ liczbê w¹tków > 0).");
                return;
            }

            Matrix A = new Matrix(size, true);
            Matrix B = new Matrix(size, true);

            const int iterations = 5;
            long totalTime = 0;

            for (int i = 0; i < iterations; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                Matrix result = ThreatMatrixMultiplier.MultiplyWithThreads(A, B, threads);

                sw.Stop();
                totalTime += sw.ElapsedMilliseconds;
            }

            long avgTime = totalTime / iterations;
            string entry = $"(THREAD) Rozmiar: {size}x{size}, W¹tki: {threads}, Œredni czas z {iterations} pomiarów: {avgTime} ms";

            listBox1.Items.Add(entry);
        }

    }
}