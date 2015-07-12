using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Models.Choices;
using Data.Models.Effects;
using Data.Models.Items;
using Data.Models.Managers;
using Data.Repositories.Interfaces;

namespace Providers.CharacterProviders
{
    public class CharacterProvider 
        : ICharacterProvider
    {
        private readonly IStatProvider _statProvider;
        private readonly ISkillProvider _skillProvider;
        private readonly IClassProvider _classProvider;
        private readonly IRaceProvider _raceProvider;
        private readonly ISpellLoader _spellLoader;
        private readonly IBackgroundProvider _backgroundProvider;

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

        public CharacterProvider(
            IStatProvider statProvider, 
            ISkillProvider skillProvider, 
            IClassProvider classProvider, 
            IRaceProvider raceProvider, 
            IBackgroundProvider backgroundProvider, 
            ISpellLoader spellLoader)
        {
            _statProvider = statProvider;
            _skillProvider = skillProvider;
            _classProvider = classProvider;
            _raceProvider = raceProvider;
            _backgroundProvider = backgroundProvider;
            _spellLoader = spellLoader;
            // Load a new Character
            CreateNewCharacter();
        }

        public void CreateNewCharacter()
        {
            var modifiers = new LevelModifiers();

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
                LevelModifiers = modifiers,
                PlayerName = "Coolguy Steve",
                CharacterName = "Bruenor",
                SpellBook = new SpellBookManager(_spellLoader)
            };

            var minimumStatBonus = new MinimumStatEffect(StatType.Strength, 17);
            var flatStatBonus = new BonusStatEffect(StatType.Dexterity, 2);



            // set level up choice
            var choice = new ClassSelectionChoice(
                CurrentCharacter.LevelModifiers,
                _classProvider.GetAvailableLevelUpOptions(CurrentCharacter)
                )
            {
                Description = string.Format(@"Pick your level {0} class", CurrentCharacter.LevelModifiers.Level + 1),
                Name = string.Format(@"Level Up to {0}", CurrentCharacter.LevelModifiers.Level + 1),
                ShortDescription = string.Format(@"Pick your level {0} class", CurrentCharacter.LevelModifiers.Level + 1)
            };
            CurrentCharacter.AddChoice(choice);

            //var effectList = new List<IEffect>
            //{
            //    minimumStatBonus,
            //    flatStatBonus
            //};

            //var randomHat = new EquippableItem(
            //    name: "Cool Hat", 
            //    description: "A cool hat",
            //    shortDescription: "Coolhat",
            //    weight: 1,
            //    cost: 100,
            //    slot: EquippableSlot.Head,
            //    effects: effectList);

            //CurrentCharacter.Equip(randomHat);
            _raceProvider.GetRaceChoiceEffect().ApplyToCharacter(CurrentCharacter);
            _backgroundProvider.GetBackgroundChoiceEffect().ApplyToCharacter(CurrentCharacter);
        }
    }
}
