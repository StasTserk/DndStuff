using System.Collections.Generic;
using Data.Models;

namespace Data.Repositories.Interfaces
{
    public interface ISpellLoader
    {
        IEnumerable<Spell> GetSpells();
    }
}
