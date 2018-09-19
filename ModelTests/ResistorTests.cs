using System.Numerics;
using Model.Elements;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Тесты класса Resistor")]
    internal class ResistorTests
    {
        #region Public methods

        [TestCase(20)]
        [TestCase(200)]
        [TestCase(20000)]
        [Description("Тест номинала на разные частоты")]
        public void CalculateZTest(double frequency)
        {
            Resistor resistor = new Resistor("R", 20);

            Complex expected = new Complex(20, 0);

            Assert.AreEqual(expected, resistor.CalculateZ(frequency));
        }

        #endregion
    }
}