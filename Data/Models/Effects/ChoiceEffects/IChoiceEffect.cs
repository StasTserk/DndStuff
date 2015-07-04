using System.Collections.Generic;
using Data.Models.Choices;

namespace Data.Models.Effects.ChoiceEffects
{
    public interface IChoiceEffect : IEffect
    {
        void ApplyChoiceToCharacter(IChoiceOption choice, Character playerCharacter);
        void RemoveChoiceFromCharacter(Character playerCharacter);
        IChoice Choice { get; }
    }
}
