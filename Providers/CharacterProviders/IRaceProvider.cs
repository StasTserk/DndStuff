using Data.Models;
namespace Providers.CharacterProviders
{
    public interface IRaceProvider
    {
        Race GetSampleRace();
        Race GetRaceByName(string name);
    }
}
