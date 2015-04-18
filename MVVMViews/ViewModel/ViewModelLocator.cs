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
        public StandardKernel _kernel;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            _kernel = new StandardKernel();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                _kernel.Load(new DesignTimeModules());
            }
            else
            {
                // Create run time view services and models
                _kernel.Load(new RunTimeModule());
            }
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

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}