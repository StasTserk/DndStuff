using System;
using System.Collections.Generic;

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
            String levelComposition = "";
            foreach (var cls in spell.Classes)
            {
                levelComposition += " " + cls;
            }
            return String.Format("*Name*: {0}\n\n" +
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
