using System.Collections.Generic;
using Data.Models;

namespace Providers.CharacterProviders
{
    public interface ISkillProvider
    {
        IEnumerable<Skill> GetDefaultSkills(LevelModifiers modifiers, Stat strStat, Stat dexStat, Stat wisStat, Stat intStat,
            Stat chaStat);
    }
}
