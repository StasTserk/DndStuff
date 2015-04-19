using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5thEdTools.Controllers
{
    public interface ISpellListController
    {
        IEnumerable<Spell> GetFilteredSpells(Func<Spell, bool> criteria);
        IEnumerable<Spell> GetUnfilteredSpells();
        Spell GetSpellByName(String name);
    }
}
