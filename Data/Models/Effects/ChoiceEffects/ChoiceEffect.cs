using System.Linq;
using Data.Models.Choices;

namespace Data.Models.Effects.ChoiceEffects
{
    public class ChoiceEffect : IChoiceEffect
    {
        private IChoiceOption _chosenOption;
        private readonly IChoice _choice;

        public ChoiceEffect(IChoice choice)
        {
            _choice = choice;
        }

        public void ApplyChoiceToCharacter(IChoiceOption chosenOption, Character playerCharacter)
        {
            if (!_choice.Choices.Contains(chosenOption)) return;

            _chosenOption = chosenOption;
            foreach (var choiceEffect in _chosenOption.ChoiceEffects)
            {
                choiceEffect.RemoveFromCharacter(playerCharacter);
            }
        }

        public void RemoveChoiceFromCharacter(Character playerCharacter)
        {
            if (_chosenOption == null) return;
            foreach (var choiceEffect in _chosenOption.ChoiceEffects)
            {
                choiceEffect.RemoveFromCharacter(playerCharacter);
            }
            _chosenOption = null;
        }

        public IChoice Choice { get { return _choice; } }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.AddChoice(_choice);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.RemoveChoice(_choice);
        }
    }
}
