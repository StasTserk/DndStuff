using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Effects.BackgroundEffects
{
    class AddBondsEffect : IEffect
    {
        private readonly string _bond;

        public AddBondsEffect(string bond)
        {
            _bond = bond;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.AddBackgroundBond(_bond);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.RemoveBackgroundBond(_bond);
        }
    }
}
