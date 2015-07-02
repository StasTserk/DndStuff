using System.Collections.Generic;
using Data.Models.Effects;

namespace Data.Models.Choices
{
    public interface IChoice
    {
        IEnumerable<IChoiceOption> GetChoices();
        string Name { get; set; }
        string Description { get; set; }
        string ShortDescription { get; set; }
    }
}
