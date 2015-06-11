using System;

namespace Data.Models.Effects
{
    class ArmorWithMaxDexEffect : IArmorClassEffect
    {
        private readonly int _acBonus;
        private readonly int _maxDex;

        /// <summary>
        /// Holds information for an armor with a maximum dexterity bonus
        /// </summary>
        /// <param name="acBonus">Bonus added to AC by the armor - Calculated as the given Base AC - 10</param>
        /// <param name="maxDex">Maximum bonus to be gained from dexterity; -1 for unlimited.</param>
        public ArmorWithMaxDexEffect(int acBonus, int maxDex)
        {
            _acBonus = acBonus;
            _maxDex = maxDex;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.Armor.AddArmorClassEffect(this);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.Armor.RemoveArmorClassEffect(this);
        }

        public int GetArmorClass(int currentArmorClass)
        {
            return currentArmorClass + _acBonus;
        }

        public int GetDexBonus(int dexBonus)
        {
            if (_maxDex == -1)
            {
                return dexBonus;
            }
            return (dexBonus > _maxDex) ? _maxDex : dexBonus;
        }
    }
}
