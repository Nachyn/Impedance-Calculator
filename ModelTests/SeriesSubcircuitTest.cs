using System;
using Model.Circuits;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Тесты класса SeriesSubcircuit")]
    internal class SeriesSubcircuitTest
    {
        #region Public methods

        [Test(Description = "Негативный тест на расчет.")]
        public void NegativeCalculateZTest()
        {
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();
            Assert.Throws<InvalidOperationException>(() => { seriesSubcircuit.CalculateZ(1); });
        }

        #endregion
    }
}