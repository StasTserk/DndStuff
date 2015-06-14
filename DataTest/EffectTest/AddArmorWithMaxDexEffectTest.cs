using Data.Models.Effects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests.EffectTest
{
    [TestClass]
    public class AddArmorWithMaxDexEffectTest
    {
        [TestMethod]
        public void AddArmorWithMaxDexEffectMaxStatPositive()
        {
            var effect = new ArmorWithMaxDexEffect(
                acBonus: 4, maxDex: 2);
            const int dexBonus = 3;
            const int expectedBonus = 2;

            var actual = effect.GetDexBonus(dexBonus);

            Assert.AreEqual(expectedBonus, actual);
        }

        [TestMethod]
        public void AddArmorWithMaxDexEffectMaxStatNegative()
        {
            var effect = new ArmorWithMaxDexEffect(
                acBonus: 4, maxDex: 3);
            const int dexBonus = 2;
            const int expectedBonus = 2;

            var actual = effect.GetDexBonus(dexBonus);

            Assert.AreEqual(expectedBonus, actual);
        }

        [TestMethod]
        public void AddArmorWithMaxDexEffectAcBonus()
        {
            var effect = new ArmorWithMaxDexEffect(
                acBonus: 4, maxDex: 2);
            const int expectedBonus = 4;

            var actual = effect.GetArmorClass(0);

            Assert.AreEqual(expectedBonus, actual);
        }
    }
}
