namespace MnistLoader
{
    public class MnistLoader
    {
        public static (double[][], int[]) LoadData(string imagesFilePath, string labelsFilePath)
        {
            if (!File.Exists(imagesFilePath))
            {
                throw new FileNotFoundException($"File {imagesFilePath} does not exists");
            }

            if (!File.Exists(labelsFilePath))
            {
                throw new FileNotFoundException($"File {labelsFilePath} does not exists");
            }

            byte[] images = File.ReadAllBytes(imagesFilePath);
            byte[] labels = File.ReadAllBytes(labelsFilePath);

            int magicNumber = ReadInt32(images, 0);

            int numberOfImages = ReadInt32(images, 4);
            Console.WriteLine($"Number of images: {numberOfImages}");

            int numberOfRows = ReadInt32(images, 8);
            Console.WriteLine($"Number of rows: {numberOfRows}");

            int numberOfCols = ReadInt32(images, 12);
            Console.WriteLine($"Number of cols: {numberOfCols}");

            int headerSize = 16;

            int[] targets = new int[numberOfImages];
            double[][] inputs = new double[numberOfImages][];

            for (int i = 0; i < numberOfImages; i++)
            {
                inputs[i] = new double[numberOfRows * numberOfCols];
                for (int j = 0; j < numberOfRows * numberOfCols; j++)
                {
                    inputs[i][j] = images[headerSize + i * numberOfRows * numberOfCols + j] / 255.0;
                }
                targets[i] = labels[8 + i];
            }
            return (inputs, targets);
        }

        private static int ReadInt32(byte[] buffer, int offset)
        {
            return buffer[offset] << 24 | buffer[offset + 1] << 16 | buffer[offset + 2] << 8 | buffer[offset + 3];
        }
    }
}
