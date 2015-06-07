namespace Data.Models.Effects
{
    public interface ISkillEffect : IEffect
    {
        int GetAffectedSkillScore(int skillScore);
    }
}
