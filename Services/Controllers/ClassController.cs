using System.Collections.Generic;
using Data.Models;
using Data.Repositories.Interfaces;
using Services.Controllers.Interfaces;

namespace Services.Controllers
{
    public class ClassController : IClassController
    {
        private readonly IClassLoader _classLoader;

        public ClassController(IClassLoader classLoader)
        {
            _classLoader = classLoader;
        }

        public CharacterClass GetClassByClassType(CharacterClassType type)
        {
            return _classLoader.GetClass(type);
        }

        public IEnumerable<CharacterClass> GetClasses()
        {
            return _classLoader.GetClasses();
        }
    }
}
