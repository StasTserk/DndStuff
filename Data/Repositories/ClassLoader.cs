using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Data.EffectParser;
using Data.Models;
using Data.Models.Choices;
using Data.Models.Effects;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class ClassLoader : IClassLoader
    {
        private readonly ICollection<CharacterClass> _characterClasses;
        private readonly IEffectParser _effectParser;
        private readonly ICollection<ClassCustomization> _classCustomizations;

        public ClassLoader(IEffectParser effectParser)
        {
            _effectParser = effectParser;
            _characterClasses = new List<CharacterClass>();
            _classCustomizations = new List<ClassCustomization>();
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

            var specList = doc.Root.Elements("ClassCustomization");
            foreach (var specNode in specList)
            {
                _classCustomizations.Add(ParseCustomization(specNode));
            }

            
            var classList = doc.Root.Elements("Class");

            foreach (var classNode in classList)
            {
                _characterClasses.Add(ParseClass(classNode));
            }

            CustomizationChoicePostProcessing();
        }

        private void CustomizationChoicePostProcessing()
        {
            foreach (var outstandingCustomizationChoice in _effectParser.GetOutstandingCustomizationChoices())
            {
                CharacterClassType targetType = outstandingCustomizationChoice.TargetClass;
                foreach (var cOpt in
                        _classCustomizations.Where(c => c.ClassType == targetType)
                            .Select(clsCstm =>
                                new ChoiceOption(
                                    name: clsCstm.Name,
                                    description: clsCstm.Description,
                                    shortDescription: clsCstm.ShortDescription,
                                    effect: new ClassCustomizationEffect(clsCstm))))
                {
                    outstandingCustomizationChoice.ChoiceAsModifiable.AddChoiceOption(cOpt);
                }
            }
            _effectParser.ClearOutstandingChoices();
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

            return new CharacterClass(classLevels, classType)
            {
                Name = classNode.Attribute("Name").Value
            };
        }

        private ClassCustomization ParseCustomization(XElement specNode)
        {
            var targetType =
                (CharacterClassType)Enum.Parse(typeof(CharacterClassType), specNode.Attribute("AffectedClass").Value);
            var classLevels = specNode.Elements("Effects").Select(
                effects => new ClassLevel(
                    levelEffects: _effectParser.GetEffectsFromXml(effects),
                    level: int.Parse(effects.Attribute("Level").Value),
                    classType: targetType)).ToList();

            return new ClassCustomization(classLevels, targetType)
            {
                Name = specNode.Attribute("Name").Value,
                Description = specNode.Attribute("Description").Value,
                ShortDescription = specNode.Attribute("ShortDescription").Value
            };
        }
    }
}
