using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight;

namespace Data.Models.Choices
{
    public class ClassSelectionChoice : ObservableObject, IChoice
    {
        private readonly LevelModifiers _levels;
        private readonly IEnumerable<CharacterClass> _allClasses; 
        private readonly IEnumerable<ClassLevel> _classLevelOptions;
        private readonly IEnumerable<IChoiceOption> _choiceOptions;
        private IChoiceOption _chosenOption;

        public ClassSelectionChoice(LevelModifiers levels, IEnumerable<CharacterClass> allClasses)
        {
            _levels = levels;
            _allClasses = allClasses;
            _classLevelOptions = new List<ClassLevel>();
            _choiceOptions = new List<IChoiceOption>();

            // TODO Add Multiclassing
            if (_levels.Level == 0)
            {
                _classLevelOptions = _allClasses.Select(c => c.LevelEffects.First(l => l.Level == 1));
            }
            else
            {
                _classLevelOptions =
                    _allClasses.First(c => c.ClassType == _levels.ClassesAndLevels.First().Item1)
                    .LevelEffects.Where(le => le.Level == _levels.ClassesAndLevels.First().Item2 + 1);
            }

            _choiceOptions = _classLevelOptions.Select(
                cl => new ChoiceOption(
                    name: string.Format(@"{0} {1}", cl.ClassType, cl.Level), 
                    description: string.Format(@"Attain level {0} of the {1} class,    with all the perks that come with that.", cl.Level, cl.ClassType),
                    shortDescription: string.Format(@"Gain level {0} of {1}", cl.Level, cl.ClassType), 
                    effect: cl));
        }

        public void MakeChoice(IChoiceOption chosenOption)
        {
            _chosenOption = chosenOption;
            RaisePropertyChanged(() => ChosenOption);
        }

        public IChoiceOption ChosenOption { get { return _chosenOption; }}
        public IEnumerable<IChoiceOption> Choices { get {return _choiceOptions;} }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}
