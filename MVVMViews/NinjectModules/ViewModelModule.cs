using GalaSoft.MvvmLight.Messaging;
using MVVMViews.ViewModel;
using Ninject.Modules;
using Providers;
using Xceed.Wpf.Toolkit;

namespace MVVMViews.NinjectModules
{
    class ViewModelModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IMessenger>().To<Messenger>().InSingletonScope();

            Bind<IRtfProvider>().To<MarkdownToAnsiRtfProvider>().InSingletonScope();
            Bind<MainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<SimpleSpellListViewModel>().To<SimpleSpellListViewModel>().InSingletonScope();
        }
    }
}
