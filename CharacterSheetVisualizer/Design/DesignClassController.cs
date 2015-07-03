using System.Collections.Generic;
using System.Windows.Media.Effects;
using Data.Models;
using Data.Models.Choices;
using Data.Models.Effects;
using Data.Models.Effects.ChoiceEffects;
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
                        }, 2, CharacterClassType.Barbarian),
                    new ClassLevel(
                        new List<IEffect>
                        {
                            new ChoiceEffect(
                                new ExclusiveEffectChoice(
                                    new List<IChoiceOption>
                                    {
                                        new ChoiceOption(
                                            name: "Choice A", 
                                            description: "Choice A Description",
                                            shortDescription: "Choice A Short Description", 
                                            effect: new AddFeatureEffect(
                                                new CharacterFeature(
                                                    name: "Sample Choice A",
                                                    description: "This is the first option in a choice",
                                                    shortDescription: "Easier to hit, easier to be hit",
                                                    source: "Barbarian"
                                                    )
                                                )
                                            ),
                                        new ChoiceOption(
                                            name: "Choice B", 
                                            description: "Choice B Description",
                                            shortDescription: "Choice B Short Description", 
                                            effect:new AddFeatureEffect(
                                            new CharacterFeature(
                                                name: "Sample Choice B",
                                                description: "Gain advantage on dexterity saving throws against things you can see",
                                                shortDescription: "Advantage to Dex Saves vs things you are aware of",
                                                source: "Barbarian"
                                                )
                                            )
                                        )
                                    })
                                {
                                    Description = "A sample Choice description using many more words         \r\nAnd extra newlines",
                                    Name = "SampleChoice",
                                    ShortDescription = "A sample choice description"
                                })
                                    
                            }, 3, CharacterClassType.Barbarian)                
                }, CharacterClassType.Barbarian);
        }

        public IEnumerable<CharacterClass> GetClasses()
        {
            return new List<CharacterClass>
            {
                GetClassByClassType(CharacterClassType.Barbarian)
            };
        }
    }
}
