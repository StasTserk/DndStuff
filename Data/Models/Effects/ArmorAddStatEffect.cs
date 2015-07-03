using System.Linq;

namespace Data.Models.Effects
{
    public class ArmorAddStatEffect : IArmorClassEffect
    {
        private readonly StatType _associatedStatType;
        private Stat _associatedStat;

        public ArmorAddStatEffect(StatType associatedStatType)
        {
            _associatedStatType = associatedStatType;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            _associatedStat = targetCharacter.Stats.First(s => s.Type == _associatedStatType);
            targetCharacter.Armor.AddArmorClassEffect(this);
            _associatedStat.PropertyChanged += targetCharacter.Armor.UpdateAc;
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.Armor.RemoveArmorClassEffect(this);
            _associatedStat.PropertyChanged -= targetCharacter.Armor.UpdateAc;
            _associatedStat = null;
        }

        public int GetArmorClass(int currentArmorClass)
        {
            return currentArmorClass + _associatedStat.Modifier;
        }

        public int GetDexBonus(int dexBonus)
        {
            return dexBonus;
        }
    }
}
