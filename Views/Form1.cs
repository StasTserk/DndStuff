using DnD5thEdTools.Controllers;
using System;
using System.Linq;
using System.Windows.Forms;
using Providers;
using DnD5thEdTools.Models;

namespace DnD5thEdTools.Views
{
    public partial class Form1 : Form
    {
        private readonly ISpellListController _spellsController;
        private readonly ISimpleSpellListView _simpleSpellGridView;
        private readonly ISpellDetailProvider _spellDetailFormatProvider;
        private readonly IRtfProvider _formatProvider;

        public Form1(ISpellListController controller, ISimpleSpellListView spellListView,
            ISpellDetailProvider detailProvider, IRtfProvider formatProvider)
        {
            _spellsController = controller;
            _simpleSpellGridView = spellListView;
            _spellDetailFormatProvider = detailProvider;
            _formatProvider = formatProvider;
            
            InitializeComponent();
            InitializeSpellGrid();

            InitializeYesNoDropdown("Concentration", Filter_ConcentrationDropdown);
            InitializeYesNoDropdown("Has Save", Filter_HasSaveDropdown);
            InitializeYesNoDropdown("Attack Roll", Filter_RequiresAttackDropdown);
            InitializeYesNoDropdown("Ritual", Filter_RitualDropdown);

            InitializeMultiOptionMenus();
        }

        private void InitializeMultiOptionMenus()
        {
            Filter_CastingTimeDropdown.Items.Add("Casting Time");
            Filter_CastingTimeDropdown.SelectedItem = "Casting Time";
            Filter_CastingTimeDropdown.Items.AddRange(
                _spellsController.GetUnfilteredSpells().Select(s => s.CastingTime).Distinct().ToArray()
                );

            Filter_ClassDropdown.Items.Add("Class");
            Filter_ClassDropdown.SelectedItem = "Class";
            Filter_ClassDropdown.Items.AddRange(
                _spellsController.GetClassList().ToArray()
                );
        }

        private void InitializeYesNoDropdown(string defaultOption, ComboBox dropdown)
        {
            dropdown.Items.Add(defaultOption);
            dropdown.Items.Add("Yes");
            dropdown.Items.Add("No");
            dropdown.SelectedItem = defaultOption;
        }

        private void InitializeSpellGrid()
        {
            _simpleSpellGridView.SetColumns(ListOfSpells.Columns);
        }

        private void loadSpellsButton_Click(object sender, EventArgs e)
        {
            _spellsController.AddFilterCriteria("default", s => s.Duration == s.Duration);
            ResetSpells();
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

        private void ResetSpells()
        {
            var spells = _spellsController.GetFilteredSpells();

            ListOfSpells.Items.Clear();
            foreach (var spell in spells)
            {
                ListOfSpells.Items.Add(_simpleSpellGridView.ConvertToColumnRecord(spell));
            }
        }

        private void Filter_ConcentrationDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessYesNoDropdown(Filter_ConcentrationDropdown, "conc", s => s.Concentration);
        }

        private void Filter_HasSaveDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessYesNoDropdown(Filter_HasSaveDropdown, "save", s => s.Save != "None");
        }

        private void Filter_RequiresAttackDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessYesNoDropdown(Filter_RequiresAttackDropdown, "attack", s => s.RequiresAttackRoll);
        }
        private void Filter_RitualDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessYesNoDropdown(Filter_RitualDropdown, "ritual", s => s.Ritual );
        }

        private void ProcessYesNoDropdown(ComboBox dropdown, string filterName, Func<Spell, bool> criteria)
        {
            switch (dropdown.SelectedItem.ToString())
            {
                case "Yes":
                    _spellsController.AddFilterCriteria(filterName, criteria );
                    break;
                case "No":
                    _spellsController.AddFilterCriteria(filterName, s => !criteria(s));
                    break;
                default:
                    _spellsController.RemoveFilterCriteria(filterName);
                    break;
            }
            ResetSpells();
        }

        private void Filter_CastingTimeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filter_CastingTimeDropdown.SelectedItem == "Casting Time")
            {
                _spellsController.RemoveFilterCriteria("castTime");
            }
            else
            {
                _spellsController.AddFilterCriteria("castTime",
                    s => s.CastingTime == Filter_CastingTimeDropdown.SelectedItem.ToString()
                    );
            }
            ResetSpells();
        }

        private void Filter_ClassDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filter_ClassDropdown.SelectedItem == "Class")
            {
                _spellsController.RemoveFilterCriteria("class");
            }
            else
            {
                _spellsController.AddFilterCriteria("class",
                    s => s.Classes.FirstOrDefault(c => c.Contains(Filter_ClassDropdown.SelectedItem.ToString())) != null
                    );
            }
            ResetSpells();
        }
    }
}
