using Data.Models;
using Data.Models.Effects.ChoiceEffects;

namespace Providers.CharacterProviders
{
    public interface IBackgroundProvider
    {
        Background GetBackground(string name);
        IChoiceEffect GetBackgroundChoiceEffect();
    }
}
