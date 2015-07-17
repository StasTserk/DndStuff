using System;
using Data.Models;
using Data.Models.Choices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Providers.CharacterProviders;

namespace CharacterSheetVisualizer.ViewModel
{
    public class CharacterChoicesViewModel : ViewModelBase
    {
        private readonly ICharacterProvider _characterProvider;
        private IChoice _selectedChoice;
        public RelayCommand OptionPickedCommand { get; set; }
        public IChoiceOption SelectedOption { get; set; }

        public IChoice SelectedChoice
        {
            get
            {
                return _selectedChoice;
            }
            set
            {
                _selectedChoice = value;
                RaisePropertyChanged(() => SelectedChoice);
            }
        }

        public Character Character
        {
            get { return _characterProvider.CurrentCharacter; }
        }

        /// <summary>
        /// Initializes a new instance of the CharacterChoicesViewModel class.
        /// </summary>
        public CharacterChoicesViewModel(ICharacterProvider characterProvider)
        {
            OptionPickedCommand = new RelayCommand(OnChoiceOptionPicked);
            _characterProvider = characterProvider;
            _characterProvider.NewCharacterLoaded += OnCharacterLoaded;
        }

        private void OnChoiceOptionPicked()
        {
            if (_selectedChoice == null) return;
            var effects = SelectedOption.ChoiceEffects;

            foreach (var choiceEffect in effects)
            {
                choiceEffect.ApplyToCharacter(Character);
            }

            Character.MakeChoice(SelectedChoice, SelectedOption);

            SelectedOption = null;
            SelectedChoice = null;
        }

        private void OnCharacterLoaded(object sender, EventArgs e)
        {
            // The Current Character should be reloaded
            RaisePropertyChanged(() => Character);
        }
    }
}
