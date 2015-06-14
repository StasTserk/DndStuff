using System.Collections.Generic;
using Data.Models;
using Data.Models.Effects;

namespace Providers.CharacterProviders
{
    public class RaceProvider : IRaceProvider
    {
        public Race GetSampleRace()
        {
            return new Race()
            {
                Description = "Forest Gnome",
                Name = "Forest Gnome",
                Effects = new List<IEffect>
                {
                    new BonusSpeedEffect(25),
                    new AddFeatureEffect(new CharacterFeature(
                        name: "Darkvision",
                        description: "See in the dark",
                        shortDescription: "Vision in Dark",
                        source: "Gnome Racial")),
                    new AddFeatureEffect(new CharacterFeature(
                        name: "Gnome Cunning",
                        description: "Advantage on Intelligence, Wisdom, and Charisma saves against magic.",
                        shortDescription: "Advantage on mental saves vs. magic",
                        source: "Gnome Racial")),
                    new BonusStatEffect(StatType.Dexterity, 1),
                    new BonusStatEffect(StatType.Intelligence, 2)
                }
            };
        }

        public Race GetRaceByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
