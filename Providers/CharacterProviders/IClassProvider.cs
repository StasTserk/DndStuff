using System.Collections.Generic;
using Data.Models;

namespace Providers.CharacterProviders
{
    public interface IClassProvider
    {
        CharacterClass GetSampleClass();
        CharacterClass GetClassByClassType(CharacterClassType type);
        IEnumerable<CharacterClass> GetAvailableLevelUpOptions(Character player);
    }
}
