using System.Collections.Generic;
using Data.Models;
using Data.Models.Effects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests.EffectTest
{
    [TestClass]
    public class AddFeatureEffectTest
    {
        [TestMethod]
        public void TestGetFeatureList()
        {
            var feature = new CharacterFeature("tesetFeature", null, null, null);
            var effect = new AddFeatureEffect(feature);

            var featureList = new List<CharacterFeature>();
            var listReturned = effect.GetFeatureList(featureList);

            Assert.IsTrue(listReturned.Contains(feature));
        }

        // TODO adjust character to allow apply/remove testing
    }
}
