using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Data.EffectParser;
using Data.Models;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class RaceLoader : IRaceLoader
    {
        private readonly ICollection<Race> _races;
        private readonly IEffectParser _parser;

        public RaceLoader(IEffectParser parser)
        {
            _parser = parser;
            _races = new List<Race>();
        }

        public IEnumerable<Race> GetRaces()
        {
            if (!_races.Any())
            {
                LoadRaces();
            }

            return _races;
        }

        private void LoadRaces()
        {
            var doc = XDocument.Load(@"Xml/Races.xml");

            var specList = doc.Root.Elements("Race");
            foreach (var race in specList)
            {
                _races.Add(ParseRace(race));
            }
        }

        private Race ParseRace(XElement raceElement)
        {
            return new Race
            {
                Description = raceElement.Attribute("Description").Value,
                Name = raceElement.Attribute("Name").Value,
                ShortDescription = raceElement.Attribute("ShortDescription").Value,
                Effects = _parser.GetEffectsFromXml(raceElement.Elements("Effects").First())
            };
        }

        public Race GetRaceByName(string name)
        {
            if (!_races.Any())
            {
                LoadRaces();
            }

            return _races.FirstOrDefault(r => r.Name == name);
        }
    }
}
