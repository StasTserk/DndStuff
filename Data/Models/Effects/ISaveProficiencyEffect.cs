using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Effects
{
    public interface ISaveProficiencyEffect : IEffect
    {
        ProficencyModifierType GetSaveModifier(ProficencyModifierType baseSaveModifier);
    }
}
