using System.Collections.Generic;

namespace NeuralNetworks
{
    public class Topology
    {
        public int InputCount { get; }
        public int OutputCount { get; }
        public List<int> HiddenLayers { get; }

        public Typology(int inputCount, int outputCount, double learningRate, params int[] layers)
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            learningRate = learningRate;
            HiddenLayers = new List<int>();
            HiddenLayers.addRange(layers);

        }
    }
}