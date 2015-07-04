using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Data.EffectParser;
using Data.Models;
using Data.Models.Choices;
using Data.Models.Effects.BackgroundEffects;
using Data.Models.Effects.ChoiceEffects;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class BackgroundLoader : IBackgroundLoader
    {
        private readonly IEffectParser _effectParser;
        private readonly ICollection<Background> _backgrounds;

        public BackgroundLoader(IEffectParser effectParser)
        {
            _effectParser = effectParser;
            _backgrounds = new List<Background>();
        }

        public Background GetBackground(string name)
        {
            if (!_backgrounds.Any())
            {
                LoadBackgrounds();
            }

            return _backgrounds.FirstOrDefault(b => b.Name == name);
        }

        private void LoadBackgrounds()
        {
            var doc = XDocument.Load(@"Xml/Backgrounds.xml");

            var backgroundList = doc.Root.Elements("Background");
            foreach (var background in backgroundList)
            {
                _backgrounds.Add(ParseBackground(background));
            }
        }

        private Background ParseBackground(XElement background)
        {
            var newBackground = new Background
            { 
                Name = background.Attribute("Name").Value,
                Description = background.Attribute("Description").Value,
                Flaws = background.Elements("Flaw").Select(e => e.Attribute("Text").Value),
                Bonds = background.Elements("Bond").Select(e => e.Attribute("Text").Value),
                PersonalityTraits = background.Elements("PTrait").Select(e => e.Attribute("Text").Value),
                Ideals = background.Elements("Ideal").Select(e => e.Attribute("Text").Value),
                Effects = _effectParser.GetEffectsFromXml(background.Elements("Effects").First())
            };

            return newBackground;
        }

        public IChoiceEffect GetBackgroundChoiceEffect()
        {
            if (!_backgrounds.Any())
            {
                LoadBackgrounds();
            }

            IEnumerable<ChoiceOption> options = _backgrounds.Select(b =>
                new ChoiceOption(
                    name: b.Name,
                    description: b.Description,
                    shortDescription: string.Format("The {0} background.", b.Name),
                    effect: new AddBackgroundEffect(b)));

            var choice = new ExclusiveEffectChoice(options)
            {
                Name = "Character Background",
                ShortDescription = "Your character's background",
                Description = "Your character's background determines your personality traits   as well as some starting skills."
            };
            var choiceEffect = new ChoiceEffect(choice);
            return choiceEffect;
        }

        public IEnumerable<Background> GetBackgrounds()
        {
            if (!_backgrounds.Any())
            {
                LoadBackgrounds();
            }
            return _backgrounds;
        }
    }
}
