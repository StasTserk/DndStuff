using System.Collections.Generic;
using Data.Models;

namespace Providers.CharacterProviders
{
    public interface IStatProvider
    {
        IEnumerable<Stat> GetDefaultStats(LevelModifiers modifiers);
    }
}