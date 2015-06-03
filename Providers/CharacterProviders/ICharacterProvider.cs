using System;
using Data.Models;

namespace Providers.CharacterProviders
{
    public interface ICharacterProvider
    {
        event EventHandler NewCharacterLoaded;
        Character CurrentCharacter { get; }

        void CreateNewCharacter();
    }
}