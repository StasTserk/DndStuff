using Data.Models;

namespace Services.Controllers.Interfaces
{
    public interface IClassController
    {
        CharacterClass GetClassByClassType(CharacterClassType type);
    }
}
