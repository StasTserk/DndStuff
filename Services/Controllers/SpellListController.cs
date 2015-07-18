using DnD5thEdTools.Repositories;
using DnD5thEdTools.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DnD5thEdTools.Controllers
{
    public class SpellListController : ISpellListController
    {
        private readonly ISpellLoader _spellSource;
        private IEnumerable<Spell> _spells;
        private IDictionary<String, Func<Spell, bool>> _filterCriteria;

        public SpellListController(ISpellLoader loader)
        {
            _spellSource = loader;
            _filterCriteria = new Dictionary<String, Func<Spell, bool>>();
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


        public IEnumerable<Spell> GetFilteredSpells()
        {
            return from spell in _spells
                let validSpell = _filterCriteria.Select(expr => expr.Value).All(criteria => criteria(spell))
                where validSpell
                select spell;
        }

        public bool AddFilterCriteria(string filterName, Func<Spell, bool> criteria)
        {
            if (String.IsNullOrEmpty(filterName))
            {
                return false;
            }

            if (criteria == null)
            {
                RemoveFilterCriteria(filterName);
            }
            else
            {
                _filterCriteria[filterName] = criteria;
            }

            return true;
        }

        public bool RemoveFilterCriteria(string filterName)
        {
            if (String.IsNullOrEmpty(filterName))
            {
                return false;
            }

            if (_filterCriteria.ContainsKey(filterName))
            {
                _filterCriteria.Remove(filterName);
            }
            return true;
        }

        public void ClearFilterCriteria()
        {
            _filterCriteria.Clear();
        }


        public IEnumerable<string> GetClassList()
        {
            return _spellSource.GetClassList();
        }
    }
}
