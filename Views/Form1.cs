using DnD5thEdTools.Controllers;
using System;
using System.Windows.Forms;
using Providers;

namespace DnD5thEdTools.Views
{
    public partial class Form1 : Form
    {
        private readonly ISpellListController _spellsController;
        private readonly ISimpleSpellListView _simpleSpellGridView;
        private readonly ISpellDetailView _spellDetailFormatProvider;
        private readonly IRtfProvider _formatProvider;

        public Form1(ISpellListController controller, ISimpleSpellListView spellListView,
            ISpellDetailView detailView, IRtfProvider formatProvider)
        {
            _spellsController = controller;
            _simpleSpellGridView = spellListView;
            _spellDetailFormatProvider = detailView;
            _formatProvider = formatProvider;
            InitializeComponent();
            InitializeSpellGrid();
        }

        private void InitializeSpellGrid()
        {
            _simpleSpellGridView.SetColumns(ListOfSpells.Columns);
        }

        private void loadSpellsButton_Click(object sender, EventArgs e)
        {
            var spells = _spellsController.GetFilteredSpells(s => true);

            ListOfSpells.Items.Clear();
            foreach (var spell in spells)
	        {
                ListOfSpells.Items.Add(_simpleSpellGridView.ConvertToColumnRecord(spell));
            }
        }

        private void ListOfSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfSpells.SelectedItems.Count == 0) return;

            var selectedSpell = _spellsController.GetSpellByName(ListOfSpells.SelectedItems[0].Text);

            SpellDescriptionTextBox.Rtf = _formatProvider.GetRtfFromString(
                _spellDetailFormatProvider.GetSpellDetailText(selectedSpell));

            BasicSpellDetailsTextBox.Rtf = _formatProvider.GetRtfFromString(
                _spellDetailFormatProvider.GetBasicSpellText(selectedSpell));
        }
    }
}
