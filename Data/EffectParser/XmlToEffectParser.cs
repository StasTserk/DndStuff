using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Data.Models;
using Data.Models.Choices;
using Data.Models.Effects;
using Data.Models.Effects.ChoiceEffects;

namespace Data.EffectParser
{
    public class XmlToEffectParser : IEffectParser
    {
        private readonly ICollection<ClassCustomizationChoiceEffect> _outstandingClassCustomizationChoiceEffects;

        public XmlToEffectParser()
        {
            _outstandingClassCustomizationChoiceEffects = new List<ClassCustomizationChoiceEffect>();
        }

        public IEnumerable<IEffect> GetEffectsFromXml(XElement element)
        {
            return element.Elements("Effect").Select(ParseEffect).ToList();
        }

        public IEnumerable<ClassCustomizationChoiceEffect> GetOutstandingCustomizationChoices()
        {
            return _outstandingClassCustomizationChoiceEffects;
        }

        public void ClearOutstandingChoices()
        {
            _outstandingClassCustomizationChoiceEffects.Clear();
        }

        private IEffect ParseEffect(XElement effectElement)
        {
            switch (effectElement.Attribute("Type").Value)
            {
                case "ClassCustomizationChoiceEffect":
                    return ParseClassCustomizationChoiceEffect(effectElement);
                case "FeatureChoiceEffect":
                    return ParseFeatureChoiceEffect(effectElement);
                case "AddFeatureEffect":
                    return ParseAddFeatureEffect(effectElement);
                case "AddProficiencyEffect":
                    return ParseAddProficiencyEffect(effectElement);
                case "ArmorAddStatEffect":
                    return ParseArmorAddStatEffect(effectElement);
                case "ArmorWithMaxDexEffect": 
                    return ParseArmorWithMaxDexEffect(effectElement);
                case "BonusSkillEffect": 
                    return ParseBonusSkillEffect(effectElement);
                case "BonusSpeedEffect": 
                    return ParseBonusSpeedEffect(effectElement);
                case "BonusStatEffect": 
                    return ParseBonusStatEffect(effectElement);
                case "MinimumSkillProficiencyEffect": 
                    return ParseMinimumSkillProficiencyEffect(effectElement);
                case "MinimumStatEffect": 
                    return ParseMinimumStatEffect(effectElement);
                case "ModifyFeatureEffect": 
                    return ParseModifyFeatureEffect(effectElement);
                case "SaveProficiencyEffect": 
                    return ParseSaveProficiencyEffect(effectElement);
            }
            throw new InvalidDataException("XML Element contains invalid Effect Type attribute - " 
                + effectElement.Attribute("Type").Value);
        } 

        private IEffect ParseFeatureChoiceEffect(XElement effectElement)
        {
            var choice = new ExclusiveEffectChoice(
                    effectElement.Elements("Choice")
                        .Select(e =>
                            new ChoiceOption(name: e.Attribute("Name").Value,
                                description: e.Attribute("ShortDescription").Value,
                                shortDescription: e.Attribute("ShortDescription").Value,
                                effects: e.Elements().Select(ParseEffect))))
            {
                Description = effectElement.Attribute("Description").Value,
                Name = effectElement.Attribute("Name").Value,
                ShortDescription = effectElement.Attribute("ShortDescription").Value
            };

            return new ChoiceEffect(choice);

        }

        private IEffect ParseClassCustomizationChoiceEffect(XElement effectElement)
        {
            var cust = new ClassCustomizationChoiceEffect(new ModifiableChoice(),
                ParseClassType(effectElement.Attribute("AffectedClass").Value));
            _outstandingClassCustomizationChoiceEffects.Add(cust);
            return cust;
        }

        #region Individual effect parsing code
        private static IEffect ParseSaveProficiencyEffect(XElement effectElement)
        {
            return new SaveProficiencyEffect(
                modifier: ParseProficiencyType(effectElement.Attribute("Proficiency").Value),
                saveModified: ParseStatType(effectElement.Attribute("SaveModified").Value));
        }

        private static IEffect ParseModifyFeatureEffect(XElement effectElement)
        {
            return new ModifyFeatureEffect(
                new CharacterFeature(
                    name: effectElement.Attribute("Name").Value,
                    description: effectElement.Attribute("Description").Value,
                    shortDescription: effectElement.Attribute("ShortDescription").Value,
                    source: effectElement.Attribute("Source").Value));
        }

        private static IEffect ParseMinimumStatEffect(XElement effectElement)
        {
            return new MinimumStatEffect(
                type: (StatType) Enum.Parse(typeof (StatType), effectElement.Attribute("Stat").Value),
                statMinimum: int.Parse(effectElement.Attribute("Minimum").Value));
        }

        private static IEffect ParseMinimumSkillProficiencyEffect(XElement effectElement)
        {
            return new MinimumSkillProficiencyEffect(
                type: ParseSkillType(effectElement.Attribute("Skill").Value),
                minimumModifierType: ParseProficiencyType(effectElement.Attribute("Proficiency").Value));
        }

        private static IEffect ParseBonusStatEffect(XElement effectElement)
        {
            return new BonusStatEffect(
                type: ParseStatType(effectElement.Attribute("Stat").Value),
                bonus: int.Parse(effectElement.Attribute("Bonus").Value));
        }

        private static IEffect ParseBonusSpeedEffect(XElement effectElement)
        {
            return new BonusSpeedEffect(
                speedBonus: int.Parse(effectElement.Attribute("Speed").Value));
        }

        private static IEffect ParseBonusSkillEffect(XElement effectElement)
        {
            return new BonusSkillEffect(
                skillType: ParseSkillType(effectElement.Attribute("Skill").Value),
                skillBonus: int.Parse(effectElement.Attribute("Bonus").Value));
        }

        private static IEffect ParseArmorWithMaxDexEffect(XElement effectElement)
        {
            return new ArmorWithMaxDexEffect(
                acBonus: int.Parse(effectElement.Attribute("Bonus").Value),
                maxDex: int.Parse(effectElement.Attribute("MaxDex").Value));
        }

        private static IEffect ParseArmorAddStatEffect(XElement effectElement)
        {
            return new ArmorAddStatEffect(
                associatedStatType: ParseStatType(effectElement.Attribute("Stat").Value));
        }

        private static IEffect ParseAddProficiencyEffect(XElement effectElement)
        {
            return new AddProficiencyEffect(
                new Proficiency(
                    source: effectElement.Attribute("Source").Value,
                    name: effectElement.Attribute("Name").Value));
        }

        private static IEffect ParseAddFeatureEffect(XElement effectElement)
        {
            return new AddFeatureEffect(
                new CharacterFeature(
                    name: effectElement.Attribute("Name").Value,
                    description: effectElement.Attribute("Description").Value,
                    shortDescription: effectElement.Attribute("ShortDescription").Value,
                    source: effectElement.Attribute("Source").Value));
        }
        #endregion

        #region EnumParsing
        private static SkillType ParseSkillType(string value)
        {
            return (SkillType)Enum.Parse(typeof(SkillType), value);
        }

        private static StatType ParseStatType(string value)
        {
            return (StatType)Enum.Parse(typeof(StatType), value);
        }

        private static ProficencyModifierType ParseProficiencyType(string value)
        {
            return (ProficencyModifierType) Enum.Parse(typeof (ProficencyModifierType), value);
        }

        private static CharacterClassType ParseClassType(string value)
        {
            return (CharacterClassType) Enum.Parse(typeof (CharacterClassType), value);
        }
        #endregion
    }
}
