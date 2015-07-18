using System.Collections.Generic;
using DnD5thEdTools.Models;
using DnD5thEdTools.Repositories;

namespace MVVMViews.Design
{
    class DesignSpellLoader
        : ISpellLoader
    {
        public IEnumerable<Spell> GetSpells()
        {
            return new List<Spell>
            {
                new Spell()
                {
                    Name = "Addition",
                    School = "Math",
                    Level = 99,
                    ShortDescription = "Take an Enumeration of numbers and find their sum."
                },
                new Spell()
                {
                    Name = "A Different Spell",
                    CastingTime = "15"
                },
            };
        }


        public IEnumerable<string> GetClassList()
        {
            return new List<string>
            {
                "Class1",
                "Class2"
            };
        }
    }
}
