using System.Collections.Generic;
using System.Xml.Linq;
using Data.Models.Effects;
using Data.Models.Effects.ChoiceEffects;

namespace Data.EffectParser
{
    public interface IEffectParser
    {
        IEnumerable<IEffect> GetEffectsFromXml(XElement element);

        IEnumerable<ClassCustomizationChoiceEffect> GetOutstandingCustomizationChoices();

        void ClearOutstandingChoices();
    }
}
