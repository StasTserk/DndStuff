using System.Collections.Generic;

namespace Data.Models.Effects
{
    public interface IOtherProficencyEffect : IEffect
    {
        IList<Proficiency> GetProficencyList(IList<Proficiency> list);
    }
}
