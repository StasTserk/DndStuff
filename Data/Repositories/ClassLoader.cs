using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Data.EffectParser;
using Data.Models;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class ClassLoader : IClassLoader
    {
        private readonly ICollection<CharacterClass> _characterClasses;
        private readonly IEffectParser _effectParser;

        public ClassLoader(IEffectParser effectParser)
        {
            _effectParser = effectParser;
            _characterClasses = new List<CharacterClass>();
        }

        public CharacterClass GetClass(CharacterClassType type)
        {
            if (!_characterClasses.Any())
            {
                LoadClasses();
            }

            return _characterClasses.First(c => c.ClassType == type);
        }

        private void LoadClasses()
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;
            var doc = XDocument.Load(@"Xml/Classes.xml");
            var list = doc.Root.Elements("Class");

            foreach (var classNode in list)
            {
                _characterClasses.Add(ParseClass(classNode));
            }
        }

        private CharacterClass ParseClass(XElement classNode)
        {
            var classType =
                (CharacterClassType) Enum.Parse(typeof (CharacterClassType), classNode.Attribute("Name").Value);
            var classLevels = classNode.Elements("Effects").Select(
                effects => new ClassLevel(
                    levelEffects: _effectParser.GetEffectsFromXml(effects), 
                    level: int.Parse(effects.Attribute("Level").Value), 
                    classType: classType)).ToList();

            return new CharacterClass(classLevels, classType);
        }
    }
}
