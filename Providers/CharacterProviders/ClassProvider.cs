using System.Collections.Generic;
using System.Diagnostics;
using Data.Models;
using Data.Models.Effects;

namespace Providers.CharacterProviders
{
    public class ClassProvider : IClassProvider
    {
        public CharacterClass GetSampleClass()
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
                            new SaveProficiencyEffect(ProficencyModifierType.Proficent, StatType.Strength),
                            new SaveProficiencyEffect(ProficencyModifierType.Proficent, StatType.Constitution),
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
                                    source: "Barbarian"))
                        }, 1)
                }, CharacterClassType.Barbarian);
        }

        public CharacterClass GetClassByClassType(CharacterClassType type)
        {
            throw new System.NotImplementedException();
        }
    }
}
