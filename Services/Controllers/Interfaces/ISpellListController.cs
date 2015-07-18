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
        IEnumerable<string> GetClassList();
        IEnumerable<Spell> GetFilteredSpells(Func<Spell, bool> criteria);
        IEnumerable<Spell> GetFilteredSpells();
        IEnumerable<Spell> GetUnfilteredSpells();
        Spell GetSpellByName(String name);
        bool AddFilterCriteria(String filterName, Func<Spell, bool> criteria);
        bool RemoveFilterCriteria(String filterName);
        void ClearFilterCriteria();
    }
}
