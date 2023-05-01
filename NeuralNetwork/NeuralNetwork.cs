using ShellProgressBar;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace NeuralNetwork
{
    [Serializable]
    public class NeuralNetwork
    {
        private readonly List<Layer> layers;

        public NeuralNetwork(params int[] sizes)
        {
            layers = new List<Layer>();

            for (int i = 0; i < sizes.Length - 1; i++)
            {
                layers.Add(new Layer(sizes[i], sizes[i + 1]));
            }
        }

        public double[] Predict(double[] inputs)
        {
            double[] outputs = FeedForward(inputs);
            return outputs;
        }

        public void Train(double[][] inputs, int[] targets, double learningRate, int epochs, string outputDirPath)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                var options = new ProgressBarOptions
                {
                    ForegroundColor = ConsoleColor.Yellow,
                    ForegroundColorDone = ConsoleColor.DarkGreen,
                    BackgroundColor = ConsoleColor.DarkGray,
                    BackgroundCharacter = '\u2593',
                    ProgressBarOnBottom = true,
                };
                var progressBar = new ProgressBar(inputs.Length, $"Epoch: {epoch + 1}/{epochs} ", options);
                double totalError = 0.0;
                stopwatch.Start();

                for (int i = 0; i < inputs.Length; i++)
                {
                    // Feed forward
                    double[] outputs = FeedForward(inputs[i]);

                    // Calculate target output
                    double[] target = new double[outputs.Length];
                    target[targets[i]] = 1;

                    // Calculate output error
                    double[] outputError = new double[outputs.Length];

                    for (int j = 0; j < outputs.Length; j++)
                    {
                        outputError[j] = (target[j] - outputs[j]) * Layer.SigmoidDerivative(outputs[j]);
                        totalError += Math.Abs(outputError[j]);
                    }

                    //Console.WriteLine($"Output error: {outputError.Select(Math.Abs).Sum()} ");

                    BackPropagation(inputs[i], outputError, learningRate);

                    progressBar.Tick();
                }

                stopwatch.Stop();
                progressBar.Dispose();
                Console.WriteLine($"Total error = {totalError / inputs.Length * 100:F2}% | Training time: {stopwatch.Elapsed.Hours}h {stopwatch.Elapsed.Minutes}m {stopwatch.Elapsed.Seconds}s ({stopwatch.Elapsed.TotalMilliseconds:F0}ms)");

                // Saving neutal network
                string filePath = outputDirPath + $"\\NeuralNetwork_epoch_{epoch + 1}.nn";
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    Console.WriteLine($"File with neural network saved in: {filePath}");
                }

                stopwatch.Reset();
            }
        }

        public double[] FeedForward(double[] inputs)
        {
            double[] output = inputs;

            foreach (Layer layer in layers)
            {
                output = layer.FeedForward(output);
            }
            return output;
        }

        private void BackPropagation(double[] input, double[] outputError, double learningRate)
        {
            for (int i = layers.Count - 1; i >= 0; i--)
            {
                outputError = layers[i].BackPropagation(i == 0 ? input : layers[i - 1].Neurons, outputError, learningRate);
            }
        }
    }
}
