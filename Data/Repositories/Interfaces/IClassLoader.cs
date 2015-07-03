using System.Collections.Generic;
using Data.Models;

namespace Data.Repositories.Interfaces
{
    public interface IClassLoader
    {
        CharacterClass GetClass(CharacterClassType type);
        IEnumerable<CharacterClass> GetClasses();
    }
}
