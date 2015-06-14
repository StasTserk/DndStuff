using System.Collections.Generic;
using System.Linq;
using Data.Models.Effects;

namespace Data.Models
{
    public enum CharacterClassType
    {
        Barbarian,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Sorcerer,
        Warlock,
        Wizard
    }

    /// <summary>
    /// Data structure representing a set of benifits gained by gaining a class
    /// </summary>
    public class ClassLevel : IEffect
    {
        private readonly IEnumerable<IEffect> _levelEffects;
        private readonly int _level;
        private readonly CharacterClassType _classType ;

        public ClassLevel(IEnumerable<IEffect> levelEffects, int level, CharacterClassType classType)
        {
            _levelEffects = levelEffects;
            _level = level;
            _classType = classType;
        }

        public int Level
        {
            get { return _level;  }
        }

        public IEnumerable<IEffect> LevelEffects 
        {
            get { return _levelEffects; }
        }

        public CharacterClassType ClassType { get { return _classType; } }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.LevelModifiers.AddClass(this);
            foreach (var levelEffect in _levelEffects)
            {
                levelEffect.ApplyToCharacter(targetCharacter);
            }
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            foreach (var levelEffect in _levelEffects)
            {
                levelEffect.RemoveFromCharacter(targetCharacter);
            }
        }
    }

    public class CharacterClass
    {
        private readonly IEnumerable<ClassLevel> _levelEffects ;
        private readonly CharacterClassType _classType;
        public CharacterClass(IEnumerable<ClassLevel> levelEffects, CharacterClassType classType)
        {
            _levelEffects = levelEffects;
            _classType = classType;
        }

        public IEnumerable<ClassLevel> LevelEffects
        {
            get { return _levelEffects; }
        }

        public CharacterClassType ClassType
        {
            get { return _classType; }
        }

        public ClassLevel GetClassLevel(int level)
        {
            return _levelEffects.FirstOrDefault(l => l.Level == level);
        }
    }
}
