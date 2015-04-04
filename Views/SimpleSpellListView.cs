using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD5thEdTools.Views
{
    class SimpleSpellListView : ISimpleSpellListView
    {
        public void setColumns(ListView.ColumnHeaderCollection columns)
        {
            columns.Add("Name", 150, HorizontalAlignment.Left);
            columns.Add("School", 100, HorizontalAlignment.Left);
            columns.Add("Level", -2, HorizontalAlignment.Left);
            columns.Add("Description", -2, HorizontalAlignment.Left);
        }

        public ListViewItem convertToColumnRecord(Spell spell)
        {
            return new ListViewItem(
                new[] 
                {
                    spell.Name,
                    spell.School,
                    spell.Level.ToString(),
                    spell.ShortDescription
                }
                );
        }
    }
}
