using System;
using GalaSoft.MvvmLight;

namespace Data.Models
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
            get { return (int)Math.Floor(Score / 2.0) - 5; }
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
}
