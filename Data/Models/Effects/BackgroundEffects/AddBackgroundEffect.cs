using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models.Choices;
using Data.Models.Effects.ChoiceEffects;

namespace Data.Models.Effects.BackgroundEffects
{
    class AddBackgroundEffect : IEffect
    {
        private readonly Background _background;
        private IChoiceEffect _personalityTraitsChoice;
        private IChoiceEffect _bondsChoice;
        private IChoiceEffect _flawsChoice;
        private IChoiceEffect _idealsChoice;

        public AddBackgroundEffect(Background background)
        {
            _background = background;

            ConstructChoices();
        }

        private void ConstructChoices()
        {
            IChoice personalityTraitsChoice = ConstructChoice(_background.PersonalityTraits.Select( pt =>
                new ChoiceOption(
                    name: "Personality trait",
                    description: pt,
                    shortDescription: pt,
                    effect: new AddPersonalityTraitEffect(pt))));
            personalityTraitsChoice.Name = "Personality Trait";
            personalityTraitsChoice.Description = "A defining trait of your character's personality";
            personalityTraitsChoice.ShortDescription = "You character's personality trait";

            IChoice bondsChoice = ConstructChoice(_background.PersonalityTraits.Select(b =>
                new ChoiceOption(
                    name: "Character Bond",
                    description: b,
                    shortDescription: b,
                    effect: new AddBondsEffect(b))));
            bondsChoice.Name = "Character Bonds";
            bondsChoice.Description = "A bond that ties your character to the world around you";
            bondsChoice.ShortDescription = "A bond to the land";

            IChoice flawsChoice = ConstructChoice(_background.PersonalityTraits.Select(f =>
                new ChoiceOption(
                    name: "Personality Flaw",
                    description: f,
                    shortDescription: f,
                    effect: new AddFlawsEffect(f))));
            flawsChoice.Name = "Character Flaws";
            flawsChoice.Description = "A personality flaw in your character";
            flawsChoice.ShortDescription = "A character flaw";

            IChoice idealsChoice = ConstructChoice(_background.PersonalityTraits.Select(i =>
                new ChoiceOption(
                    name: "Character Ideals",
                    description: i,
                    shortDescription: i,
                    effect: new AddIdealsEffect(i))));
            idealsChoice.Name = "Character Ideals";
            idealsChoice.Description = "An idea or thought that your character values above all.";
            idealsChoice.ShortDescription = "Your character's Ideals";

            _personalityTraitsChoice = new ChoiceEffect(personalityTraitsChoice);
            _bondsChoice = new ChoiceEffect(bondsChoice);
            _flawsChoice = new ChoiceEffect(flawsChoice);
            _idealsChoice = new ChoiceEffect(idealsChoice);
        }

        private IChoice ConstructChoice(IEnumerable<ChoiceOption> @select)
        {
            return new ExclusiveEffectChoice(select);
        }

        public void ApplyToCharacter(Character targetCharacter)
        {
            foreach (var effect in _background.Effects)
            {
                effect.ApplyToCharacter(targetCharacter);
            }

            targetCharacter.Background = _background;
            _personalityTraitsChoice.ApplyToCharacter(targetCharacter);
            _bondsChoice.ApplyToCharacter(targetCharacter);
            _flawsChoice.ApplyToCharacter(targetCharacter);
            _idealsChoice.ApplyToCharacter(targetCharacter);
        }

        public void RemoveFromCharacter(Character targetCharacter)
        {
            foreach (var effect in _background.Effects)
            {
                effect.RemoveFromCharacter(targetCharacter);
            }

            targetCharacter.Background = null;
            _personalityTraitsChoice.RemoveFromCharacter(targetCharacter);
            _bondsChoice.RemoveFromCharacter(targetCharacter);
            _flawsChoice.RemoveFromCharacter(targetCharacter);
            _idealsChoice.RemoveFromCharacter(targetCharacter);
        }
    }
}
