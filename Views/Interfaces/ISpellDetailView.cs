using DnD5thEdTools.Models;
using System;

namespace DnD5thEdTools.Views
{
    public interface ISpellDetailView
    {
        String GetSpellDetailText(Spell spell);
        String GetBasicSpellText(Spell spell);
    }
}
