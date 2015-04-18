using DnD5thEdTools.Repositories;
using MVVMViews.Design;
using Ninject.Modules;

namespace MVVMViews.NinjectModules
{
    public class DesignTimeModules
        : NinjectModule
    {
        public override void Load()
        {
            Bind<ISpellLoader>().To<DesignSpellLoader>().InSingletonScope();
        }
    }
}
