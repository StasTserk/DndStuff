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

        public SpellLoader()
        {
            LoadSpells();
            SetSpellLists();
        }

        private void SetSpellLists()
        {
            //throw new NotImplementedException();
        }

        private void LoadSpells()
        {
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
                    Components = spellNode.Elements("Components").First().Value,
                    School = spellNode.Elements("School").First().Value,
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
    }
}