using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterSheetVisualizer.Model
{
    public class StatService
        : IStatService
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