using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5thEdTools.Models
{
    public class Spell
    {
        public String Name;
        public List<String> Classes;
        public String CastingTime;
        public String Description;
        public String ShortDescription;
        public String School;
        public String Targets;
        public String Range;
        public String Save;
        public List<String> Materials;
        public int Level;
        public bool Concentration;
        public String Duration;
        public bool Overcastable;
        public String Components;
        public bool RequiresAttackRoll;
        public bool Ritual;
    }
}
