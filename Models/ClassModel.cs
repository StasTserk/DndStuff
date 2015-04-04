using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5thEdTools.Models
{
    class PlayerClass
    {
        public String Name;
        
    }

    class ClassAbility
    {
        public String Description;
        public AbilityType Type;
        public short LevelObtained;
    }

    enum AbilityType
    {
        Proficiency,
        Passive,
        Active
    }
}
