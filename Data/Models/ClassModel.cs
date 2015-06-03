namespace Data.Models
{
    public class PlayerClass
    {
        public string Name { get; set; }
    }

    public class ClassAbility
    {
        public string Description { get; set; }
        public AbilityType Type { get; set; }
        public short LevelObtained { get; set; }
    }

    public enum AbilityType
    {
        Proficiency,
        Passive,
        Active
    }
}
