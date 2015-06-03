using System;
using System.Collections.Generic;
using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public enum SkillType
    {
        Perception,
        Stealth,
        Acrobatics,
        AnimalHandling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Investigation,
        Medicine,
        Nature,
        Performance,
        Persuasion,
        Religion,
        SleightOfHand,
        Survival
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
                if (_modifierType == value)
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

        private void StatModifierChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(() => Modifier);
        }

        public Skill(Stat associatedStat, LevelModifiers modifier)
        {
            _modifiers = modifier;
            _associatedStat = associatedStat;
            _associatedStat.PropertyChanged += StatModifierChanged;
        }


    }

}
