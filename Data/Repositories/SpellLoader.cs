﻿using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DnD5thEdTools.Repositories
{
    public class SpellLoader : ISpellLoader
    {
        private List<Spell> _spellList;
        private Dictionary<String, Spell> _classSpellList;
        private List<string> _classList;

        public SpellLoader()
        {
            LoadSpells();
            SetSpellLists();
        }

        private void SetSpellLists()
        {
            var doc = XDocument.Load(@"Xml/SpellLists.xml");
            var list = doc.Root.Elements("class");

            _classSpellList = new Dictionary<string, Spell>();
            _classList = new List<string>();

            foreach(var spellClass in list)
            {
                String className = spellClass.Attribute("name").Value;
                var spellCollection = spellClass.Elements("spell");

                if (!_classList.Contains(className))
                {
                    _classList.Add(className);
                }

                foreach (var spellEntry in spellCollection)
                {
                    if (_spellList.Where(s => s.Name == spellEntry.Attribute("name").Value).Any())
                    {
                        Spell spl = _spellList.Where(s => s.Name == spellEntry.Attribute("name").Value).First();

                        spl.Classes.Add(className + " " + spellEntry.Attribute("level").Value);
                    }
                }
            }
        }

        private void LoadSpells()
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;
            var doc = XDocument.Load(@"Xml/Spells.xml");
            var list = doc.Root.Elements("spell");

            _spellList = new List<Spell>();
            
            foreach (var spellNode in list)
            {
                var spell = new Spell
                {
                    Name = spellNode.Elements("name").First().Value,
                    CastingTime = spellNode.Elements("CastingTime").First().Value,
                    Description = spellNode.Elements("Description").First().Value,
                    ShortDescription = spellNode.Elements("ShortDescription").First().Value,
                    Targets = spellNode.Elements("Targets").First().Value,
                    Range = spellNode.Elements("Range").First().Value,
                    Save = spellNode.Elements("Save").First().Value,
                    Concentration = spellNode.Elements("Concentration").First().Value == "Yes",
                    Duration = spellNode.Elements("Duration").First().Value,
                    Overcastable = spellNode.Elements("Overcastable").First().Value == "Yes",
                    Ritual = spellNode.Elements("Ritual").First().Value == "Yes",
                    Components = spellNode.Elements("Components").First().Value,
                    School = spellNode.Elements("School").First().Value,
                    RequiresAttackRoll = spellNode.Elements("RequiresAttackRoll").First().Value == "Yes",
                    Level = Int32.Parse(spellNode.Elements("Level").First().Value)
                };

                if (spellNode.Elements("Materials").First().Elements("Material").Any())
                {
                    spell.Materials = spellNode.Elements("Materials").First().Elements("Material").Select(m => m.Value).ToList();
                }

                _spellList.Add(spell);
            }
        }

        public IEnumerable<Spell> GetSpells()
        {
            return _spellList;
        }


        public IEnumerable<string> GetClassList()
        {
            return _classList;
        }
    }
}
