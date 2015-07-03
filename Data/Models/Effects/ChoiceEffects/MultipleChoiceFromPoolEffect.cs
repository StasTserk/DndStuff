using System;
using System.Collections.Generic;
using Data.Models.Choices;

namespace Data.Models.Effects.ChoiceEffects
{
    class MultipleChoiceFromPoolEffect : IChoiceEffect
    {
        private readonly IEnumerable<IChoice> _commonChoices;

        public MultipleChoiceFromPoolEffect(IEnumerable<IChoice> commonChoices)
        {
            _commonChoices = commonChoices;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            foreach (var choice in _commonChoices)
            {
                targetCharacter.AddChoice(choice);
            }
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            foreach (var choice in _commonChoices)
            {
                targetCharacter.RemoveChoice(choice);
            }
        }

        public void ApplyChoiceToCharacter(IChoiceOption choice, Character playerCharacter)
        {
            throw new NotImplementedException();
        }

        public void RemoveChoiceFromCharacter(Character playerCharacter)
        {
            throw new NotImplementedException();
        }

        public IChoice Choice { get; private set; }
    }
}
