using CharacterSheetVisualizer.ViewModel;
using Data.EffectParser;
using Data.Repositories;
using Data.Repositories.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using Ninject.Modules;
using Providers.CharacterProviders;
using Services.Controllers;
using Services.Controllers.Interfaces;

namespace CharacterSheetVisualizer.NinjectModules
{
    class ViewModelModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IMessenger>().To<Messenger>().InSingletonScope();
            Bind<IStatProvider>().To<StatProvider>().InSingletonScope();
            Bind<ICharacterProvider>().To<CharacterProvider>().InSingletonScope();
            Bind<ISkillProvider>().To<SkillProvider>().InSingletonScope();
            Bind<IClassProvider>().To<ClassProvider>().InSingletonScope();
            Bind<IBackgroundLoader>().To<BackgroundLoader>();
            Bind<IBackgroundProvider>().To<BackgroundProvider>();

            Bind<MainViewModel>().To<MainViewModel>().InSingletonScope();
        }
    }
}
