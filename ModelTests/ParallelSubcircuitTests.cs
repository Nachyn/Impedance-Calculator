using System;
using Model.Circuits;
using Model.Elements;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Тесты класса ParallelSubcircuit")]
    internal class ParallelSubcircuitTests
    {
        #region Public methods

        [Test(Description = "Негативный тест параллельного соединения на вычисление")]
        public void NegativeCalculateZTest()
        {
            ParallelSubcircuit parallel = new ParallelSubcircuit();
            parallel.Nodes.Add(new Resistor("R", 20));
            Assert.Throws<InvalidOperationException>(() => { parallel.CalculateZ(20); });
        }

        #endregion
    }
}