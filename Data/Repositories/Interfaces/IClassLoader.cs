using Data.Models;

namespace Data.Repositories.Interfaces
{
    public interface IClassLoader
    {
        CharacterClass GetClass(CharacterClassType type);
    }
}
