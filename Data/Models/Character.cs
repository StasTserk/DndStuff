using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public class Character
        : ObservableObject
    {
        public IEnumerable<Stat> Stats { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public string PlayerName;
        public string CharacterName;
        public string RaceName;
        public string AlignmentName;
        public IEnumerable<Proficiency> OtherProficiencies;
        public IEnumerable<string> FeaturesAndTraits;
    }
}
