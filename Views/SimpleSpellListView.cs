using System.Windows.Forms;
using Data.Models;
using DnD5thEdTools.Views.Interfaces;

namespace DnD5thEdTools.Views
{
    class SimpleSpellListView : ISimpleSpellListView
    {
        public void SetColumns(ListView.ColumnHeaderCollection columns)
        {
            columns.Add("Name", 150, HorizontalAlignment.Left);
            columns.Add("School", 100, HorizontalAlignment.Left);
            columns.Add("Level", -2, HorizontalAlignment.Left);
            columns.Add("Description", -2, HorizontalAlignment.Left);
        }

        public ListViewItem ConvertToColumnRecord(Spell spell)
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
