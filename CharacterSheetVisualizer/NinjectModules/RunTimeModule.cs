using Data.EffectParser;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Ninject.Modules;
using Services.Controllers;
using Services.Controllers.Interfaces;

namespace CharacterSheetVisualizer.NinjectModules
{
    class RunTimeModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IClassController>().To<ClassController>().InSingletonScope();
            Bind<IClassLoader>().To<ClassLoader>().InSingletonScope();
            Bind<IEffectParser>().To<XmlToEffectParser>();
        }
    }
}
