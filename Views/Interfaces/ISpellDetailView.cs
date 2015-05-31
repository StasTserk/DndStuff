using System;
using Data.Models;

namespace DnD5thEdTools.Views.Interfaces
{
    public interface ISpellDetailView
    {
        String GetSpellDetailText(Spell spell);
        String GetBasicSpellText(Spell spell);
    }
}
