using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public class Character
        : ObservableObject
    {
        public IEnumerable<Stat> Stats { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public string PlayerName { get; set; }
        public string CharacterName { get; set; }
        public string RaceName { get; set; }
        public string AlignmentName { get; set; }
        public IEnumerable<Proficiency> OtherProficiencies { get; set; }
        public IEnumerable<string> FeaturesAndTraits { get; set; }
    }
}
