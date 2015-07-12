using System;

namespace Data.Models.Effects.ChoiceEffects
{
    class LevelBasedSpellChoiceEffect : IEffect
    {
        private readonly int _choiceCount;
        private readonly int _spellLevel;

        public LevelBasedSpellChoiceEffect(int choiceCount, int spellLevel)
        {
            _choiceCount = choiceCount;
            _spellLevel = spellLevel;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            var choices = targetCharacter.SpellBook.GetNewSpellMultipleChoice(
                s=> s.Level == _spellLevel, _choiceCount);

            foreach (var choice in choices)
            {
                choice.ShortDescription =
                    string.Format(@"Pick a level {0} spell from the following list",
                        _spellLevel);
                targetCharacter.AddChoice(choice);
            }
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
