using System;
using Model.Circuits;
using Model.Elements;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Тесты класса Circuit")]
    internal class CircuitTests
    {
        #region Public methods

        [Test(Description = "Тест на добавление элемента в цепь")]
        public void AddAfterTest()
        {
            Circuit circuit = new Circuit();
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();
            ParallelSubcircuit parallelSubcircuit = new ParallelSubcircuit();
            circuit.AddAfter(null, seriesSubcircuit);
            circuit.AddAfter(seriesSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(seriesSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(parallelSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(parallelSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(seriesSubcircuit, parallelSubcircuit);
            Assert.AreEqual(50, circuit.CalculateZ(new double[] {1})[0].Real, 0.01);
        }

        [Test(Description = "Тест на удаление элемента из цепи")]
        public void RemoveTest()
        {
            Circuit circuit = new Circuit();
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();
            ParallelSubcircuit parallelSubcircuit = new ParallelSubcircuit();
            circuit.AddAfter(null, seriesSubcircuit);
            circuit.AddAfter(seriesSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(seriesSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(parallelSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(parallelSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(seriesSubcircuit, parallelSubcircuit);
            circuit.Remove(parallelSubcircuit);
            Assert.AreEqual(40, circuit.CalculateZ(new double[] {1})[0].Real, 0.01);
        }

        [Test(Description = "Тест 2 на удаление элемента из цепи")]
        public void RemoveRootTest()
        {
            Circuit circuit = new Circuit();
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();

            circuit.AddAfter(null, seriesSubcircuit);
            circuit.Remove(seriesSubcircuit);
            if (circuit.Root != null)
            {
                throw new Exception("Корень был null");
            }
        }

        [Test(Description = "Тест на пустой корень при вычислении")]
        public void CalculateEmptyRootTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                Circuit circuit = new Circuit();
                circuit.CalculateZ(new double[] {1});
            });
        }

        [Test(Description = "Тест на пустой корень при удалении")]
        public void RemoveEmptyRootTest()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Circuit circuit = new Circuit();
                circuit.Remove(new Resistor("R", 20));
            });
        }

        #endregion
    }
}