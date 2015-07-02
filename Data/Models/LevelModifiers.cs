using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public enum ProficencyModifierType
    {
        None,
        JackOfAllTrades,
        Proficient,
        Expert
    }

    public class LevelModifiers
        : ObservableObject
    {
        #region Backing fields
        private readonly ICollection<ClassLevel> _classLevels;
        private readonly ICollection<CharacterClass> _characterClasses; 
        private int _level;
        #endregion

        #region Constructors
        public LevelModifiers()
        {
            _classLevels = new List<ClassLevel>();
        }
        #endregion

        #region Properties
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
                RaisePropertyChanged(() => NextLevelTooltip);
                RaisePropertyChanged(() => ComposedClassLevelString);
            }
        }

        public string NextLevelTooltip
        {
            get
            {
                var tooltip = "Experience to next level: ";
                tooltip = tooltip + ExperienceToNextLevelString();
                return tooltip;
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
                case ProficencyModifierType.Proficient:
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
            get
            {
                return ClassesAndLevels.Aggregate(
                    @"", (current, classAndLevel) =>
                        string.Join("/", current, string.Format(@"{0} {1}", classAndLevel.Item1, classAndLevel.Item2)))
                    .Substring(1); // remove leading /
            }
        }

        public int ProficiencyBonus
        {
            get { return 2 + (Level/4); }
        }

        public IEnumerable<CharacterClass> CharacterClasses; 

        public IEnumerable<Tuple<CharacterClassType, int>> ClassesAndLevels
        {
            get
            {
                return from c in _classLevels
                    group c.Level by c.ClassType
                    into g
                    select new Tuple<CharacterClassType, int>(
                        g.Key, 
                        g.Max(l => l));
            }
        }
        #endregion

        #region Class Level Handling
        public void RemoveClassLevel(ClassLevel classLevel)
        {
            _classLevels.Remove(classLevel);
            Level --;
        }

        public void AddClassLevel(ClassLevel classLevel)
        {
            _classLevels.Add(classLevel);
            Level++;
        }
        #endregion

        #region Helper Methods
        private string ExperienceToNextLevelString()
        {
            switch (Level)
            {
                case 1:
                    return "300";
                case 2:
                    return "900";
                case 3:
                    return "2,700";
                case 4:
                    return "6,500";
                case 5:
                    return "14,000";
                case 6:
                    return "23,000";
                case 7:
                    return "34,000";
                case 8:
                    return "48,000";
                case 9:
                    return "64,000";
                case 10:
                    return "85,000";
                case 11:
                    return "100,000";
                case 12:
                    return "120,000";
                case 13:
                    return "140,000";
                case 14:
                    return "165,000";
                case 15:
                    return "195,000";
                case 16:
                    return "225,000";
                case 17:
                    return "265,000";
                case 18:
                    return "305,000";
                case 19:
                    return "355,000";
                default:
                    return "NaN";
            }
        }
        #endregion
    }
}
