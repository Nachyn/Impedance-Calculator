using System;
using Model.Circuits;
using Model.Elements;
using Model.Events;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Тесты интерфейса ICircuitNode")]
    internal class ICircuitNodeTests
    {
        #region Public methods

        [Test(Description = "Тест правильности расчета сложной цепи")]
        public void NodesAddTest()
        {
            SeriesSubcircuit seriesRoot = new SeriesSubcircuit();
            SeriesSubcircuit seriesLeftOne = new SeriesSubcircuit();
            SeriesSubcircuit seriesRightOne = new SeriesSubcircuit();

            ParallelSubcircuit parallelLeftOne = new ParallelSubcircuit();
            ParallelSubcircuit parallelLeftTwo = new ParallelSubcircuit();

            seriesRoot.Nodes.Add(parallelLeftOne);
            seriesRoot.Nodes.Add(seriesRightOne);

            parallelLeftOne.Nodes.Add(new Resistor("R", 20));
            parallelLeftOne.Nodes.Add(seriesLeftOne);

            seriesLeftOne.Nodes.Add(new Resistor("R", 10));
            seriesLeftOne.Nodes.Add(parallelLeftTwo);

            parallelLeftTwo.Nodes.Add(new Resistor("R", 20));
            parallelLeftTwo.Nodes.Add(new Resistor("R", 20));

            seriesRightOne.Nodes.Add(new Resistor("R", 20));
            seriesRightOne.Nodes.Add(new Resistor("R", 20));

            Assert.AreEqual(50, seriesRoot.CalculateZ(1).Real, 0.01);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        [Test(Description = "Негативный Тест имени")]
        public void NegativeNameTest(string name)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ElementBase elementBase = new Resistor(name, 40);
            });
        }


        [Test(Description = "Тест имени у базового элемента")]
        public void NameTest()
        {
            string name = Guid.NewGuid().ToString().Substring(0, 5);
            ElementBase elementBase = new Resistor(name, 40);
        }

        [TestCase(-20)]
        [TestCase(-200)]
        [TestCase(-20000)]
        [Description("Негативный тест на отрицательный номинал")]
        public void NegativeValueTest(double resistance)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Resistor resistor = new Resistor("Message", resistance);
            });
        }

        [TestCase(0)]
        [TestCase(-100)]
        [TestCase(1000000000001)]
        [Description("Негативный тест на отрицательную частоту")]
        public void NegativeFrequencyTest(double frequency)
        {
            ElementBase elementBase = new Capacitor("C", 20);
            Assert.Throws<ArgumentException>(() => { elementBase.CalculateZ(frequency); });
        }

        [Test(Description = "Тест на вызов события")]
        public void EventHandlerTest()
        {
            Inductor inductor = new Inductor("I", 40);
            bool test = false;

            inductor.ValueChanged += (sender, argument) => { test = true; };

            inductor.Value = 50;

            Assert.AreEqual(true, test);
        }

        [TestCase(1)]
        [TestCase(2345)]
        [TestCase(1000)]
        [Test(Description = "Тест номинала у аргумента события")]
        public void EventArgsValueTest(
            double value)
        {
            ElementValueEventArgs args = new ElementValueEventArgs("Message", value);
        }

        #endregion
    }
}