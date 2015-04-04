using DnD5thEdTools.Controllers;
using DnD5thEdTools.Repositories;
using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5thEdTools.Controllers
{
    public class SpellListController : ISpellListController
    {
        public ISpellLoader _spellSource;
        private IEnumerable<Spell> _spells;

        public SpellListController(ISpellLoader loader)
        {
            _spellSource = loader;
            LoadSpellList();
        }

        void LoadSpellList()
        {
            _spells = _spellSource.GetSpells();
        }

        public IEnumerable<Spell> GetFilteredSpells(Func<Spell, bool> criteria)
        {
            LoadSpellList();
            return _spells.Where(s => criteria(s) == true);
        }

        public IEnumerable<Spell> GetUnfilteredSpells()
        {
            return _spells;
        }


        public Spell GetSpellByName(string name)
        {
            return _spells.Where(s => s.Name == name).First();
        }
    }
}
