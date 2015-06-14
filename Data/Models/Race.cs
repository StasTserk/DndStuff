using System.Collections.Generic;
using Data.Models.Effects;

namespace Data.Models
{
    public class Race : IEffect
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IEffect> Effects { get; set; }
        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.Race = this;
            foreach (var effect in Effects)
            {
                effect.ApplyToCharacter(targetCharacter);
            }
        }
        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.Race = null;
            foreach (var effect in Effects)
            {
                effect.RemoveFromCharacter(targetCharacter);
            }
        }
    }
}
