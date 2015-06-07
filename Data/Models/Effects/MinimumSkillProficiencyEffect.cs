using System;
using System.Linq;

namespace Data.Models.Effects
{
    class MinimumSkillProficiencyEffect : ISkillProficiencyEffect
    {
        private readonly SkillType _type;
        private readonly ProficencyModifierType _minimumModifierType;

        public MinimumSkillProficiencyEffect(SkillType type, ProficencyModifierType minimumModifierType)
        {
            _type = type;
            _minimumModifierType = minimumModifierType;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.Skills.First(s => s.Type == _type).AddSkillProficiencyEffect(this);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.Skills.First(s => s.Type == _type).RemoveSkillProficiencyEffect(this);
        }

        public ProficencyModifierType GetModifiedProficiency(ProficencyModifierType type)
        {
            switch (_minimumModifierType)
            {
                case ProficencyModifierType.Expert:
                    return _minimumModifierType;
                case ProficencyModifierType.Proficent:
                    return type == ProficencyModifierType.Expert ? type : _minimumModifierType;
                case ProficencyModifierType.JackOfAllTrades:
                    return type == ProficencyModifierType.None ? _minimumModifierType : type;
                case ProficencyModifierType.None:
                    return type;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
