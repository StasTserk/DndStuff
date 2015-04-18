using MVVMViews.ViewModel;
using Ninject.Modules;

namespace MVVMViews.NinjectModules
{
    class ViewModelModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<MainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<SimpleSpellListViewModel>().To<SimpleSpellListViewModel>().InSingletonScope();
        }
    }
}
