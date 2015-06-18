using System.Collections.Generic;
using Data.Models.Effects;

namespace Data.Models.Items
{
    public class EquippableItem : IEquippable
    {
        private readonly IEnumerable<IEffect> _effects;

        public void Use(Character target)
        {
            EquipOn(target);
        }

        private readonly EquippableSlot _slot;

        private readonly string _name;
        public string Name
        {
            get { return _name; }
        }

        private readonly string _description;
        public string Description
        {
            get { return _description; }
        }

        private readonly string _shortDescription;
        public string ShortDescription
        {
            get { return _shortDescription; }
        }

        private readonly double _weight;
        public double Weight
        {
            get { return _weight; }
        }

        private readonly int _cost;
        public int Cost {
            get { return _cost; }
        }

        public void EquipOn(Character target)
        {
            foreach (var effect in _effects)
            {
                effect.ApplyToCharacter(target);
            }
        }

        public void RemoveFrom(Character target)
        {
            foreach (var effect in _effects)
            {
                effect.RemoveFromCharacter(target);
            }
        }

        public EquippableSlot GetSlot()
        {
            return _slot;
        }

        public EquippableItem(
            string name, string description, string shortDescription, double weight,
            int cost, EquippableSlot slot, IEnumerable<IEffect> effects)
        {
            _name = name;
            _description = description;
            _shortDescription = shortDescription;
            _weight = weight;
            _cost = cost;
            _slot = slot;
            _effects = effects;
        }
    }
}
