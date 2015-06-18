namespace Data.Models.Effects
{
    public interface ISkillProficiencyEffect : IEffect
    {
        ProficencyModifierType GetModifiedProficiency(ProficencyModifierType type);
    }
}
