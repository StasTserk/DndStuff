using System;
using System.Linq;

namespace Data.Models.Effects
{
    public class SaveProficiencyEffect : ISaveProficiencyEffect
    {
        private readonly ProficencyModifierType _modifier;
        private readonly StatType _saveModified;

        public SaveProficiencyEffect(ProficencyModifierType modifier, StatType saveModified)
        {
            _modifier = modifier;
            _saveModified = saveModified;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.Stats.First(s => s.Type == _saveModified).AddSaveEffect(this);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.Stats.First(s => s.Type == _saveModified).RemoveSaveEffect(this);
        }

        public ProficencyModifierType GetSaveModifier(ProficencyModifierType baseSaveModifier)
        {
            return _modifier;
        }
    }
}
