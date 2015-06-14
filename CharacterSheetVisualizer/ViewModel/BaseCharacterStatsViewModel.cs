using System;
using System.Windows.Data;
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
    public class BaseCharacterStatsViewModel : ViewModelBase
    {
        private readonly ICharacterProvider _characterProvider;

        public Character Character
        {
            get { return _characterProvider.CurrentCharacter; }
        }

        /// <summary>
        /// Initializes a new instance of the BaseCharacterStatsViewModel class.
        /// </summary>
        public BaseCharacterStatsViewModel(ICharacterProvider characterProvider)
        {
            _characterProvider = characterProvider;
            _characterProvider.NewCharacterLoaded += OnCharacterLoaded;
        }

        private void OnCharacterLoaded(object sender, EventArgs e)
        {
            // THe Current Character should be reloaded
            RaisePropertyChanged(() => Character);
        }
    }
}