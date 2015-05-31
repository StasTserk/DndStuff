using Data.Repositories.Interfaces;
using MVVMViews.Design;
using Ninject.Modules;
using Services.Controllers;
using Services.Controllers.Interfaces;

namespace MVVMViews.NinjectModules
{
    public class DesignTimeModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<ISpellLoader>().To<DesignSpellLoader>().InSingletonScope();
            Bind<ISpellListController>().To<SpellListController>().InSingletonScope();
        }
    }
}
