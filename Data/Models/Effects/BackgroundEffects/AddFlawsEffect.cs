using System;

namespace Data.Models.Effects.BackgroundEffects
{
    class AddFlawsEffect : IEffect
    {
        private readonly string _flaws;

        public AddFlawsEffect(string flaws)
        {
            _flaws = flaws;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.AddBackgroundFlaw(_flaws);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.RemoveBackgroundFlaw(_flaws);
        }
    }
}
