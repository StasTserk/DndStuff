using System;

namespace Data.Models.Effects.BackgroundEffects
{
    class AddPersonalityTraitEffect : IEffect
    {
        private readonly string _personalityTrait;

        public AddPersonalityTraitEffect(string personalityTrait)
        {
            _personalityTrait = personalityTrait;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.AddBackgroundTrait(_personalityTrait);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.RemoveBackgroundTrait(_personalityTrait);
        }
    }
}
