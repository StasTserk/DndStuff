﻿using System.Collections.Generic;
using Data.Models;
using Data.Repositories.Interfaces;

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
    }
}
