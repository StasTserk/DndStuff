namespace Data.Models.Effects.SpellEffects
{
    class AddSpellsToSpellListEffect : IEffect
    {
        private readonly CharacterClassType _classType;
        private readonly int _maxLevel;

        public AddSpellsToSpellListEffect(CharacterClassType classType, int maxLevel)
        {
            _classType = classType;
            _maxLevel = maxLevel;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.SpellBook.AddSpellsToSpellList(_classType, _maxLevel);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            throw new System.NotImplementedException();
        }
    }
}
