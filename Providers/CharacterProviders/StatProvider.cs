using System.Collections.Generic;
using System.Linq;
using Data.Models;

namespace Providers.CharacterProviders
{
    public class StatProvider
        : IStatProvider
    {
        public IEnumerable<Stat> GetDefaultStats(LevelModifiers modifiers)
        {
            return from type in Types
                   select GetDefaultStat(type, modifiers);
        }

        private static Stat GetDefaultStat(StatType type, LevelModifiers modifiers)
        {
            return new Stat(modifiers)
            {
                Score = 10,
                Type = type,
                IsProficent = false
            };
        }

        private static readonly IEnumerable<StatType> Types = new HashSet<StatType>
        {
            StatType.Strength,
            StatType.Dexterity,
            StatType.Constitution,
            StatType.Intelligence,
            StatType.Wisdom,
            StatType.Charisma
        };
    }
}