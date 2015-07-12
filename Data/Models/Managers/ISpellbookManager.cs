using System;
using System.Collections.Generic;
using Data.Models.Choices;

namespace Data.Models.Managers
{
    public interface ISpellBookManager
    {
        IEnumerable<Spell> GetCharacterKnownSpells();
        IEnumerable<Spell> GetCharacterPreparedSpells();
        IChoice GetNewSpellChoice();
        IEnumerable<IChoice> GetNewSpellMultipleChoice(int choiceCount);
        IChoice GetNewSpellChoice(Func<Spell, bool> condition);
        IEnumerable<IChoice> GetNewSpellMultipleChoice(Func<Spell, bool> condition, int choiceCount);
        void AddSpellsToSpellList(CharacterClassType classType, int level);
        void AddSpellToSpellKnown(string name);
    }
}
