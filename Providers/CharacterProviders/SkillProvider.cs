using System.Collections.Generic;
using Data.Models;

namespace Providers.CharacterProviders
{
    public class SkillProvider : ISkillProvider
    {
        public IEnumerable<Skill> GetDefaultSkills(LevelModifiers modifiers, Stat strStat, Stat dexStat, Stat wisStat, Stat intStat, Stat chaStat)
        {
            return new List<Skill>
            {
                GetDefaultSkills(dexStat, modifiers, SkillType.Acrobatics),
                GetDefaultSkills(wisStat, modifiers, SkillType.AnimalHandling),
                GetDefaultSkills(intStat, modifiers, SkillType.Arcana),
                GetDefaultSkills(strStat, modifiers, SkillType.Athletics),
                GetDefaultSkills(chaStat, modifiers, SkillType.Deception),
                GetDefaultSkills(intStat, modifiers, SkillType.History),
                GetDefaultSkills(wisStat, modifiers, SkillType.Insight),
                GetDefaultSkills(chaStat, modifiers, SkillType.Intimidation),
                GetDefaultSkills(intStat, modifiers, SkillType.Investigation),
                GetDefaultSkills(wisStat, modifiers, SkillType.Medicine),
                GetDefaultSkills(intStat, modifiers, SkillType.Nature),
                GetDefaultSkills(wisStat, modifiers, SkillType.Perception),
                GetDefaultSkills(chaStat, modifiers, SkillType.Performance),
                GetDefaultSkills(chaStat, modifiers, SkillType.Persuasion),
                GetDefaultSkills(intStat, modifiers, SkillType.Religion),
                GetDefaultSkills(dexStat, modifiers, SkillType.SleightOfHand),
                GetDefaultSkills(dexStat, modifiers, SkillType.Stealth),
                GetDefaultSkills(wisStat, modifiers, SkillType.Survival)
            };
        }

        private static Skill GetDefaultSkills(Stat stat, LevelModifiers modifiers, SkillType skillType)
        {
            return new Skill(stat, modifiers)
            {
                Type = skillType,
                ModifierType = ProficencyModifierType.None
            };
        }

    }
}
