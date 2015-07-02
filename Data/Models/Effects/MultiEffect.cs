using System.Collections.Generic;

namespace Data.Models.Effects
{
    class MultiEffect : IEffect
    {
        private readonly IEnumerable<IEffect> _effects;

        public MultiEffect(IEnumerable<IEffect> effects)
        {
            _effects = effects;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            foreach (var effect in _effects)
            {
                effect.ApplyToCharacter(targetCharacter);
            }
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            foreach (var effect in _effects)
            {
                effect.RemoveFromCharacter(targetCharacter);
            }
        }
    }
}
