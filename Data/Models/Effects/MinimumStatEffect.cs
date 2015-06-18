using System.Linq;

namespace Data.Models.Effects
{
    public class MinimumStatEffect : IStatEffect
    {
        private readonly StatType _type;
        private readonly int _statMinimum;

        public MinimumStatEffect(StatType type, int statMinimum)
        {
            _type = type;
            _statMinimum = statMinimum;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.Stats.First(s => s.Type == _type).AddEffectLast(this);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.Stats.First(s => s.Type == _type).RemoveEffect(this);
        }

        public int GetAffectedStatScore(int statScore)
        {
            return statScore > _statMinimum ? statScore : _statMinimum;
        }

        public StatType Type
        {
            get { return _type; }
        }
    }
}
