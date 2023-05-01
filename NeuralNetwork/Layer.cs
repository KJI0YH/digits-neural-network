namespace NeuralNetwork
{
    [Serializable]
    public class Layer
    {
        public readonly int InputSize;
        public readonly int OutputSize;
        public readonly double[] Biases;
        public readonly double[,] Weights;
        public readonly double[] Neurons;

        public Layer(int inputSize, int outputSize)
        {
            InputSize = inputSize;
            OutputSize = outputSize;
            Neurons = new double[outputSize];
            Biases = new double[outputSize];
            Weights = new double[inputSize, outputSize];

            for (int j = 0; j < OutputSize; j++)
            {
                Biases[j] = RandomDouble(-1.0, 1.0);
                for (int i = 0; i < InputSize; i++)
                {
                    Weights[i, j] = RandomDouble(-1.0, 1.0);
                }
            }
        }

        public double[] FeedForward(double[] inputs)
        {
            for (int j = 0; j < OutputSize; j++)
            {
                double output = Biases[j];
                for (int i = 0; i < InputSize; i++)
                {
                    output += inputs[i] * Weights[i, j];
                }
                Neurons[j] = Sigmoid(output);
            }
            return Neurons;
        }

        public double[] BackPropagation(double[] inputs, double[] outputError, double learningRate)
        {
            double[] inputError = new double[InputSize];
            for (int i = 0; i < InputSize; i++)
            {
                double sum = 0;
                for (int j = 0; j < OutputSize; j++)
                {
                    sum += outputError[j] * Weights[i, j];
                    Weights[i, j] += outputError[j] * learningRate * inputs[i];
                }
                inputError[i] = sum * SigmoidDerivative(inputs[i]);
            }

            for (int j = 0; j < OutputSize; j++)
            {
                Biases[j] += outputError[j] * learningRate;
            }

            return inputError;
        }

        public static double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public static double SigmoidDerivative(double x)
        {
            return x * (1.0 - x);
        }

        private double RandomDouble(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
