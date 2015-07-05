using System.Collections.Generic;
using Data.Models;
using Data.Models.Effects.ChoiceEffects;

namespace Providers.CharacterProviders
{
    public interface IRaceProvider
    {
        IEnumerable<Race> GetRaces();
        Race GetSampleRace();
        Race GetRaceByName(string name);
        IChoiceEffect GetRaceChoiceEffect();
    }
}
