using Model.Circuits;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Тесты функционала SubcircuitBase")]
    internal class SubcircuitBaseTests
    {
        #region Public methods

        [Test(Description = "Тест инкремента Id у подцепи")]
        public void IdTest()
        {
            bool test = true;
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();
            ParallelSubcircuit parallelSubcircuit = new ParallelSubcircuit();

            if (seriesSubcircuit.Id == parallelSubcircuit.Id)
            {
                test = false;
            }

            Assert.AreEqual(true, test);
        }

        [Test(Description = "Тест на вызов события")]
        public void EventTest()
        {
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();
            bool test = false;
            seriesSubcircuit.ParentChanged += (sender, e) => { test = true; };
            seriesSubcircuit.Parent = new SeriesSubcircuit();
            Assert.AreEqual(true, test);
        }

        #endregion
    }
}