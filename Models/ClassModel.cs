using System;

namespace DnD5thEdTools.Models
{
    public class PlayerClass
    {
        public String Name;
    }

    public class ClassAbility
    {
        public String Description;
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
