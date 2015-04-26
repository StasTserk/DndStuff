/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:CharacterSheetVisualizer.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System;
using GalaSoft.MvvmLight;
using CharacterSheetVisualizer.NinjectModules;
using Ninject;

namespace CharacterSheetVisualizer.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
        : IDisposable
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
            get { return _kernel.Get<MainViewModel>(); }
        }

        public BaseCharacterStatsViewModel BaseCharacterStats
        {
            get { return _kernel.Get<BaseCharacterStatsViewModel>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        public void Dispose()
        {
            ((IDisposable) _kernel).Dispose();
        }
    }
}