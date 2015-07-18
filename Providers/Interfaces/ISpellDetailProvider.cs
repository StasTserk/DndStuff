using DnD5thEdTools.Models;
using System;

namespace DnD5thEdTools.Views
{
    public interface ISpellDetailProvider
    {
        String GetSpellDetailText(Spell spell);
        String GetBasicSpellText(Spell spell);
    }
}
