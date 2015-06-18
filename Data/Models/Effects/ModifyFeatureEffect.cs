using System.Collections.Generic;
using System.Linq;

namespace Data.Models.Effects
{
    public class ModifyFeatureEffect : IFeatureEffect
    {
        private readonly CharacterFeature _newFeature;

        public ModifyFeatureEffect(CharacterFeature newFeature)
        {
            _newFeature = newFeature;
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
            featureList.Remove(
                featureList.FirstOrDefault(f => f.Name == _newFeature.Name));
            featureList.Add(_newFeature);
            return featureList;
        }
    }
}
