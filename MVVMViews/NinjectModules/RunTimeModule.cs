using DnD5thEdTools.Repositories;
using Ninject.Modules;

namespace MVVMViews.NinjectModules
{
    class RunTimeModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<ISpellLoader>().To<SpellLoader>();
        }
    }
}
