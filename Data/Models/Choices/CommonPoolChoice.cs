using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Choices
{
    class CommonPoolChoice : IChoice
    {
        private readonly ICollection<IChoiceOption> _choicePool;

        public CommonPoolChoice(ICollection<IChoiceOption> choicePool)
        {
            _choicePool = choicePool;
        }

        public void MakeChoice(IChoiceOption chosenOption)
        {
            ChosenOption = chosenOption;
            _choicePool.Remove(chosenOption);
        }

        public IChoiceOption ChosenOption { get; private set; }
        public IEnumerable<IChoiceOption> Choices { get { return _choicePool; } }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}
