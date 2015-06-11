using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Models.Effects;
using Data.Models.Items;

namespace Providers.CharacterProviders
{
    public class CharacterProvider 
        : ICharacterProvider
    {
        private readonly IStatProvider _statProvider;
        private readonly ISkillProvider _skillProvider;
        private readonly IClassProvider _classProvider;

        public event EventHandler NewCharacterLoaded;

        private Character _currentCharacter;
        public Character CurrentCharacter
        {
            get { return _currentCharacter; }
            private set
            {
                _currentCharacter = value;
                
                if (NewCharacterLoaded != null)
                {
                    NewCharacterLoaded(this, new EventArgs());     
                }
            }
        }

        public CharacterProvider(IStatProvider statProvider, ISkillProvider skillProvider, IClassProvider classProvider)
        {
            _statProvider = statProvider;
            _skillProvider = skillProvider;
            _classProvider = classProvider;
            // Load a new Character
            CreateNewCharacter();
        }

        public void CreateNewCharacter()
        {
            var modifiers = new LevelModifiers()
            {
                Level = 1
            };


            var defaultStats = _statProvider.GetDefaultStats(modifiers);

            var enumerable = defaultStats.ToList();

            var defaultSkills = _skillProvider.GetDefaultSkills(
                modifiers,
                enumerable.FirstOrDefault(s => s.Type == StatType.Strength),
                enumerable.FirstOrDefault(s => s.Type == StatType.Dexterity),
                enumerable.FirstOrDefault(s => s.Type == StatType.Wisdom),
                enumerable.FirstOrDefault(s => s.Type == StatType.Intelligence),
                enumerable.FirstOrDefault(s => s.Type == StatType.Charisma)
                );

            var acTracker = new ArmorClass(enumerable.First(s => s.Type == StatType.Dexterity));

            CurrentCharacter = new Character()
            {
                Stats = enumerable,
                Skills = defaultSkills.ToList(),
                Armor = acTracker,
                LevelModifiers = modifiers
            };

            var minimumStatBonus = new MinimumStatEffect(StatType.Strength, 17);
            var flatStatBonus = new BonusStatEffect(StatType.Dexterity, 2);

            var effectList = new List<IEffect>
            {
                minimumStatBonus,
                flatStatBonus
            };

            _classProvider.GetSampleClass().GetClassLevel(1).ApplyToCharacter(CurrentCharacter);

            var randomHat = new EquippableItem(
                name: "Cool Hat", 
                description: "A cool hat",
                shortDescription: "Coolhat",
                weight: 1,
                cost: 100,
                slot: EquippableSlot.Head,
                effects: effectList);

            CurrentCharacter.Equip(randomHat);
        }
    }
}
