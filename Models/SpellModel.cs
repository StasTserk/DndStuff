using System;
using System.Collections.Generic;

namespace DnD5thEdTools.Models
{
    public class Spell
    {
        public String Name;
        public IEnumerable<String> Classes;
        public String CastingTime;
        public String Description;
        public String ShortDescription;
        public String School;
        public String Targets;
        public String Range;
        public String Save;
        public IEnumerable<String> Materials;
        public int Level;
        public bool Concentration;
        public String Duration;
        public bool Overcastable;
        public String Components;
        public bool RequiresAttackRoll;
        public bool Ritual;
    }
}
