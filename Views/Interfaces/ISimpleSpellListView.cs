using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD5thEdTools.Views
{
    public interface ISimpleSpellListView
    {
        void setColumns(ListView.ColumnHeaderCollection columns);
        ListViewItem convertToColumnRecord(Spell spell);
    }
}
