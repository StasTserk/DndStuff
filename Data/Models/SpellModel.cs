using System;
using System.Collections.Generic;

namespace DnD5thEdTools.Models
{
    public class Spell
    {
        public Spell()
        {
            Classes = new List<String>();
            Materials = new List<String>();
        }

        public String Name { get; set; }
        public List<String> Classes { get; set; }
        public String CastingTime { get; set; }
        public String Description { get; set; }
        public String ShortDescription { get; set; }
        public String School { get; set; }
        public String Targets { get; set; }
        public String Range { get; set; }
        public String Save { get; set; }
        public IEnumerable<String> Materials { get; set; }
        public int Level { get; set; }
        public bool Concentration { get; set; }
        public String Duration { get; set; }
        public bool Overcastable { get; set; }
        public String Components { get; set; }
        public bool RequiresAttackRoll { get; set; }
        public bool Ritual { get; set; }
    }
}
