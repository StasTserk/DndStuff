using System;
using Data.Models;
using GalaSoft.MvvmLight;
using Providers.CharacterProviders;

namespace CharacterSheetVisualizer.ViewModel
{
    public class CharacterBackgroundViewModel : ViewModelBase
    {
        private readonly ICharacterProvider _characterProvider;

        public Character Character
        {
            get { return _characterProvider.CurrentCharacter; }
        }

        public CharacterBackgroundViewModel(ICharacterProvider characterProvider)
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
