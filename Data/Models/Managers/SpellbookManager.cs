using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models.Choices;
using Data.Models.Effects.SpellEffects;
using Data.Repositories.Interfaces;

namespace Data.Models.Managers
{
    public class SpellBookManager : ISpellBookManager
    {
        private readonly ISpellLoader _spellLoader;
        private readonly ICollection<Spell> _knownSpells;
        private readonly ICollection<Spell> _preparedSpells;
        private readonly ICollection<Spell> _spellList;
        private readonly ICollection<IChoiceOption> _spellChoiceOptions;

        public SpellBookManager(ISpellLoader spellLoader)
        {
            _spellLoader = spellLoader;
            _knownSpells = new List<Spell>();
            _preparedSpells = new List<Spell>();
            _spellList = new List<Spell>();
            _spellChoiceOptions = new List<IChoiceOption>();
        }

        public IEnumerable<Spell> GetCharacterKnownSpells()
        {
            return _knownSpells;
        }

        public IEnumerable<Spell> GetCharacterPreparedSpells()
        {
            return _preparedSpells;
        }

        public IChoice GetNewSpellChoice()
        {
            return GetNewSpellMultipleChoice(1).FirstOrDefault();
        }

        public IEnumerable<IChoice> GetNewSpellMultipleChoice(int choiceCount)
        {
            var choices = new List<CommonPoolChoice>();
            for (var i = 0; i < choiceCount; i++)
            {
                choices.Add(new CommonPoolChoice(_spellChoiceOptions)
                {
                    Description = "Pick a spell from the following list",
                    Name = "Spell Selection",
                    ShortDescription = "Pick a spell from a list of options"
                });
            }

            return choices;
        }

        public IChoice GetNewSpellChoice(Func<Spell, bool> condition)
        {
            return GetNewSpellMultipleChoice(condition, 1).FirstOrDefault();
        }

        public IEnumerable<IChoice> GetNewSpellMultipleChoice(Func<Spell, bool> condition, int choiceCount)
        {
            var choices = new List<CommonPoolChoice>();
            ICollection<IChoiceOption> choiceOptions =
                _spellList.Where(condition).Select(GetSpellChoiceOption).ToList();

            for (var i = 0; i < choiceCount; i ++)
            {
                choices.Add(new CommonPoolChoice(choiceOptions)

                {
                    Description = "Pick a spell from the following list",
                    Name = "Spell Selection",
                    ShortDescription = "Pick a spell from a list of options"
                });
            }

            return choices;
        }

        public void AddSpellsToSpellList(CharacterClassType classType, int level)
        {
            AddSpellsToSpellList(
                s => s.Classes.Any(c => c.Contains(classType.ToString()))
                    && s.Level <= level
                );
        }

        public void AddSpellToSpellKnown(string name)
        {
            Spell theSpell = _spellLoader.GetSpells().First(s => s.Name == name);
            _knownSpells.Add(theSpell);

            IChoiceOption theOption = _spellChoiceOptions.FirstOrDefault(
                sc => sc.Description == theSpell.Description);

            if (theOption != null)
            {
                _spellChoiceOptions.Remove(theOption);
            }
        }

        public void AddSpellsToSpellList(Func<Spell, bool> condition)
        {
            foreach (var spell in _spellLoader.GetSpells().
                Where(condition).Where(s => !_knownSpells.Contains(s)))
            {
                _spellList.Add(spell);
                _spellChoiceOptions.Add(GetSpellChoiceOption(spell));
            }
        }

        private static IChoiceOption GetSpellChoiceOption(Spell spell)
        {
            return new ChoiceOption(
                name: string.Format(@"{0} ({1})", spell.Name, spell.Level),
                description: spell.Description,
                shortDescription: spell.ShortDescription,
                effect: new AddKnownSpellEffect(spell.Name));
        }
    }
}
