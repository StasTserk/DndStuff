using System;
using System.Linq;

namespace Data.Models.Effects.ChoiceEffects
{
    class StatBasedSpellChoiceEffect : IEffect
    {
        private readonly int _baseCount;
        private readonly StatType _statType;

        public StatBasedSpellChoiceEffect(StatType statType, int baseCount)
        {
            _statType = statType;
            _baseCount = baseCount;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            Stat stat = targetCharacter.Stats.First(s => s.Type == _statType);

            var choices = targetCharacter.SpellBook.GetNewSpellMultipleChoice(stat.Modifier + _baseCount);

            foreach (var choice in choices)
            {
                targetCharacter.AddChoice(choice);
            }
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
