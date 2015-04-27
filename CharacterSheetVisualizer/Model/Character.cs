using System;
using System.CodeDom;
using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace CharacterSheetVisualizer.Model
{
    public enum StatType
    {
        Strength,
        Intelligence,
        Constitution,
        Dexterity,
        Wisdom,
        Charisma
    }

    public enum SkillType
    {
        Perception
    }

    public enum ProficencyModifierType
    {
        None,
        JackOfAllTrades,
        Proficent,
        Expert
    }

    public class LevelModifiers
        : ObservableObject
    {
        private int _level;
        public int Level
        {
            get { return _level; }
            set
            {
                if (_level == value)
                    return;

                _level = value;
                
                RaisePropertyChanged(() => Level);
            }
        }

        public int GetProficencyBonus(ProficencyModifierType type)
        {
            double multiplier;
            switch (type)
            {
                case ProficencyModifierType.Expert:
                    multiplier = 2.0;
                    break;
                case  ProficencyModifierType.Proficent:
                    multiplier = 1.0;
                    break;
                case ProficencyModifierType.JackOfAllTrades:
                    multiplier = 0.5;
                    break;
                default:
                    multiplier = 0.0;
                    break;
            }

            return (int)(multiplier * (2 + (Level/4)));
        }

    }

    public class Skill
        : ObservableObject
    {
        private Stat _associatedStat;
        private LevelModifiers _modifiers;

        public SkillType Type { get; set; }

        public int SelectedIndex
        {
            get { return 0; }
            set
            {
                Console.Out.Write("Blacch");
            }
        }

        private ProficencyModifierType _modifierType;
        public ProficencyModifierType ModifierType 
        {
            get { return _modifierType; }
            set
            {
                if(_modifierType == value)
                    return;

                _modifierType = value;
                RaisePropertyChanged(() => ModifierType);
                RaisePropertyChanged(() => Modifier);
            }
        }

        public int Modifier
        {
            get { return _associatedStat.Modifier + _modifiers.GetProficencyBonus(ModifierType); }
        }

        public IEnumerable<ProficencyModifierType> ModifierTypes
        {
            get
            {
                return new List<ProficencyModifierType>
                {
                    ProficencyModifierType.None,
                    ProficencyModifierType.JackOfAllTrades,
                    ProficencyModifierType.Proficent,
                    ProficencyModifierType.Expert
                };
            }
        }

        public Skill(Stat associatedStat, LevelModifiers modifier)
        {
            _modifiers = modifier;
            _associatedStat = associatedStat;
        }
    }

    public class Stat
        : ObservableObject
    {
        private readonly LevelModifiers _modifiers;

        public StatType Type { get; set; }

        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                if (_score == value)
                {
                    return;
                }

                _score = value;
                RaisePropertyChanged(() => Score);
                RaisePropertyChanged(() => Modifier);
                RaisePropertyChanged(() => Save);
            }
        }

        public int Modifier
        {
            get { return (int) Math.Floor(Score/2.0) - 5; }
        }

        public int Save
        {
            get { return Modifier + _modifiers.GetProficencyBonus(_proficencyType); }
        }

        private ProficencyModifierType _proficencyType;
        public bool IsProficent
        {
            get { return _proficencyType == ProficencyModifierType.Proficent; }
            set
            {
                _proficencyType = value ? ProficencyModifierType.Proficent : ProficencyModifierType.None;

                RaisePropertyChanged(() => IsProficent);
                RaisePropertyChanged(() => Save);
            }
        }

        public Stat(LevelModifiers modifiers)
        {
            _modifiers = modifiers;
        }
   }

    public class Character
        : ObservableObject
    {
        public IEnumerable<Stat> Stats { get; set; }
        public IEnumerable<Skill> Skills { get; set; } 
    }
}
