using System.Linq;

namespace Data.Models.Effects
{
    /// <summary>
    /// Implementation for a stat effect that grants a flat bonus to a stat.
    /// </summary>
    public class BonusStatEffect : IStatEffect
    {
        private readonly StatType _type;
        private readonly int _bonus;

        public BonusStatEffect(StatType type, int bonus)
        {
            _type = type;
            _bonus = bonus;
        }

        /// <summary>
        /// Inserts at the start of the character's StatEffects collection.
        /// Since it is important to apply the bonus before any items that raise a score to a minimum, this is added to the start.
        /// </summary>
        /// <param name="targetCharacter">Player stat effect must be added to.</param>
        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.Stats.First(s => s.Type == _type).StatEffects.Insert(0, this);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.Stats.First(s => s.Type == _type).StatEffects.Remove(this);
        }

        public int GetAffectedStatScore(int statScore)
        {
            return statScore + _bonus;
        }
    }
}
