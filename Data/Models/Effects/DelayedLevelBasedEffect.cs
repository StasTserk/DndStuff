using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Effects
{
    class DelayedLevelBasedEffect : IEffect
    {
        private readonly IDictionary<int, IEnumerable<IEffect>> _effectsByLevel;
        private Character _character;
        private int _lastLevelApplied;

        public DelayedLevelBasedEffect(IDictionary<int, IEnumerable<IEffect>> effectsByLevel)
        {
            _effectsByLevel = effectsByLevel;
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            targetCharacter.LevelModifiers.PropertyChanged += TargetCharacterOnPropertyChanged;

            // if the character already should have a few effects we should apply those
            for (int i = 1; i <= targetCharacter.LevelModifiers.Level; i ++)
            {
                ApplyEffectsByLevel(i);
                _lastLevelApplied = i;
            }

            _character = targetCharacter;
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            throw new NotImplementedException();
        }

        #region Helper Methods
        private void TargetCharacterOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "Level")
            {
                TryApplyEffects();
            }
        }

        private void ApplyEffectsByLevel(int level)
        {
            foreach (var effect in _effectsByLevel.First(e => e.Key == level).Value)
            {
                effect.ApplyToCharacter(_character);
            }
        }

        private void TryApplyEffects()
        {
            if (!_effectsByLevel.ContainsKey(_character.LevelModifiers.Level) ||
                _character.LevelModifiers.Level <= _lastLevelApplied)
            {
                return;
            }

            ApplyEffectsByLevel(_character.LevelModifiers.Level);

            _lastLevelApplied = _character.LevelModifiers.Level;
        }
        #endregion
    }
}
