using System.Collections.ObjectModel;
using DnD5thEdTools.Models;
using DnD5thEdTools.Repositories;
using GalaSoft.MvvmLight;

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
        private readonly ISpellLoader _loader;

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
        public SimpleSpellListViewModel(ISpellLoader loader)
        {
            _loader = loader;
            Spells = new ObservableCollection<Spell>(_loader.GetSpells());
        }
    }
}