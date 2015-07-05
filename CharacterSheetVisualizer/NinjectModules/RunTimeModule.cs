using Data.EffectParser;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Ninject.Modules;
using Providers.CharacterProviders;
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
            Bind<IRaceProvider>().To<RaceProvider>().InSingletonScope();
            Bind<IRaceLoader>().To<RaceLoader>().InSingletonScope();
            Bind<IEffectParser>().To<XmlToEffectParser>();
        }
    }
}
