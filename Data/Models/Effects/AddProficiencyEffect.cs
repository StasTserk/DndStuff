using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Effects
{
    public class AddProficiencyEffect : IOtherProficencyEffect
    {
        private readonly Proficiency _proficiency;

        public AddProficiencyEffect(Proficiency proficiency)
        {
            _proficiency = proficiency;
        }


        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.AddProficiencyEffect(this);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.RemoveProficiencyEffect(this);
        }

        public IList<Proficiency> GetProficencyList(IList<Proficiency> list)
        {
            if (!list.Contains(_proficiency))
            {
                list.Add(_proficiency);
            }
            return list;
        }
    }
}
