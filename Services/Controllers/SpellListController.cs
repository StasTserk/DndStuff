using DnD5thEdTools.Repositories;
using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnD5thEdTools.Controllers
{
    public class SpellListController : ISpellListController
    {
        private readonly ISpellLoader _spellSource;
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
            return _spells.Where(criteria);
        }

        public IEnumerable<Spell> GetUnfilteredSpells()
        {
            return _spells;
        }

        public Spell GetSpellByName(string name)
        {
            return _spells.FirstOrDefault(s => s.Name == name);
        }
    }
}
