using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5thEdTools.Views
{
    class SpellDetailView : ISpellDetailView
    {
        public string getSpellDetailText(Models.Spell spell)
        {
            return spell.Description;//.Replace(System.Environment.NewLine, "");
        }

        public string getBasicSpellText(Models.Spell spell)
        {
            return
                String.Format("Name: {0}\nSchool: Level {1} {2}\nCasting Time: {3}\nComponents: {4}\nDuration: {5}\nConcentration: {6}\nRange: {7}\nTargets: {8}",
                spell.Name, spell.Level, spell.School, spell.CastingTime, spell.Components,
                spell.Duration, spell.Concentration, spell.Range, spell.Targets);
        }
    }
}
