using DnD5thEdTools.Repositories;
using DnD5thEdTools.Models;
using System;
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
            foreach (var spell in _spells)
            {
                bool validSpell = true;
                foreach (var expr in _filterCriteria)
                {
                    var criteria = expr.Value;
                    if (!criteria(spell))
                    {
                        validSpell = false;
                        break;
                    }
                }
                if (validSpell)
                {
                    yield return spell;
                }
            }

        }

        public bool AddFilterCriteria(string filterName, Func<Spell, bool> criteria)
        {
            if (String.IsNullOrEmpty(filterName))
            {
                return false;
            }

            if (_filterCriteria.ContainsKey(filterName))
            {
                _filterCriteria.Remove(filterName);
            }
            _filterCriteria.Add(filterName, criteria);
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
    }
}
