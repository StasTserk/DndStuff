using DnD5thEdTools.Models;
using System.Windows.Forms;

namespace DnD5thEdTools.Views
{
    public interface ISimpleSpellListView
    {
        void SetColumns(ListView.ColumnHeaderCollection columns);
        ListViewItem ConvertToColumnRecord(Spell spell);
    }
}
