using System.Collections.Generic;

namespace NeuralNetworks
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public List<double> Inputs { get;}
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }
        public double Delta { get; private set;}

        public Neuron(int inputCount, NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();
            Inputs = new List<double>();
            
            InitWeightsRandomValue(inputCount);
           
        }

        private void InitWeightsRandomValue(int inputCount)
        {
             for (int i = 0; i < inputCount; i++)
            {
                if (NeuronType == NeuronType.Input)
                {
                    Weights.Add(1);
                }
                else 
                {
                    Weights.Add(rnd.NextDouble());
                }
                Inputs.Add(0);
            }
        }

        public double FeedForward(List<double> inputs)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                Inputs[i] = inputs[i]
            }
            var sum = 0.0;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }
            if (NeuronType = NeuronType.Input)
            {
                Output = Sigmoid(sum);
            }
            else
            {
                Output = sum;
            }
            
            return Output;
        }

        private double Sigmoid(double x)
        {
            var result = 1.0 / (1.0 + Math.Pow(Math.E, -x));
            return result;
        }

        private double SigmoidDx()
        {
            var sigmoid = Sigmoid(x);
            var result = sigmoid / (1 - sigmoid);
            return result;
        }

        public void Learn(double error, double learningRate)
        {
            if (neuronType == NeuronType.Input)
            {
                return;
            }

            var delta = error * SigmoidDx(Output);//output текущее значение нейрона

            for (int i = 0; i < Weights.Count; i++)
            {
                var weight = Weights[i];
                var input = Inputs[i];

                var newWeight = weight - input * delta * learningRate;
                Weights[i] = newWeight;
            }

            Delta = delta;

        }

        public void SetWeights(params double[] weights)
        {
            //TODO: удалить после добавления возможности обучения сети

            for(int i = 0; i < weights.Length; i++)
            {
                Weights[i] = weights[i];
            }
        }
        
        public override string ToString()
        {
            return Type.ToString();
        }

    }
}