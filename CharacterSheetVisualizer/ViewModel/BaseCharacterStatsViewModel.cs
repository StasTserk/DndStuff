using System;
using System.Runtime.Remoting.Channels;
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
    public class BaseCharacterStatsViewModel : ViewModelBase
    {
        private readonly ICharacterService _characterService;

        public Character Character
        {
            get { return _characterService.CurrentCharacter; }
        }

        /// <summary>
        /// Initializes a new instance of the BaseCharacterStatsViewModel class.
        /// </summary>
        public BaseCharacterStatsViewModel(ICharacterService characterService)
        {
            _characterService = characterService;
            _characterService.NewCharacterLoaded += OnCharacterLoaded;
        }

        private void OnCharacterLoaded(object sender, EventArgs e)
        {
            // THe Current Character should be reloaded
            RaisePropertyChanged(() => Character);
        }
    }
}