using System;
using System.Collections.Generic;
using Data.Models;

namespace Services.Controllers.Interfaces
{
    public interface ISpellListController
    {
        IEnumerable<Spell> GetFilteredSpells(Func<Spell, bool> criteria);
        IEnumerable<Spell> GetUnfilteredSpells();
        Spell GetSpellByName(String name);
    }
}
