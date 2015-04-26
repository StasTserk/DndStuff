using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace CharacterSheetVisualizer.Model
{
    public enum StatType
    {
        Strength,
        Intelligence,
        Agility
    }

    public class Stat
        : ObservableObject
    {
        private int _score;

        public StatType Type
        {
            get; set;
        }

        public int Score
        {
            get
            {
                return _score;
            }
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
            get { return Modifier + ProficencyBonus; }
        }

        private int _proficencyBonus;
        public int ProficencyBonus
        {
            get { return _proficencyBonus; }
            set
            {
                if (_proficencyBonus == value)
                {
                    return;
                }

                _proficencyBonus = value;
                
                // Notify the Change for all properties that Depend on the Proficency Bonus
                RaisePropertyChanged(() => ProficencyBonus);
                RaisePropertyChanged(() => HasProficency);
                RaisePropertyChanged(() => Save);
            }
        }

        public bool HasProficency
        {
            get { return ProficencyBonus > 0; }
        }
    }

    public class Character
        : ObservableObject
    {
        public IEnumerable<Stat> Stats { get; set; }

        public Character()
        {
            Stats = new List<Stat>
            {
                new Stat()
                {
                    ProficencyBonus = 2,
                    Score = 10,
                    Type = StatType.Agility
                },
                new Stat()
                {
                    ProficencyBonus = 0,
                    Score = 10,
                    Type = StatType.Strength
                }
            };
        }
    }
}
