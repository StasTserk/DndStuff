using System.Collections.Generic;
using System.Linq;
using Data.Models.Effects;
using Data.Models.Items;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public class Character
        : ObservableObject
    {
        private readonly ICollection<IOtherProficencyEffect> _proficiencyEffects;
        private readonly ICollection<IFeatureEffect> _featureEffects; 

        public IEnumerable<Stat> Stats { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public string PlayerName { get; set; }
        public string CharacterName { get; set; }
        public string RaceName { get; set; }
        public string AlignmentName { get; set; }

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
        public IEnumerable<IEquippable> EquippedItems { get { return _equippedItems;} }
        public IEnumerable<IItem> Inventory {
            get { return _inventory; }
        }

        private readonly ICollection<IEquippable> _equippedItems;
        private readonly ICollection<IItem> _inventory;

        public Character()
        {
            _featureEffects = new List<IFeatureEffect>();
            _proficiencyEffects = new List<IOtherProficencyEffect>();
            _equippedItems = new List<IEquippable>();
            _inventory = new List<IItem>();
        }

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

#region Effects handling
        public void AddProficiencyEffect(IOtherProficencyEffect otherProficencyEffect)
        {
            _proficiencyEffects.Add(otherProficencyEffect);
        }

        public void RemoveProficiencyEffect(IOtherProficencyEffect otherProficencyEffect)
        {
            _proficiencyEffects.Remove(otherProficencyEffect);
        }

        public void AddFeatureEffect(IFeatureEffect featureEffect)
        {
            _featureEffects.Add(featureEffect);
        }

        public void RemoveFeatureEffect(IFeatureEffect featureEffect)
        {
            _featureEffects.Remove(featureEffect);
        }
#endregion
    }
}
