using System;
using System.Collections.Generic;

namespace Data.Models.Choices
{
    class ModifiableChoice : IModifiableChoice
    {
        private readonly ICollection<IChoiceOption> _choices;

        public ModifiableChoice()
        {
            _choices = new List<IChoiceOption>();
        }

        public IEnumerable<IChoiceOption> GetChoices()
        {
            return _choices;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public void AddChoiceOption(IChoiceOption option)
        {
            _choices.Add(option);
        }
    }
}
