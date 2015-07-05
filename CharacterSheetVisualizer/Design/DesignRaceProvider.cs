using System;
using System.Collections.Generic;
using Data.Models;
using Data.Models.Choices;
using Data.Models.Effects;
using Data.Models.Effects.ChoiceEffects;
using Providers.CharacterProviders;

namespace CharacterSheetVisualizer.Design
{
    class DesignRaceProvider : IRaceProvider
    {
        public IEnumerable<Race> GetRaces()
        {
            throw new NotImplementedException();
        }

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
            return GetSampleRace();
        }

        public IChoiceEffect GetRaceChoiceEffect()
        {
            // todo add design time choice here
            return null;
        }

        private IChoice GetRaceChoice()
        {
            // todo add design time choice here
            return null;
        }
    }
}

