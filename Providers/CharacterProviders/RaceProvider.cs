﻿using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Models.Choices;
using Data.Models.Effects;
using Data.Models.Effects.ChoiceEffects;
using Data.Repositories.Interfaces;

namespace Providers.CharacterProviders
{
    public class RaceProvider : IRaceProvider
    {
        private readonly IRaceLoader _raceLoader;

        public RaceProvider(IRaceLoader raceLoader)
        {
            _raceLoader = raceLoader;
        }

        public IEnumerable<Race> GetRaces()
        {
            return _raceLoader.GetRaces();
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
            return _raceLoader.GetRaceByName(name);
        }

        public IChoiceEffect GetRaceChoiceEffect()
        {
            return new ChoiceEffect(GetRaceChoice());
        }

        private IChoice GetRaceChoice()
        {
            return new ExclusiveEffectChoice(
                GetRaces().Select(race =>
                    new ChoiceOption(
                        name: race.Name,
                        description: race.Description,
                        shortDescription: race.ShortDescription,
                        effect: race))
                )
            {
                Description = "Pick a race for your character.",
                ShortDescription = "Pick a race for your character.",
                Name = "Race"
            };
        }
    }
}
