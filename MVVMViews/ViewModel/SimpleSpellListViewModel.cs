using System.Collections.ObjectModel;
using System.Linq;
using DnD5thEdTools.Controllers;
using DnD5thEdTools.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVMViews.Messages;
using Ninject;

namespace MVVMViews.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SimpleSpellListViewModel 
        : ViewModelBase
        , IInitializable
    {
        private readonly IMessenger _messenger;
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

                // Send a Message indicating that a Spell has been selected
                _messenger.Send(new SpellSelectedMessage{SelectedSpell = _selectedSpell});
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
        public SimpleSpellListViewModel(ISpellListController controller, IMessenger messenger)
        {
            _controller = controller;
            _messenger = messenger;

            _messenger.Register<FilterAppliedMessage>(this, message =>
            {
                _controller.AddFilterCriteria(message.Type.ToString(), message.FilterFunction);
                Spells = new ObservableCollection<Spell>(_controller.GetFilteredSpells());
            });
        }

        public void Initialize()
        {
            Spells = new ObservableCollection<Spell>(_controller.GetUnfilteredSpells());
        }
    }
}