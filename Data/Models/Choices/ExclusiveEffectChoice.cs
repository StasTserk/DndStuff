using System.Collections.Generic;
using System.Linq;
using Data.Models.Effects;

namespace Data.Models.Choices
{
    public class ExclusiveEffectChoice : IChoice
    {
        private readonly IEnumerable<IChoiceOption> _choices;
        private IChoiceOption _chosenOption; 

        public ExclusiveEffectChoice(IEnumerable<IChoiceOption> choices)
        {
            _choices = choices;
        }

        public void MakeChoice(IChoiceOption chosenOption)
        {
            if (_choices.Contains(chosenOption))
            {
                return;
            }
            _chosenOption = chosenOption;
        }

        public IEnumerable<IChoiceOption> Choices
        {
            get { return _choices; }
        }

        public IChoiceOption ChosenOption
        {
            get
            {
                return _chosenOption;
            }
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}