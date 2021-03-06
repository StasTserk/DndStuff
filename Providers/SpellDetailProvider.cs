﻿using System.Linq;

namespace DnD5thEdTools.Views
{
    public class SpellDetailProvider : ISpellDetailProvider
    {
        public string GetSpellDetailText(Models.Spell spell)
        {
            return spell.Description;
        }

        public string GetBasicSpellText(Models.Spell spell)
        {
            if (spell == null)
            {
                return string.Empty;
            }

            string levelComposition = spell.Classes.Aggregate("", (current, cls) => current + (" " + cls));
            return string.Format("*Name*: {0}\n\n" +
                              "*School*: {1}" +
                              "*Level*: {2} \n\n" +
                              "*Casting Time*: {3}\n\n" +
                              "*Components*: {4}\n\n" +
                              "*Duration*: {5}\n\n" +
                              "*Concentration*: {6}\n\n" +
                              "*Range*: {7}\n\n" +
                              "*Targets*: {8} \n\n" +
                              "*Save*: {9} \n\n" +
                              "*Requires Attack*: {10}\n\n",
                spell.Name, 
                spell.School + (spell.Ritual ? " (Ritual)\n\n":"\n\n"), levelComposition, spell.CastingTime, spell.Components,
                spell.Duration, spell.Concentration, spell.Range, spell.Targets, spell.Save, 
                spell.RequiresAttackRoll);
        }
    }
}
