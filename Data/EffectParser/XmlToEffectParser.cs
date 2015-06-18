using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Data.Models;
using Data.Models.Effects;

namespace Data.EffectParser
{
    public class XmlToEffectParser : IEffectParser
    {
        public IEnumerable<IEffect> GetEffectsFromXml(XElement element)
        {
            return element.Elements("Effect").Select(ParseEffect).ToList();
        }

        private static IEffect ParseEffect(XElement effectElement)
        {
            switch (effectElement.Attribute("Type").Value)
            {
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
            throw new InvalidDataException("XML Element contains invalid type attribute");
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
        #endregion
    }
}
