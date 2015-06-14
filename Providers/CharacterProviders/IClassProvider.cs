using Data.Models;

namespace Providers.CharacterProviders
{
    public interface IClassProvider
    {
        CharacterClass GetSampleClass();
        CharacterClass GetClassByClassType(CharacterClassType type);
    }
}
