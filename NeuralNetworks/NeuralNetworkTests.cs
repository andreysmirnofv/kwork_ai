namespace NeuralNetwork
{
    [TestClass()]
    public class NeuralNetworkTests
    {
        [TestMethod()]
        public void FeedForward()
        {
            //результат - пациент болен - 1
            //            пациент здоро - 0
            // не правильная температура T
            // хороший возраст A
            // купит S
            // правильно питается F
            //                                       T  A  S  F
            new Tuple<double, double[]> (0, new double[] { 0, 0, 0, 0 })
            new Tuple<double, double[]> (0, new double[] { 0, 0, 0, 1 })
            new Tuple<double, double[]> (1, new double[] { 0, 0, 1, 0 })
            new Tuple<double, double[]> (0, new double[] { 0, 0, 1, 1 })
            new Tuple<double, double[]> (0, new double[] { 0, 1, 0, 0 })
            new Tuple<double, double[]> (0, new double[] { 0, 1, 0, 1 })
            new Tuple<double, double[]> (1, new double[] { 0, 1, 1, 0 })
            new Tuple<double, double[]> (1, new double[] { 0, 1, 1, 1 })
            new Tuple<double, double[]> (1, new double[] { 1, 0, 0, 0 })
            new Tuple<double, double[]> (1, new double[] { 1, 0, 0, 1 })
            new Tuple<double, double[]> (1, new double[] { 1, 0, 1, 0 })
            new Tuple<double, double[]> (1, new double[] { 1, 0, 1, 1 })
            new Tuple<double, double[]> (1, new double[] { 1, 1, 0, 0 })
            new Tuple<double, double[]> (0, new double[] { 1, 1, 0, 1 })
            new Tuple<double, double[]> (1, new double[] { 1, 1, 1, 0 })
            new Tuple<double, double[]> (1, new double[] { 1, 1, 1, 1 })

            var topology = new Topology(4, 1, 0.1, 16, 8);
            var neuralNetwork = new NeuralNetwork(topology);
            var defferencre = neuralNetwork.Learn(dataset, 50000);

            var results = new List<double>();
            foreach (var data in dataset)
            {
                var res = neuralNetwork.FeedForward(data.Item2).Output
                results.Add(res);
            }
            for (int i = 0; i < results.Count; i++)
            {
                var expected = Math.Round(dataset[i].Item1, 4);
                var actual = Math.Round(results[i], 4);
                Assert.AreEqual(expected, actual);
            }

            var result = NeuralNetwork.FeedForward(new Tuple<double, double[]> (1, new double[] { 0, 1, 1, 1 }));
        }
    }
}