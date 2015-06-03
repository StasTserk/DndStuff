
using Data.Models;
using GalaSoft.MvvmLight;
using Providers.CharacterProviders;

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
        private readonly ICharacterProvider _characterProvider;

        public Character Character
        {
            get { return _characterProvider.CurrentCharacter; }
        }

        /// <summary>
        /// Initializes a new instance of the CharacterSkillsViewModel class.
        /// </summary>
        public CharacterSkillsViewModel(ICharacterProvider characterProvider)
        {
            _characterProvider = characterProvider;
        }
    }
}