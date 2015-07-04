using System;

namespace Data.Models.Effects.BackgroundEffects
{
    class AddIdealsEffect : IEffect
    {
        private readonly string _ideal;

        public AddIdealsEffect(string ideal)
        {
            _ideal = ideal;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.AddBackgroundIdeal(_ideal);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.RemoveBackgroundIdeal(_ideal);
        }
    }
}
