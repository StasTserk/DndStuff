using System;
using System.Collections.Generic;
using Data.Models;
using DnD5thEdTools.Views.Interfaces;

namespace DnD5thEdTools.Views
{
    class SpellDetailView : ISpellDetailView
    {
        public string GetSpellDetailText(Spell spell)
        {
            return spell.Description;
        }

        public string GetBasicSpellText(Spell spell)
        {
            String levelComposition = "";
            foreach (var cls in spell.Classes)
            {
                levelComposition += " " + cls;
            }
            return String.Format("*Name*: {0}\n\n" +
                              "*School*: {1} \n\n" +
                              "*Level*: {2} \n\n" +
                              "*Casting Time*: {3}\n\n" +
                              "*Components*: {4}\n\n" +
                              "*Duration*: {5}\n\n" +
                              "*Concentration*: {6}\n\n" +
                              "*Range*: {7}\n\n" +
                              "*Targets*: {8}",
                spell.Name, spell.School, levelComposition, spell.CastingTime, spell.Components,
                spell.Duration, spell.Concentration, spell.Range, spell.Targets);
        }
    }
}
