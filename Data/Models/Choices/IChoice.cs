using System.Collections.Generic;
using System.ComponentModel;

namespace Data.Models.Choices
{
    public interface IChoice
    {
        void MakeChoice(IChoiceOption chosenOption);
        IChoiceOption ChosenOption { get; }
        IEnumerable<IChoiceOption> Choices { get; }
        string Name { get; set; }
        string Description { get; set; }
        string ShortDescription { get; set; }
    }
}
