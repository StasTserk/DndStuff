/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MVVMViews"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System.Windows.Data;
using GalaSoft.MvvmLight;
using MVVMViews.NinjectModules;
using Ninject;

namespace MVVMViews.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private readonly StandardKernel _kernel;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            _kernel = new StandardKernel();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                _kernel.Load(new DesignTimeModule());
            }
            else
            {
                // Create run time view services and models
                _kernel.Load(new RunTimeModule());
            }

            _kernel.Load(new ViewModelModule());
        }

        public MainViewModel Main
        {
            get
            {
                return _kernel.Get<MainViewModel>();
            }
        }

        public SimpleSpellListViewModel SimpleSpellList
        {
            get { return _kernel.Get<SimpleSpellListViewModel>(); }
        }

        public SpellDetailViewModel SpellDetail
        {
            get { return _kernel.Get<SpellDetailViewModel>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}