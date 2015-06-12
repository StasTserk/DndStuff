using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Data.Models.Effects;
using Data.Models.Items;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public class Character
        : ObservableObject
    {
        #region Backing Fields
        private readonly ICollection<IOtherProficencyEffect> _proficiencyEffects;
        private readonly ICollection<IFeatureEffect> _featureEffects;
        private readonly ICollection<IEquippable> _equippedItems;
        private readonly ICollection<IItem> _inventory;
        private IEnumerable<Skill> _skills;
        private IEnumerable<Stat> _stats; 
        #endregion

        #region Properties
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

        public string PlayerName { get; set; }
        public string CharacterName { get; set; }
        public string RaceName { get; set; }
        public string AlignmentName { get; set; }
        public LevelModifiers LevelModifiers { get; set; }
        public ArmorClass Armor { get; set; }

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
        #endregion

        #region Constructors
        public Character()
        {
            _featureEffects = new List<IFeatureEffect>();
            _proficiencyEffects = new List<IOtherProficencyEffect>();
            _equippedItems = new List<IEquippable>();
            _inventory = new List<IItem>();
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
        #endregion
    }
}
