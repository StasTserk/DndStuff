using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Data.Models.Choices;
using Data.Models.Effects;
using Data.Models.Items;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public enum AlignmentType
    {
        LawfulGood,
        Good,
        ChaoticGood,
        Lawful,
        Neutral,
        Chaotic,
        LawfulEvil,
        Evil,
        ChaoticEvil
    }

    public class Character
        : ObservableObject
    {
        #region Backing Fields
        private readonly ICollection<IOtherProficencyEffect> _proficiencyEffects;
        private readonly ICollection<IFeatureEffect> _featureEffects;
        private readonly ICollection<ISpeedEffect> _speedEffects;
        private readonly ICollection<IEquippable> _equippedItems;
        private readonly ICollection<IItem> _inventory;
        private readonly ICollection<IChoice> _oustandingChoices;
        private ICollection<IChoice> _completedChoices;
        private Race _race;
        private IEnumerable<Skill> _skills;
        private IEnumerable<Stat> _stats;
        private AlignmentType _alignment;
        

        #endregion

        #region Properties

        public IEnumerable<IChoice> OutstandingChoices 
        {
            get { return _oustandingChoices; }
        }

        public IEnumerable<IChoice> CompletedChoices
        {
            get { return _completedChoices; }
        }

        public IEnumerable<Stat> Stats {
            get { return _stats; }
            set
            {
                _stats = value;
                _stats.First(s => s.Type == StatType.Dexterity).PropertyChanged +=
                    UpdateInitiative;

                foreach (var stat in value)
                {
                    stat.PropertyChanged += UpdatePointBuyEquivalent;
                }
            }
        }

        public IEnumerable<Skill> Skills 
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
                _skills.First(s => s.Type == SkillType.Perception).PropertyChanged +=
                    UpdatePassivePerception;
            } 
        }

        public int PassivePerception
        {
            get { return 10 + Skills.First(s => s.Type == SkillType.Perception).Modifier; }
        }

        public int Initiative
        {
            get { return Stats.First(s => s.Type == StatType.Dexterity).Modifier; }
        }
        
        public int ExperiencePoints { get; set; }

        public int Speed
        {
            get
            {
                return _speedEffects.Aggregate(
                    0, (speed, mod) => mod.GetSpeed(speed));
            }
        }

        public string PlayerName { get; set; }
        
        public string CharacterName { get; set; }
        
        public Race Race 
        {
            get
            {
                return _race;
            }
            set
            {
                _race = value;
                RaisePropertyChanged(() => Race.Name);
            } 
        }
        
        public LevelModifiers LevelModifiers { get; set; }
        
        public ArmorClass Armor { get; set; }

        public AlignmentType Alignment
        {
            get {return _alignment;}
            set
            {
                _alignment = value;
                RaisePropertyChanged(() => Alignment);
            }
        }
        
        public IEnumerable<Proficiency> OtherProficiencies
        {
            get
            {
                var profList = new List<Proficiency>();
                foreach (var prof in _proficiencyEffects)
                {
                    prof.GetProficencyList(profList);
                }
                return profList;
            }
        }

        public IEnumerable<CharacterFeature> FeaturesAndTraits
        {
            get
            {
                var featureList = new List<CharacterFeature>();
                foreach (var prof in _featureEffects)
                {
                    prof.GetFeatureList(featureList);
                }
                return featureList;
            }
        }

        public IEnumerable<IEquippable> EquippedItems
        {
            get { return _equippedItems;}
        }
        
        public IEnumerable<IItem> Inventory 
        {
            get { return _inventory; }
        }

        public int PointBuyEquivalent
        {
            get { return Stats.Sum(s => s.PointBuyEquivalent); }
        }

        public Background Background { get; set; }

        public ClassCustomization ClassCustomization { get; set; }

        #endregion

        #region Constructors
        public Character()
        {
            _featureEffects = new List<IFeatureEffect>();
            _proficiencyEffects = new List<IOtherProficencyEffect>();
            _equippedItems = new List<IEquippable>();
            _inventory = new List<IItem>();
            _speedEffects = new List<ISpeedEffect>();
            _oustandingChoices = new List<IChoice>();
            _completedChoices = new List<IChoice>();
        }
        #endregion

        #region Choice Handling

        // TODO reowrk massive logic flaw (dealing with ChoiceEffects instead of choices directly?)
        public void AddChoice(IChoice choice)
        {
            _oustandingChoices.Add(choice);
        }

        public void RemoveChoice(IChoice choice)
        {
            _oustandingChoices.Remove(choice);
        }

        public void MakeChoice(IChoice choiceSet, IChoiceOption choiceOption)
        {
            if (choiceSet == null || choiceOption == null) return;

            choiceSet.MakeChoice(choiceOption);
            _oustandingChoices.Remove(choiceSet);
            _completedChoices.Add(choiceSet);

            RaisePropertyChanged(() => CompletedChoices);
            RaisePropertyChanged(() => OutstandingChoices);
        }

        #endregion

        #region Item Handling
        public void Equip(IEquippable equippableItem)
        {
            var slot = equippableItem.GetSlot();
            // If slot is taken, unequip item already in the slot
            if (_equippedItems.Any(i => i.GetSlot() == slot))
            {
                Unequip(_equippedItems.First(i => i.GetSlot() == slot));
            }

            // add item to equipped item collection, apply item effects, 
            // remove from inventory
            _equippedItems.Add(equippableItem);
            equippableItem.EquipOn(this);
            _inventory.Remove(equippableItem);

            RaisePropertyChanged(() => Inventory);
            RaisePropertyChanged(() => EquippedItems);
        }

        public void Unequip(IEquippable equippableItem)
        {
            // Remove item from inventory, remove effects, add to inventory
            _equippedItems.Remove(equippableItem);
            equippableItem.RemoveFrom(this);
            _inventory.Add(equippableItem);

            RaisePropertyChanged(() => Inventory);
            RaisePropertyChanged(() => EquippedItems);
        }
        #endregion

        #region Event Handling
        private void UpdatePassivePerception(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(() => PassivePerception);
        }

        private void UpdateInitiative(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(() => Initiative);
        }

        private void UpdatePointBuyEquivalent(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(() => PointBuyEquivalent);
        }
        #endregion

        #region Effects handling
        public void AddProficiencyEffect(IOtherProficencyEffect otherProficencyEffect)
        {
            _proficiencyEffects.Add(otherProficencyEffect);
            RaisePropertyChanged(() => OtherProficiencies);
        }

        public void RemoveProficiencyEffect(IOtherProficencyEffect otherProficencyEffect)
        {
            _proficiencyEffects.Remove(otherProficencyEffect);
            RaisePropertyChanged(() => OtherProficiencies);
        }

        public void AddFeatureEffect(IFeatureEffect featureEffect)
        {
            _featureEffects.Add(featureEffect);
            RaisePropertyChanged(() => FeaturesAndTraits);
        }

        public void RemoveFeatureEffect(IFeatureEffect featureEffect)
        {
            _featureEffects.Remove(featureEffect);
            RaisePropertyChanged(() => FeaturesAndTraits);
        }

        public void AddSpeedEffect(ISpeedEffect speedEffect)
        {
            _speedEffects.Add(speedEffect);
            RaisePropertyChanged(() => Speed);
        }

        public void RemoveSpeedEffect(ISpeedEffect speedEffect)
        {
            _speedEffects.Remove(speedEffect);
            RaisePropertyChanged(() => Speed);
        }
        #endregion
    }
}