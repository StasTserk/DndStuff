using System.Collections.Generic;
using Data.Models;
using Data.Models.Effects.ChoiceEffects;

namespace Data.Repositories.Interfaces
{
    public interface IBackgroundLoader
    {
        Background GetBackground(string name);
        IChoiceEffect GetBackgroundChoiceEffect();
        IEnumerable<Background> GetBackgrounds();
    }
}
