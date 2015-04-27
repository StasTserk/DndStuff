using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterSheetVisualizer.Model
{
    public class CharacterService 
        : ICharacterService
    {
        private readonly IStatService _statService;

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

        public CharacterService(IStatService statService)
        {
            _statService = statService;
            
            // Load a new Character
            CreateNewCharacter();
        }

        public void CreateNewCharacter()
        {
            var modifiers = new LevelModifiers()
            {
                Level = 1
            };


            var defaultStats = _statService.GetDefaultStats(modifiers);

            var enumerable = defaultStats.ToList();

            var defaultSkills = new List<Skill>
            {
                new Skill(enumerable.First(x => x.Type == StatType.Wisdom), modifiers)
                {
                    Type = SkillType.Perception,
                    ModifierType = ProficencyModifierType.Proficent
                }
            };

            CurrentCharacter = new Character()
            {
                Stats = enumerable,
                Skills = defaultSkills
            };
        }
    }
}
