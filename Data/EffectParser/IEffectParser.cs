using System.Collections.Generic;
using System.Xml.Linq;
using Data.Models.Effects;

namespace Data.EffectParser
{
    public interface IEffectParser
    {
        IEnumerable<IEffect> GetEffectsFromXml(XElement element);
    }
}
