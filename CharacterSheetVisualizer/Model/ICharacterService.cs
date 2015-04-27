using System;

namespace CharacterSheetVisualizer.Model
{
    public interface ICharacterService
    {
        event EventHandler NewCharacterLoaded;
        Character CurrentCharacter { get; }

        void CreateNewCharacter();
    }
}