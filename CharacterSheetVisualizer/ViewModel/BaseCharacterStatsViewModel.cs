using System;
using System.ComponentModel;
using System.Windows.Data;
using Data.Models;
using Data.Models.Choices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private readonly IClassProvider _classProvider;
        public RelayCommand LevelUpCommand { get; set; }

        public Character Character
        {
            get { return _characterProvider.CurrentCharacter; }
        }

        public bool CanLevelUp
        {
            get { return Character.OutstandingChoices.Count == 0; }
        }

        /// <summary>
        /// Initializes a new instance of the BaseCharacterStatsViewModel class.
        /// </summary>
        public BaseCharacterStatsViewModel(ICharacterProvider characterProvider, IClassProvider classProvider)
        {
            _characterProvider = characterProvider;
            _classProvider = classProvider;
            _characterProvider.NewCharacterLoaded += OnCharacterLoaded;

            // TODO make button enabling work correctly here
            LevelUpCommand = new RelayCommand(AddLevelUpChoice,
                () => true); // only level up on no choices left
        }

        private void AddLevelUpChoice()
        {
            if (!CanLevelUp)
            {
                return;
            }

            var choice = new ClassSelectionChoice(
                Character.LevelModifiers,
                _classProvider.GetAvailableLevelUpOptions(Character)
                )
            {
                Description = string.Format(@"Pick your level {0} class", Character.LevelModifiers.Level + 1),
                Name = string.Format(@"Level Up to {0}", Character.LevelModifiers.Level + 1),
                ShortDescription = string.Format(@"Pick your level {0} class", Character.LevelModifiers.Level + 1)
            };
            Character.AddChoice(choice);
        }

        private void OnCharacterLoaded(object sender, EventArgs e)
        {
            // THe Current Character should be reloaded
            RaisePropertyChanged(() => Character);
        }
    }
}