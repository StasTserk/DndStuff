using System;
using System.Linq;
using Data.Models.Choices;

namespace Data.Models.Effects.ChoiceEffects
{
    public class ClassCustomizationChoiceEffect : IChoiceEffect
    {
        private readonly IModifiableChoice _choice;
        private readonly CharacterClassType _classType;
        private IChoiceOption _chosenOption;

        public ClassCustomizationChoiceEffect(IModifiableChoice choice, CharacterClassType classType)
        {
            _choice = choice;
            _classType = classType;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.AddChoice(_choice);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.RemoveChoice(_choice);
        }

        public void ApplyChoiceToCharacter(IChoiceOption choice, Character playerCharacter)
        {
            if (!_choice.GetChoices().Contains(choice)) return;

            _chosenOption = choice;

            foreach (var choiceEffect in _chosenOption.ChoiceEffects)
            {
                choiceEffect.ApplyToCharacter(playerCharacter);
            }
        }

        public void RemoveChoiceFromCharacter(Character playerCharacter)
        {
            if (_chosenOption == null) return;

            foreach (var effect in _chosenOption.ChoiceEffects)
            {
                effect.RemoveFromCharacter(playerCharacter);
            }
            _chosenOption = null;
        }

        public CharacterClassType TargetClass { get { return _classType; } }

        public IChoice Choice { get { return _choice; } }

        public IModifiableChoice ChoiceAsModifiable { get { return _choice; } }
    }
}
