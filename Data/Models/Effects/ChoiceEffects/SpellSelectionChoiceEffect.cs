using System.Linq;

namespace Data.Models.Effects.ChoiceEffects
{
    class SpellSelectionChoiceEffect : IEffect
    {
        private readonly int _choiceCount;

        public SpellSelectionChoiceEffect(int choiceCount)
        {
            _choiceCount = choiceCount;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            var choices = targetCharacter.SpellBook.GetNewSpellMultipleChoice(_choiceCount);

            foreach (var choice in choices)
            {
                targetCharacter.AddChoice(choice);
            }
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            // todo more choice removal support
            throw new System.NotImplementedException();
        }
    }
}
