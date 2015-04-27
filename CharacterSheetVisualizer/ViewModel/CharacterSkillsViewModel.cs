using CharacterSheetVisualizer.Model;
using GalaSoft.MvvmLight;

namespace CharacterSheetVisualizer.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CharacterSkillsViewModel : ViewModelBase
    {
        private readonly ICharacterService _characterService;

        public Character Character
        {
            get { return _characterService.CurrentCharacter; }
        }

        /// <summary>
        /// Initializes a new instance of the CharacterSkillsViewModel class.
        /// </summary>
        public CharacterSkillsViewModel(ICharacterService characterService)
        {
            _characterService = characterService;
        }
    }
}