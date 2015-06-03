using System.Windows.Forms;
using Data.Models;

namespace DnD5thEdTools.Views.Interfaces
{
    public interface ISimpleSpellListView
    {
        void SetColumns(ListView.ColumnHeaderCollection columns);
        ListViewItem ConvertToColumnRecord(Spell spell);
    }
}
