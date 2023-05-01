using System.Runtime.Serialization.Formatters.Binary;

namespace NeuralNetworkTesting
{
    public partial class MainForm : Form
    {
        private Point? _lastPoint;
        private Bitmap _bitmap;
        private Graphics _graphics;
        private NeuralNetwork.NeuralNetwork? _neuralNetwork = null;

        public MainForm()
        {
            InitializeComponent();

            _bitmap = new Bitmap(pbImage.Width, pbImage.Height);
            _graphics = Graphics.FromImage(_bitmap);
        }

        private void pbImage_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = e.Location;
        }

        private void pbImage_MouseUp(object sender, MouseEventArgs e)
        {
            _lastPoint = null;
            Recognize();
        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (_lastPoint != null)
                {

                    using (var brush = new SolidBrush(e.Button == MouseButtons.Left ? Color.White : Color.Black))
                    {
                        _graphics.FillRectangle(brush, e.X - 9, e.Y - 9, 18, 18);
                    }
                    _lastPoint = e.Location;
                    pbImage.Invalidate();
                }
            }
        }

        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_bitmap, 0, 0);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _graphics.Clear(Color.Black);
            dgvDigits.Rows.Clear();
            pbImage.Invalidate();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ofdNeuralNetwork.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdNeuralNetwork.FileName;

                FileStream fileStream = new FileStream(filePath, FileMode.Open);

                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    _neuralNetwork = (NeuralNetwork.NeuralNetwork?)binaryFormatter.Deserialize(fileStream);
                    lblState.ForeColor = Color.Green;
                    lblState.Text = "The neural network is loaded";
                    dgvDigits.Rows.Clear();
                }
                catch (Exception ex)
                {
                    lblState.ForeColor = Color.Red;
                    lblState.Text = "Can not load a neutal network";
                }
                finally
                {
                    fileStream.Close();
                }
            }
        }

        private void Recognize()
        {
            try
            {
                double[] inputs = Normalize(new Bitmap(_bitmap, new Size(28, 28)));
                double[] outputs = _neuralNetwork.Predict(inputs);

                int prediction = Array.IndexOf(outputs, outputs.Max());

                double full = outputs.Sum();

                dgvDigits.Rows.Clear();
                for (int i = 0; i < outputs.Length; i++)
                {
                    dgvDigits.Rows.Add(i, $"{outputs[i] / full * 100:F2}%");
                }
                dgvDigits.Rows[prediction].Cells[0].Style.ForeColor = Color.Green;
                dgvDigits.Rows[prediction].Cells[1].Style.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblState.Text = "The neural network is invalid";
                lblState.ForeColor = Color.Red;
            }
        }

        private double[] Normalize(Bitmap resized)
        {
            double[] inputs = new double[28 * 28];
            int k = 0;
            for (int i = 0; i < resized.Width; i++)
            {
                for (int j = 0; j < resized.Height; j++)
                {
                    Color c = resized.GetPixel(j, i);
                    int gray = (c.R + c.G + c.B) / 3;
                    inputs[k++] = gray / 255.0;
                }
            }
            return inputs;
        }
    }
}