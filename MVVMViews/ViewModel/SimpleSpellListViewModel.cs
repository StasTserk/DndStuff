using System.Collections.ObjectModel;
using System.Linq;
using DnD5thEdTools.Controllers;
using DnD5thEdTools.Models;
using DnD5thEdTools.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MVVMViews.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SimpleSpellListViewModel : ViewModelBase
    {
        private readonly ISpellListController _controller;

        private Spell _selectedSpell;
        public Spell SelectedSpell
        {
            get
            {
                return _selectedSpell; 
            }
            set
            {
                _selectedSpell = value;
                RaisePropertyChanged(() => SelectedSpell);
            }
        }

        private ObservableCollection<Spell> _spells;
        public ObservableCollection<Spell> Spells 
        {
            get
            {
                return _spells;
            }
            private set
            {
                _spells = value;
                RaisePropertyChanged(() => Spells);
            }
        }

        /// <summary>
        /// Initializes a new instance of the SimpleSpellListViewModel class.
        /// </summary>
        public SimpleSpellListViewModel(ISpellListController controller)
        {
            _controller = controller;
            Spells = new ObservableCollection<Spell>(_controller.GetUnfilteredSpells());
        }
    }
}