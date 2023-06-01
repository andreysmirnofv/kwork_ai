using System.Collections.Generic;

namespace NeuralNetworks
{
    public class Layer 
    {
        public List<Neuron> Neurons { get; }
        public int NeuronCount => Neurons?.Count ?? 0;
        public NeuronType Type;

        public Layer(List<Neuron> neurons, NeuronType type = NeuronType.Normal)
        {
            Neurons = neurons;
            Type = type
        }

        public List<double> getSignals()
        {
            var result = new List<double>();

            foreach(var neuron in Neurons)
            {
                result.Add(neuron.Output);
            }

            return result;
        }
    }
}