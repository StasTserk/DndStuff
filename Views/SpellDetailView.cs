﻿using System;

namespace DnD5thEdTools.Views
{
    class SpellDetailView : ISpellDetailView
    {
        public string GetSpellDetailText(Models.Spell spell)
        {
            return spell.Description;
        }

        public string GetBasicSpellText(Models.Spell spell)
        {
            return
                String.Format("*Name*: {0}\n\n" +
                              "*School*: Level {1} {2}\n\n" +
                              "*Casting Time*: {3}\n\n" +
                              "*Components*: {4}\n\n" +
                              "*Duration*: {5}\n\n" +
                              "*Concentration*: {6}\n\n" +
                              "*Range*: {7}\n\n" +
                              "*Targets*: {8}",
                spell.Name, spell.Level, spell.School, spell.CastingTime, spell.Components,
                spell.Duration, spell.Concentration, spell.Range, spell.Targets);
        }
    }
}
