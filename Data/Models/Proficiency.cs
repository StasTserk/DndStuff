namespace Data.Models
{
    /// <summary>
    /// Holds information about non-skill/stat proficiencies and their sources.
    /// </summary>
    public class Proficiency
    {
        public string Source { get; set; }
        public string Name { get; set; }

        public Proficiency(string source, string name)
        {
            Source = source;
            Name = name;
        }
    }
}
