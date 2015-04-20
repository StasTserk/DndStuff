using DnD5thEdTools.Controllers;
using DnD5thEdTools.Repositories;
using MVVMViews.Design;
using Ninject.Modules;

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
