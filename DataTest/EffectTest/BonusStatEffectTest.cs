using Data.Models;
using Data.Models.Effects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests.EffectTest
{
    [TestClass]
    public class BonusStatEffectTest
    {
        [TestMethod]
        public void TestGetAffectedStatScore()
        {
            // arrange
            var effect = new BonusStatEffect(StatType.Constitution, 2);
            const int expected = 2;
            
            // act
            int actual = effect.GetAffectedStatScore(0);

            // assert
            Assert.AreEqual(expected, actual);
        }
        
        // TODO either make stats vitual or an interface and test Apply/Remove
    }
}
