namespace Data.Models
{
    /// <summary>
    /// Holds information about non-skill/stat proficiencies and their sources.
    /// </summary>
    public class Proficiency
    {
        private string Source;
        private string Name;

        public Proficiency(string source, string name)
        {
            Source = source;
            Name = name;
        }
    }
}
