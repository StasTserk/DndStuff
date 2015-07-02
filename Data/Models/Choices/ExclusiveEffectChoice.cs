using System.Collections.Generic;
using Data.Models.Effects;

namespace Data.Models.Choices
{
    public class ExclusiveEffectChoice : IChoice
    {
        private readonly IEnumerable<IChoiceOption> _choices;

        public ExclusiveEffectChoice(IEnumerable<IChoiceOption> choices)
        {
            _choices = choices;
        }

        public IEnumerable<IChoiceOption> GetChoices()
        {
            return _choices;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}