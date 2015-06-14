using System.Collections.Generic;
using Data.Models.Effects;

namespace Data.Models
{
    public class Background
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> PersonalityTraits { get; set; }
        public IEnumerable<string> Ideals { get; set; }
        public IEnumerable<string> Bonds { get; set; }
        public IEnumerable<string> Flaws { get; set; }
        public IEnumerable<IEffect> Effects { get; set; }
    }
}
