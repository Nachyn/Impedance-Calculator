using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Elements;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Тесты класса Inductor")]
    class InductorTests
    {
        [TestCase(20)]
        [TestCase(200)]
        [TestCase(100000)]
        [Description("Тест номинала на разные частоты")]
        public void CalculateZTest(double frequency)
        {
            Inductor inductor = new Inductor("I", 50);
            double expected = 2 * Math.PI * frequency * 50;

            Assert.AreEqual(expected, inductor.CalculateZ(frequency).Imaginary, 0.001);
        }
    }
}
