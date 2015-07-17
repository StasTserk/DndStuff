using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Data.Models.Effects;
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
        private readonly Stat _associatedStat;
        private readonly LevelModifiers _modifiers;
        private readonly ICollection<ISkillEffect> _skillEffects;
        private readonly ICollection<ISkillProficiencyEffect> _skillProfficiencyEffects;

        public SkillType Type { get; set; }

        public int SelectedIndex
        {
            get { return 0; }
            set { Console.Out.Write("Blacch"); }
        }

        private ProficencyModifierType _modifierType;
        public ProficencyModifierType ModifierType
        {
            get
            {
                return _skillProfficiencyEffects.Aggregate(
                    _modifierType, (type, mod) => mod.GetModifiedProficiency(type)
                    );
            }
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
            get
            {
                return _skillEffects.Aggregate(
                    _associatedStat.Modifier + _modifiers.GetProficencyBonus(ModifierType),
                    (val, mod) => mod.GetAffectedSkillScore(val));
            }
        }

        public IEnumerable<ProficencyModifierType> ModifierTypes
        {
            get
            {
                return new List<ProficencyModifierType>
                {
                    ProficencyModifierType.None,
                    ProficencyModifierType.JackOfAllTrades,
                    ProficencyModifierType.Proficient,
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
            _skillEffects = new List<ISkillEffect>();
            _skillProfficiencyEffects = new List<ISkillProficiencyEffect>();

            _modifiers = modifier;
            _associatedStat = associatedStat;
            _associatedStat.PropertyChanged += StatModifierChanged;
        }

#region Effects
        public void AddSkillEffect(ISkillEffect skillEffect)
        {
            _skillEffects.Add(skillEffect);
            RaisePropertyChanged(() => Modifier);
        }

        public void RemoveSkillEffect(ISkillEffect skillEffect)
        {
            _skillEffects.Remove(skillEffect);
            RaisePropertyChanged(() => Modifier);
        }

        public void AddSkillProficiencyEffect(ISkillProficiencyEffect effect)
        {
            _skillProfficiencyEffects.Add(effect);
            RaisePropertyChanged(() => ModifierType);
            RaisePropertyChanged(() => Modifier);
        }

        public void RemoveSkillProficiencyEffect(ISkillProficiencyEffect effect)
        {
            _skillProfficiencyEffects.Remove(effect);
            RaisePropertyChanged(() => ModifierType);
            RaisePropertyChanged(() => Modifier);
        }
#endregion
    }
}
