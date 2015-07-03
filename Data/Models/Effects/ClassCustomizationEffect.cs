using System.Linq;

namespace Data.Models.Effects
{
    // TODO add specialized interface for this
    class ClassCustomizationEffect : IEffect
    {
        private readonly ClassCustomization _classCustomization;

        public ClassCustomizationEffect(ClassCustomization classCustomization)
        {
            _classCustomization = classCustomization;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.ClassCustomization = _classCustomization;
            _classCustomization.LevelEffects.OrderBy(l => l.Level)
                .First().ApplyToCharacter(targetCharacter);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            if (targetCharacter.ClassCustomization == _classCustomization)
            {
                targetCharacter.ClassCustomization = null;
            }
        }
    }
}
