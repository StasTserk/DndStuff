using System.Collections.Generic;
using System.Linq;
using Data.Models.Items;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public class Character
        : ObservableObject
    {
        public IEnumerable<Stat> Stats { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public string PlayerName { get; set; }
        public string CharacterName { get; set; }
        public string RaceName { get; set; }
        public string AlignmentName { get; set; }
        public IEnumerable<Proficiency> OtherProficiencies { get; set; }
        public IEnumerable<CharacterFeature> FeaturesAndTraits { get; set; }
        public IEnumerable<IEquippable> EquippedItems { get { return _equippedItems;} }
        public IEnumerable<IItem> Inventory {
            get { return _inventory; }
        }

        private readonly ICollection<IEquippable> _equippedItems;
        private readonly ICollection<IItem> _inventory;

        public Character()
        {
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
    }
}
