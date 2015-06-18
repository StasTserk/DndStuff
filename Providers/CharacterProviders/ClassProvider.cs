using System;
using Data.Models;
using Services.Controllers.Interfaces;

namespace Providers.CharacterProviders
{
    public class ClassProvider : IClassProvider
    {
        private readonly IClassController _classController;

        public ClassProvider(IClassController classController)
        {
            _classController = classController;
        }

        public CharacterClass GetSampleClass()
        {
            return _classController.GetClassByClassType(CharacterClassType.Barbarian);
        }

        public CharacterClass GetClassByClassType(CharacterClassType type)
        {
            throw new NotImplementedException();
        }
    }
}
