using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Data.Models.Effects;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public class ArmorClass : ObservableObject
    {
        private readonly Stat _associatedStat;
        private readonly ICollection<IArmorClassEffect> _armorClassEffects; 

        public ArmorClass(Stat associatedStat)
        {
            _associatedStat = associatedStat;
            _armorClassEffects = new List<IArmorClassEffect>();
            
            _associatedStat.PropertyChanged += UpdateAc;
        }

        public void UpdateAc(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(() => Value);
        }

        public int Value
        {
            get
            {
                // calculate aggregate dexterity bonus
                int dexBonus = _armorClassEffects.Aggregate(
                    _associatedStat.Modifier,
                    (dex, mod) => mod.GetDexBonus(dex));

                // calculate ac as 10 + dex (capped) + ac
                return 10 + _armorClassEffects.Aggregate(
                    dexBonus, (ac, mod) => mod.GetArmorClass(ac));
            }
        }

        public void AddArmorClassEffect(IArmorClassEffect armorEffect)
        {
            _armorClassEffects.Add(armorEffect);
            RaisePropertyChanged(() => Value);
        }

        public void RemoveArmorClassEffect(IArmorClassEffect armorEffect)
        {
            _armorClassEffects.Remove(armorEffect);
            RaisePropertyChanged(() => Value);
        }
    }
}
