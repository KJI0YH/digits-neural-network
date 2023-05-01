using ShellProgressBar;
using System.Diagnostics;

namespace NeuralNetwork
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 9)
            {
                Console.WriteLine("Invalid arguments");
                Console.WriteLine("Usage: [train images file path] [train labels file path] [test images file path] [test labels file path] [learning rate (0..1)] [epochs] [output dir path] [layer sizes {2,}]");
                return;
            }


            // Get number of learning rate
            double learningRate;
            args[4] = args[4].Replace('.', ',');
            if (!double.TryParse(args[4], out learningRate) || learningRate < 0 || learningRate > 1)
            {
                Console.WriteLine($"Invalid learning rate: {args[4]}. It must be between 0 and 1");
                return;
            }

            // Get number of epochs
            int epochs;
            if (!int.TryParse(args[5], out epochs))
            {
                Console.WriteLine($"Invalid epochs value: {args[5]}. It must be integer value");
            }

            // Test dir name
            string outputDirPath = args[6];
            try
            {
                Directory.CreateDirectory(args[6]);
            }
            catch
            {
                throw new Exception($"Can not create directory: {args[6]}");
            }

            // Get sizes of layers
            int[] sizes = new int[args.Length - 7];

            for (int i = 7; i < args.Length; i++)
            {
                if (!int.TryParse(args[i], out sizes[i - 7]))
                {
                    throw new Exception($"Invalid layer size: {args[i]}");
                }
            }

            try
            {
                Console.WriteLine("Load training data...");
                var trainData = MnistLoader.MnistLoader.LoadData(args[0], args[1]);

                Console.WriteLine("Load testing data...");
                var testData = MnistLoader.MnistLoader.LoadData(args[2], args[3]);

                var trainImages = trainData.Item1;
                var trainLabels = trainData.Item2;

                var testImages = testData.Item1;
                var testLabels = testData.Item2;

                var nn = new NeuralNetwork(sizes);

                Console.WriteLine("Training...");

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Train neural network
                nn.Train(trainImages, trainLabels, learningRate, epochs, outputDirPath);
                stopwatch.Stop();
                Console.WriteLine($"Training time: {stopwatch.Elapsed.Hours}h {stopwatch.Elapsed.Minutes}m {stopwatch.Elapsed.Seconds}s ({stopwatch.Elapsed.TotalMilliseconds:F0}ms)");

                // Testing neural network
                var options = new ProgressBarOptions
                {
                    ForegroundColor = ConsoleColor.Yellow,
                    ForegroundColorDone = ConsoleColor.DarkGreen,
                    BackgroundColor = ConsoleColor.DarkGray,
                    BackgroundCharacter = '\u2593',
                    ProgressBarOnBottom = true,
                };
                var progressBar = new ProgressBar(testImages.Length, "Testing...", options);
                stopwatch.Restart();
                int correct = 0;
                for (int i = 0; i < testImages.Length; i++)
                {
                    var input = testImages[i];
                    var output = nn.Predict(input);
                    int predicted = Array.IndexOf(output, output.Max());
                    if (predicted == testLabels[i])
                    {
                        correct++;
                    }
                    progressBar.Tick();
                }

                double accuracy = (double)correct / testImages.Length;
                stopwatch.Stop();
                progressBar.Dispose();
                Console.WriteLine($"Accuracy: {accuracy * 100}%");
                Console.WriteLine($"Testing time: {stopwatch.Elapsed.Hours}h {stopwatch.Elapsed.Minutes}m {stopwatch.Elapsed.Seconds}s ({stopwatch.Elapsed.TotalMilliseconds:F0}ms)");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
