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

        private readonly IList<IStatEffect> _statEffects;

        public int Score
        {
            get
            {   // chains stat modifiers
                return _statEffects.Aggregate(_baseScore, (stat, mod) => mod.GetAffectedStatScore(stat));
            }
        }

        private int _baseScore;
        public int BaseScore 
        {
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

        public void AddEffect(IStatEffect effect)
        {
            _statEffects.Insert(0, effect);
            RaisePropertyChanged(() => Score);
            RaisePropertyChanged(() => Modifier);
            RaisePropertyChanged(() => Save);
        }

        public void AddEffectLast(IStatEffect effect)
        {
            _statEffects.Add(effect);
            RaisePropertyChanged(() => Score);
            RaisePropertyChanged(() => Modifier);
            RaisePropertyChanged(() => Save);
        }

        public void RemoveEffect(IStatEffect effect)
        {
            _statEffects.Remove(effect);
            RaisePropertyChanged(() => Score);
            RaisePropertyChanged(() => Modifier);
            RaisePropertyChanged(() => Save);
        }

        public Stat(LevelModifiers modifiers)
        {
            _modifiers = modifiers;
            _statEffects = new List<IStatEffect>();
        }
    }
}
