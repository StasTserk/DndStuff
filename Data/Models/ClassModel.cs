using System;

namespace Data.Models
{
    public class PlayerClass
    {
        public string Name;
    }

    public class ClassAbility
    {
        public string Description;
        public AbilityType Type;
        public short LevelObtained;
    }

    public enum AbilityType
    {
        Proficiency,
        Passive,
        Active
    }
}
