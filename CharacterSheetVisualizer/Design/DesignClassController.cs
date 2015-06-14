using System.Collections.Generic;
using Data.Models;
using Data.Models.Effects;
using Services.Controllers.Interfaces;

namespace CharacterSheetVisualizer.Design
{
    class DesignClassController : IClassController
    {
        public CharacterClass GetClassByClassType(CharacterClassType type)
        {
            return new CharacterClass(
                new List<ClassLevel>
                {
                    new ClassLevel(
                        new List<IEffect>
                        {
                            new AddProficiencyEffect(
                                new Proficiency(source: "Barbarian", name: "Light Armor")),
                            new AddProficiencyEffect(
                                new Proficiency(source: "Barbarian", name: "Medium Armor")),
                            new AddProficiencyEffect(
                                new Proficiency(source: "Barbarian", name: "Simple Weapons")),
                            new AddProficiencyEffect(
                                new Proficiency(source: "Barbarian", name: "Exotic Weapons")),
                            new SaveProficiencyEffect(ProficencyModifierType.Proficient, StatType.Strength),
                            new SaveProficiencyEffect(ProficencyModifierType.Proficient, StatType.Constitution),
                            new AddFeatureEffect(
                                new CharacterFeature(
                                    name: "Rage",
                                    description: "Gain advantage with melee rolls and resistance to damage",
                                    shortDescription: "Get mad",
                                    source: "Barbarian")),
                            new AddFeatureEffect(
                                new CharacterFeature(
                                    name: "Unarmored Defense",
                                    description: "Gain CON to AC while not wearing armor",
                                    shortDescription: "Gain CON TO AC",
                                    source: "Barbarian")),
                            new ArmorAddStatEffect(StatType.Constitution)
                        }, 1, CharacterClassType.Barbarian),
                    new ClassLevel(
                        new List<IEffect>
                        {
                            new AddFeatureEffect(
                                new CharacterFeature(
                                    name: "Reckless Attack",
                                    description: "Gain advantage on strength chceks and melee attacks while granting advantage on attacks",
                                    shortDescription: "Easier to hit, easier to be hit",
                                    source: "Barbarian")),
                            new AddFeatureEffect(
                                new CharacterFeature(
                                    name: "Danger Sense",
                                    description: "Gain advantage on dexterity saving throws against things you can see",
                                    shortDescription: "Advantage to Dex Saves vs things you are aware of",
                                    source: "Barbarian"))
                        }, 2, CharacterClassType.Barbarian)
                }, CharacterClassType.Barbarian);
        }
    }
}
