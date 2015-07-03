using Data.Models;
using Data.Models.Effects.ChoiceEffects;
using Data.Repositories.Interfaces;

namespace Providers.CharacterProviders
{
    public class BackgroundProvider : IBackgroundProvider
    {
        private readonly IBackgroundLoader _backgroundLoader;

        public BackgroundProvider(IBackgroundLoader backgroundLoader)
        {
            _backgroundLoader = backgroundLoader;
        }

        public Background GetBackground(string name)
        {
            return _backgroundLoader.GetBackground(name);
        }

        public IChoiceEffect GetBackgroundChoiceEffect()
        {
            return _backgroundLoader.GetBackgroundChoiceEffect();
        }
    }
}
