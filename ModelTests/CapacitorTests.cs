using System;
using Model.Elements;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Тесты класса Capacitor")]
    internal class CapacitorTests
    {
        #region Public methods

        [TestCase(20)]
        [TestCase(200)]
        [TestCase(100000)]
        [Description("Тест номинала на разные частоты")]
        public void CalculateZTest(double frequency)
        {
            Capacitor capacitor = new Capacitor("C", 50);
            double expected = 1 / (2 * Math.PI * frequency * 50);


            Assert.AreEqual(expected, capacitor.CalculateZ(frequency).Imaginary, 0.001);
        }

        #endregion
    }
}