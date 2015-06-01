﻿using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;

namespace Providers.CharacterProviders
{
    public class CharacterProvider 
        : ICharacterProvider
    {
        private readonly IStatProvider _statProvider;
        private readonly ISkillProvider _skillProvider;

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

        public CharacterProvider(IStatProvider statProvider, ISkillProvider skillProvider)
        {
            _statProvider = statProvider;
            _skillProvider = skillProvider;
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

            var proficiencyList = new List<Proficiency>
            {
                new Proficiency("class", "Snozzberries"),
                new Proficiency("race", "Clambering")
            };

            CurrentCharacter = new Character()
            {
                Stats = enumerable,
                Skills = defaultSkills.ToList(),
                OtherProficiencies = proficiencyList
            };
        }
    }
}