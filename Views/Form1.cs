using DnD5thEdTools.Controllers;
using DnD5thEdTools.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD5thEdTools.Views
{
    public partial class Form1 : Form
    {
        private ISpellListController _spellsController;
        private ISimpleSpellListView _simpleSpellGridView;
        private ISpellDetailView _spellDetailFormatProvider;

        public Form1(ISpellListController controller, ISimpleSpellListView SpellListView, ISpellDetailView detailView)
        {
            _spellsController = controller;
            _simpleSpellGridView = SpellListView;
            _spellDetailFormatProvider = detailView;
            InitializeComponent();
            InitializeSpellGrid();
        }

        private void InitializeSpellGrid()
        {
            _simpleSpellGridView.setColumns(ListOfSpells.Columns);
        }

        private void loadSpellsButton_Click(object sender, EventArgs e)
        {
            List<Spell> spells = _spellsController.GetFilteredSpells(s => true).ToList();
            ListOfSpells.Items.Clear();
            foreach (var spell in spells)
	        {
                ListOfSpells.Items.Add(_simpleSpellGridView.convertToColumnRecord(spell));
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ListOfSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfSpells.SelectedItems.Count != 0)
            {
                Spell selectedSpell = _spellsController.GetSpellByName(ListOfSpells.SelectedItems[0].Text);

                SpellDescriptionTextBox.Text = _spellDetailFormatProvider.getSpellDetailText(selectedSpell);
                BasicSpellDetailsTextBox.Text = _spellDetailFormatProvider.getBasicSpellText(selectedSpell);
            }

        }
    }
}
