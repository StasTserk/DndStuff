namespace Data.Models.Effects
{
    /// <summary>
    /// Represents a general effect that can be applied to a player causing a change to their character.
    /// </summary>
    public interface IEffect
    {
        void ApplyToCharacter(Character targetCharacter);
        void RemoveFromCharacter(Character targetCharacter);
    }
}
