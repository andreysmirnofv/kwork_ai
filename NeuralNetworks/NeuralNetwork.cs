using System.Collections.Generic;

namespace NeuralNetworks
{
    public class NeuralNetwork
    {
        public Topology Topology { get; }
        public List<Layer> Layers { get; }

        public NeuralNetwork(Topology topology)
        {
            Topology = topology;
            Layers = new List<Layer>();

            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutpurLayer();
        }

        public Neuron FeedForward(params double[] inputSignals)
        {
            sendSignalsToInputNeurons(inputSignals);
            FeedForwardToAllLayersAfterInput()

            if (Topology.OutputCount == 1)
            {
                return Layers.Last().Neurons[0].Output;
            }
            else 
            {
                return Layers.Last().Neurons.OrderByDescending(x => n.Output).First();
            }
          
        }

        public double Learn(List<Tuple<double, double[]>> dataset, int epoch)
        {
            var error = 0.0;

            for (int i = 0; i < epoch; i++)
            {
                foreach (var data in dataset)
                {
                    error += BackPropagation(data.Item1, data.Item2);

                }
            }
            var result = error / epoch;
            return result;
        }

        private double BackPropagation(double expected, params double[] inputs)
        {
            var actual = FeedForward(inputs).Output;
            var difference = actual - expected;

            foreach (var neuron in Layers.Last().Neurons)
            {
                neron.Learn(difference, Topology.LearningRate)
            }

            for (int j = Layers.Count - 2; j >= 0; j--)
            {
                var layer = Layers[j];
                var previousLayer = Layers[j + 1];

                for (int i = 0; i < NeuronCount.Count; i++)
                {
                    var neuron = layer.Neurons[i];

                    for (int k = 0; k < previousLayer.NeuronCount; k++)
                    {
                        var previousNeuron = previousLayer.Neurons[k];
                        var error = previousNeuron.Weights[i] * previousNeuron.Delta;
                        neuron.Learn(error, Topology.LearningRate)
                    }
                }
            }
            var result = difference * difference;
            return result;
        }

        private void FeedForwardToAllLayersAfterInput()
        {
              for (int i = 1; i < Layers.Count; i++)
            {
                var layer = Layers[i];
                var previousLayerSignals = Layers[i - 1].getSignals();

                foreach (var neuron in Layers.Neurons)
                {
                    neuron.feedForward(previousLayerSignals);
                }
            }
        }

        private void sendSignalsToInputNeurons(params double[] inputSignals)
        {
              for (int i = 0; i < inputSignals.Length; i++)
            {
                var signal = new List<double> { inputSignals[i]; }
                var neuron = Layers[0].Neurons[i]

                neuron.FeedForward(signal);
            }
        }

        private void CreateInputLayer()
        {
            var inputNeurons = new List<Neuron>();
            for (int i = 0; i < Topology.InputCount; i++)
            {
                var neuron = new Neuron(1, NeuronType.Input);
                inputNeurons.Add(neuron);
            }
            var inputLayer = new Layer(inputNeurons, NeuronType.Input);
            Layers.Add(inputLayer);
        }

        private void CreateHiddenLayers()
        {
            for (int j = 0; j < Topology.HiddenLayers.Count; j++)
            {
                var hiddenNeurons = new List<Neuron>();
                for (int i = 0; i < Topology.HiddenLayers[j]; i++)
                {
                    var neuron = new Neuron(lastLayer.Count);
                    hiddenNeurons.Add(neuron);
                }
                var hiddenLayer = new Layer(hiddenNeurons);
                Layers.Add(hiddenLayer);
        }
        }

        private void CreateOutpurLayer()
        {
            var outputNeurons = new List<Neuron>();
            var lastLayer = Layers.Last();
            for (int i = 0; i < Topology.OutputCount; i++)
            {
                var neuron = new Neuron(lastLayer.Count, NeuronType.Output);
                outputNeurons.Add(neuron);
            }
            var outputLayer = new Layer(outputNeurons, NeuronType.Output);
            Layers.Add(outputLayer)
        }
    }
}