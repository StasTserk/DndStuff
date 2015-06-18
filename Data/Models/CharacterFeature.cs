using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CharacterFeature
    {
        private readonly string _name;
        private readonly string _description;
        private readonly string _shortDescription;
        private readonly string _source;

        public CharacterFeature(string name, string description, string shortDescription, string source)
        {
            _name = name;
            _description = description;
            _shortDescription = shortDescription;
            _source = source;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string ShortDescription
        {
            get { return _shortDescription; }
        }

        public string Source
        {
            get { return _source; }
        }
    }
}
