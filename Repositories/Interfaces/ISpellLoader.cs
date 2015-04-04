using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5thEdTools.Repositories
{
    public interface ISpellLoader
    {
        IEnumerable<Spell> GetSpells();
    }
}
