using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Effects
{
    public class BonusSkillEffect : ISkillEffect
    {
        private readonly SkillType _skillType;
        private readonly int _skillBonus;

        public BonusSkillEffect(SkillType skillType, int skillBonus)
        {
            _skillType = skillType;
            _skillBonus = skillBonus;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.Skills.First(s => s.Type == _skillType).AddSkillEffect(this);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.Skills.First(s => s.Type == _skillType).RemoveSkillEffect(this);
        }

        public int GetAffectedSkillScore(int skillScore)
        {
            return _skillBonus + skillScore;
        }
    }
}
