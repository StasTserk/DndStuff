using System;
using DnD5thEdTools.Models;
using DnD5thEdTools.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVMViews.Messages;
using Providers;

namespace MVVMViews.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SpellDetailViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IRtfProvider _provider;
        private readonly ISpellDetailProvider _detailProvider;

        private Spell _selectedSpell;
        private Spell SelectedSpell
        {
            set
            {
                _selectedSpell = value;
            }
        }

        private string _basicSpellText;
        public string BasicSpellText
        {
            get { return _provider.GetRtfFromString(_basicSpellText, 9); }
            private set
            {
                _basicSpellText = value;
                RaisePropertyChanged(() => BasicSpellText);
            }
        }

        private string _spellDescription;
        public string SpellDescriptionText
        {
            get { return _provider.GetRtfFromString(_spellDescription, 9); }
            private set
            {
                _spellDescription = value;
                RaisePropertyChanged(() => SpellDescriptionText);
            }
        }

        /// <summary>
        /// Initializes a new instance of the SpellDetailViewModel class.
        /// </summary>
        public SpellDetailViewModel(IMessenger messenger, IRtfProvider rtfProvider, ISpellDetailProvider detailProvider)
        {
            _basicSpellText = String.Empty;
            _spellDescription = String.Empty;
            _provider = rtfProvider;
            _messenger = messenger;
            _detailProvider = detailProvider;

            _messenger.Register<SpellSelectedMessage>(this, message =>
                {
                    SelectedSpell = message.SelectedSpell;
                    SpellDescriptionText = (_selectedSpell != null) ? _selectedSpell.Description : "";
                    BasicSpellText = _detailProvider.GetBasicSpellText((message.SelectedSpell));
                });
        }
    }
}