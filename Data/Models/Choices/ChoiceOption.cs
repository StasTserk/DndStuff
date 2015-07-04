using System.Collections.Generic;
using Data.Models.Effects;
using GalaSoft.MvvmLight;

namespace Data.Models.Choices
{
    public class ChoiceOption : IChoiceOption
    {
        private readonly string _name;
        private readonly string _description;
        private readonly string _shortDescription;
        private readonly IEnumerable<IEffect> _effects;

        public ChoiceOption(string name, string description, string shortDescription, IEnumerable<IEffect> effects)
        {
            _name = name;
            _description = description;
            _shortDescription = shortDescription;
            _effects = effects;
        }

        public ChoiceOption(string name, string description, string shortDescription, IEffect effect) :
                this(name, 
                    description, 
                    shortDescription, 
                    new List<IEffect> { effect }) 
        {}

        public string Name { get { return _name; } }
        public string Description { get {return _description; } }
        public string ShortDescription { get { return _shortDescription; } }
        public IEnumerable<IEffect> ChoiceEffects { get { return _effects; } }
    }
}
