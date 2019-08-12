using ArmyStarter.Blazor.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ArmyStarter.Test
{
    [TestClass]
    public class CalculatorProviderTest
    {
        private CalculatorProvider _calculatorProvider;

        [TestInitialize]
        public void TestInit()
        {
            _calculatorProvider = new CalculatorProvider();
        }


        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 3)]
        [DataRow(6, 1)]
        public void ToHitResultTest(int toHit, int expectedResult)
        {
            var toHitResult = _calculatorProvider.GetToHitResult(toHit);

            Assert.AreEqual(decimal.Divide(expectedResult, 6), toHitResult);
        }
    }
}
