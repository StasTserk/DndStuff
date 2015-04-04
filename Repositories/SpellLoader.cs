using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DnD5thEdTools.Repositories
{
    class SpellLoader : ISpellLoader
    {
        List<Spell> _spellList;
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
            XDocument doc = XDocument.Load(@"../../Xml/Spells.xml");
            var list = doc.Root.Elements("spell")
                               .ToList();

            _spellList = new List<Spell>();
            
            foreach (var spellNode in list)
            {
                Spell spell = new Spell();
                spell.Name = spellNode.Elements("name").First().Value;
                spell.CastingTime = spellNode.Elements("CastingTime").First().Value;
                spell.Description = spellNode.Elements("Description").First().Value;
                spell.ShortDescription = spellNode.Elements("ShortDescription").First().Value;
                spell.Targets = spellNode.Elements("Targets").First().Value;
                spell.Range = spellNode.Elements("Range").First().Value;
                spell.Save = spellNode.Elements("Save").First().Value;
                spell.Concentration = spellNode.Elements("Concentration").First().Value == "Yes";
                spell.Duration = spellNode.Elements("Duration").First().Value;
                spell.Overcastable = spellNode.Elements("Overcastable").First().Value == "Yes";
                spell.Components = spellNode.Elements("Components").First().Value;
                spell.School = spellNode.Elements("School").First().Value;
                spell.Level = Int32.Parse(spellNode.Elements("Level").First().Value);
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
