# Number recognition by a neural network
A simple neural network trained to recognize handwritten numbers

## Project structure
* **MnistLoader**
	* DLL
	* Is used in NeuralNetwork to load and parse training and test dataset
* **NeuralNetwork**
	* Console application
	* Is used to create a neural network on a training sample
	* Uses a test sample to test the accuracy of the neural network
* **TestingWithDrawing**
	* soon...

## Dataset
[The MNIST database of handwritten digits](http://yann.lecun.com/exdb/mnist/)
Has ***training*** set of 60,000 examples, and ***test*** set of 10,000 examples. The digist have been size-normalized and centered in a fixed-size image (28 x 28 pixels)

## Usage
You can create a neural network to recognize handwritten numbers with your own parameters
### Parameters
1. train images file path
2. train labels file path
3. test images file path
4. test labels file path
5. learning rate (from 0 to 1)
6. epochs (int number)
7. output dir path for storing neural networks (for each epoch)
8.  input layer size (must be 28*28 = 784)
9. ...N. hidden layers sizes (must be ints)
10. N+1. output layer size (must be 10)

### Example usage
```
.\NNBuilder\NeuralNetwork.exe 
.\train-images.idx3-ubyte 
.\train-labels.idx1-ubyte 
.\t10k-images.idx3-ubyte 
.\t10k-labels.idx1-ubyte 
0.01 
10 
'./neural networks' 
784 512 128 64 10
```
//image need
### Application of a neural network
The output file of the neural network can be loaded into TestingWithDrawing and you can check how the neural network works

## Training process theory (back propagatioin)
1. Initialize the weights of the neural network
2. Feed the input data through the network and calculate the output
3. Calculate the error between the predicted output and the actual output
4. Propagate the error backwards through the network and calculate the gradients of the weights
5. Adjust the weights using the gradients and a learning rate (a hyperparameter that determines how much the weights should be adjusted)
6. Repeat steps 2-5 for a certain number of epochs(iterations over the entire dataset)

