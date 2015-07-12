using System;

namespace Data.Models.Effects.SpellEffects
{
    class AddKnownSpellEffect : IEffect
    {
        private readonly string _spellName;

        public AddKnownSpellEffect(string spellName)
        {
            _spellName = spellName;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.SpellBook.AddSpellToSpellKnown(_spellName);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
