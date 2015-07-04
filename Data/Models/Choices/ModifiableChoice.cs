using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace Data.Models.Choices
{
    class ModifiableChoice : ObservableObject, IModifiableChoice
    {
        private readonly ICollection<IChoiceOption> _choices;
        private IChoiceOption _choiceOption;

        public ModifiableChoice()
        {
            _choices = new List<IChoiceOption>();
        }

        public void MakeChoice(IChoiceOption chosenOption)
        {
            if (!_choices.Contains(chosenOption))
            {
                return;
            }
            _choiceOption = chosenOption;
            RaisePropertyChanged(() => ChosenOption);
        }

        public IChoiceOption ChosenOption
        {
            get { return _choiceOption; }
        }

        public IEnumerable<IChoiceOption> Choices
        {
            get { return _choices; }
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public void AddChoiceOption(IChoiceOption option)
        {
            _choices.Add(option);
            RaisePropertyChanged(() => Choices);
        }
    }
}
