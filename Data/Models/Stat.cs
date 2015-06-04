using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data.Models.Effects;
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

        private IList<IStatEffect> _statEffects;
        public IList<IStatEffect> StatEffects {
            get { return _statEffects ?? (_statEffects = new List<IStatEffect>()); }
            set { _statEffects = value; }
        }

        public int Score
        {
            get
            {   // chains stat modifiers
                return StatEffects.Aggregate(_baseScore, (stat, mod) => mod.GetAffectedStatScore(stat));
            }
        }

        private int _baseScore;
        public int BaseScore {
            get { return _baseScore; }
            set
            {
                if (_baseScore == value)
                {
                    return;
                }
                
                _baseScore = value;

                RaisePropertyChanged(() => BaseScore);
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
