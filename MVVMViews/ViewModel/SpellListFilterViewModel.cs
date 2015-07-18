using System.Collections.Generic;
using System.ComponentModel.Design;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVMViews.Messages;
using Services;

namespace MVVMViews.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SpellListFilterViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IFilterService _filterService;

        private BoolFilterState _selectedConcentration;
        public BoolFilterState SelectedConcentration
        {
            get { return _selectedConcentration; }
            set
            {
                if (value == _selectedConcentration)
                {
                    return;
                }

                _selectedConcentration = value;

                var message = new FilterAppliedMessage()
                {
                    Type = FilterType.Concentration,
                    FilterFunction = _filterService.GetFilterForConcentration(_selectedConcentration)
                };

                _messenger.Send(message);

                RaisePropertyChanged(() => SelectedConcentration);
            }
        }

        public IEnumerable<BoolFilterState> Concentration
        {
            get
            {
                return new List<BoolFilterState>
                {
                    BoolFilterState.Disabled,
                    BoolFilterState.No,
                    BoolFilterState.Yes
                };
            }
        }

        /// <summary>
        /// Initializes a new instance of the SpellListFilterViewModel class.
        /// </summary>
        public SpellListFilterViewModel(IMessenger messeneger, IFilterService filterService)
        {
            _messenger = messeneger;
            _filterService = filterService;

            SelectedConcentration = BoolFilterState.Disabled;
        }
    }
}