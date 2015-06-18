using System.Collections.Generic;

namespace Data.Models.Effects
{
    public class AddFeatureEffect : IFeatureEffect
    {
        private readonly CharacterFeature _feature;

        public AddFeatureEffect(CharacterFeature feature)
        {
            _feature = feature;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
           targetCharacter.AddFeatureEffect(this);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.RemoveFeatureEffect(this);
        }

        public IList<CharacterFeature> GetFeatureList(IList<CharacterFeature> featureList)
        {
            featureList.Add(_feature);
            return featureList;
        }
    }
}