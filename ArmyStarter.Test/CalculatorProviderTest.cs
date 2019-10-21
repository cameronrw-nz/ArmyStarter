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
        [DataRow(4, 3, 6, 0, 1)]
        [DataRow(4, 6, 12, 2, 5)]
        [DataRow(2, 4, 6, 1, 2.78)]
        public void TotalWoundsOnGuardsmenTest(int toHit, int strength, int attacks, int ap, double expectedResult)
        {
            var attackingModel = new AttackingModel { ToHit = toHit, Strength = strength, Attacks = attacks, AP = ap };
            var defendingModel = new DefendingModel { Name = "GEQ", Toughness = 3, ArmourSave = 5 };
            var totalWoundsResult = _calculatorProvider.GetTotalWoundsResult(attackingModel, defendingModel);

            Assert.AreEqual((decimal)expectedResult, totalWoundsResult);
        }

        [TestMethod]
        public void AutoHitOnGuardsmenTest()
        {
            var attackingModel = new AttackingModel { ToHit = 4, Strength = 6, Attacks = 12M, AP = 2, IsAutoHitting = true };
            var defendingModel = new DefendingModel { Name = "GEQ", Toughness = 3, ArmourSave = 5 };
            var totalWoundsResult = _calculatorProvider.GetTotalWoundsResult(attackingModel, defendingModel);

            Assert.AreEqual((decimal)10, totalWoundsResult);
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

        [DataTestMethod]
        [DataRow(4, 2, 5)]
        [DataRow(4, 3, 4)]
        [DataRow(4, 4, 3)]
        [DataRow(4, 5, 2)]
        [DataRow(4, 6, 2)]
        [DataRow(4, 7, 2)]
        [DataRow(4, 8, 1)]
        [DataRow(8, 3, 5)]
        [DataRow(8, 7, 4)]
        [DataRow(8, 8, 3)]
        [DataRow(8, 9, 2)]
        public void ToWoundResult(int strength, int toughness, int expectedResult)
        {
            var toWoundResult = _calculatorProvider.GetToWoundResult(strength, toughness);

            Assert.AreEqual(decimal.Divide(expectedResult, 6), toWoundResult);
        }

        [DataTestMethod]
        [DataRow(2, 2, null, 3)]
        [DataRow(2, 0, null, 1)]
        [DataRow(4, 2, null, 5)]
        [DataRow(2, 3, 3, 4)]
        public void SaveResult(int ap, int armourSave, int? invulerableSave, int expectedResult)
        {
            var toSaveResult = _calculatorProvider.GetSaveResult(ap, armourSave, invulerableSave ?? 0);

            Assert.AreEqual(decimal.Divide(expectedResult, 6), toSaveResult);
        }
    }
}
