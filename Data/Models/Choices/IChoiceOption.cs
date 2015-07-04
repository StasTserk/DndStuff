using System.Collections.Generic;
using Data.Models.Effects;

namespace Data.Models.Choices
{
    public interface IChoiceOption
    {
        string Name { get;}

        string Description { get;}

        string ShortDescription { get; }

        IEnumerable<IEffect> ChoiceEffects { get; }

    }
}
