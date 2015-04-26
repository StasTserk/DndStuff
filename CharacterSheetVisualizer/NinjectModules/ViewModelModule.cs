using CharacterSheetVisualizer.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using Ninject.Modules;

namespace CharacterSheetVisualizer.NinjectModules
{
    class ViewModelModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IMessenger>().To<Messenger>().InSingletonScope();

            Bind<MainViewModel>().To<MainViewModel>().InSingletonScope();
        }
    }
}
