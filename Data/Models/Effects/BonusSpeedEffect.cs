namespace Data.Models.Effects
{
    public class BonusSpeedEffect : ISpeedEffect
    {
        private readonly int _speedBonus;

        public BonusSpeedEffect(int speedBonus)
        {
            _speedBonus = speedBonus;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.AddSpeedEffect(this);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            targetCharacter.RemoveSpeedEffect(this);
        }

        public int GetSpeed(int speed)
        {
            return speed + _speedBonus; 
        }
    }
}
