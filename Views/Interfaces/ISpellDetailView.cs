using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5thEdTools.Views
{
    public interface ISpellDetailView
    {
        String getSpellDetailText(Spell spell);
        String getBasicSpellText(Spell spell);
    }
}
