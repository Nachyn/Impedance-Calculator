using System;
using Model.Events;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Тесты класса ElementValueEventArgs")]
    internal class ElementValueEventArgsTests
    {
        #region Public methods

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10230)]
        [TestCase(-2000.2)]
        [TestCase(-100000000000)]
        [Test(Description = "Негативный Тест номинала у аргумента события")]
        public void NegativeValueTest(double value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ElementValueEventArgs args = new ElementValueEventArgs("Message", value);
            });
        }

        [Test(Description = "Тест сообщения у аргумента события")]
        public void MessageTest()
        {
            string message = Guid.NewGuid().ToString();
            ElementValueEventArgs args = new ElementValueEventArgs(message, 1);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        [Test(Description = "Негативный Тест имени у аргумента события")]
        public void NegativeMessageTest(string message)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ElementValueEventArgs args = new ElementValueEventArgs(message, 1);
            });
        }

        #endregion
    }
}