using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Effects
{
    public interface IArmorClassEffect : IEffect
    {
        int GetArmorClass(int currentArmorClass);
        int GetDexBonus(int dexBonus);
    }
}
