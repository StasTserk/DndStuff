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

            return (int)(multiplier * (2 + (Level / 4)));
        }

    }
}
