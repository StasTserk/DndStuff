using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;

namespace Data.Models
{
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
        private ICollection<ClassLevel> _classLevels;

        private int _level;

        public LevelModifiers()
        {
            _classLevels = new List<ClassLevel>();
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (_level == value)
                    return;

                _level = value;

                RaisePropertyChanged(() => Level);
                RaisePropertyChanged(() => ProficiencyBonus);
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
                case ProficencyModifierType.Proficent:
                    multiplier = 1.0;
                    break;
                case ProficencyModifierType.JackOfAllTrades:
                    multiplier = 0.5;
                    break;
                default:
                    multiplier = 0.0;
                    break;
            }

            return (int)(multiplier * ProficiencyBonus);
        }

        public string ComposedClassLevelString
        {
            get { return _classLevels.First().ClassType + " 1"; }
        }

        public void AddClass(ClassLevel classLevel)
        {
            _classLevels.Add(classLevel);
            Level ++;
        }

        public int ProficiencyBonus
        {
            get { return 2 + (Level/4); }
        }
    }
}
