namespace Data.Models.Effects
{
    /// <summary>
    /// An effect that can be applied to a player that modifies their stats
    /// </summary>
    public interface IStatEffect : IEffect
    {
        int GetAffectedStatScore(int statScore);
        StatType Type { get; }
    }
}
