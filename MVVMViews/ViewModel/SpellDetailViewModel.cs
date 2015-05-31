using System;
using Data.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVMViews.Messages;
using Providers;
using Providers.FormatProviders;

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
        public SpellDetailViewModel(IMessenger messenger, IRtfProvider rtfProvider)
        {
            _basicSpellText = String.Empty;
            _spellDescription = String.Empty;
            _provider = rtfProvider;
            _messenger = messenger;
            _messenger.Register<SpellSelectedMessage>(this, message =>
                {
                    SelectedSpell = message.SelectedSpell;

                    SpellDescriptionText = _selectedSpell.Description;
                    BasicSpellText = string.Format("*Name*: {0}\n\n" +
                                      "*School*: Level {1} {2}\n\n" +
                                      "*Casting Time*: {3}\n\n" +
                                      "*Components*: {4}\n\n" +
                                      "*Duration*: {5}\n\n" +
                                      "*Concentration*: {6}\n\n" +
                                      "*Range*: {7}\n\n" +
                                      "*Targets*: {8}",
                        _selectedSpell.Name, _selectedSpell.Level, _selectedSpell.School, _selectedSpell.CastingTime, _selectedSpell.Components,
                        _selectedSpell.Duration, _selectedSpell.Concentration, _selectedSpell.Range, _selectedSpell.Targets);
                });
        }
    }
}