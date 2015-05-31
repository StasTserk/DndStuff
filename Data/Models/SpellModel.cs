using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Spell
    {
        public Spell()
        {
            Classes = new List<string>();
            Materials = new List<string>();
        }

        public string Name { get; set; }
        public ICollection<string> Classes { get; set; }
        public string CastingTime { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string School { get; set; }
        public string Targets { get; set; }
        public string Range { get; set; }
        public string Save { get; set; }
        public IEnumerable<string> Materials { get; set; }
        public int Level { get; set; }
        public bool Concentration { get; set; }
        public string Duration { get; set; }
        public bool Overcastable { get; set; }
        public string Components { get; set; }
        public bool RequiresAttackRoll { get; set; }
        public bool Ritual { get; set; }
    }
}
