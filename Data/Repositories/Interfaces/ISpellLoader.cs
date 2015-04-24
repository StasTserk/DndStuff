using DnD5thEdTools.Models;
using System.Collections.Generic;

namespace DnD5thEdTools.Repositories
{
    public interface ISpellLoader
    {
        IEnumerable<Spell> GetSpells();
        IEnumerable<string> GetClassList();
    }
}
