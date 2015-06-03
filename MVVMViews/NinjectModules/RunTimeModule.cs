using Data.Repositories;
using Data.Repositories.Interfaces;
using Ninject.Modules;
using Services.Controllers;
using Services.Controllers.Interfaces;

namespace MVVMViews.NinjectModules
{
    class RunTimeModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<ISpellLoader>().To<SpellLoader>();
            Bind<ISpellListController>().To<SpellListController>().InSingletonScope();
        }
    }
}
