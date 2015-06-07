using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Effects
{
    public interface IFeatureEffect : IEffect
    {
        IList<CharacterFeature> GetFeatureList(IList<CharacterFeature> featureList);
    }
}
