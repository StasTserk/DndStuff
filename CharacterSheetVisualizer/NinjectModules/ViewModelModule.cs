using CharacterSheetVisualizer.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using Ninject.Modules;
using Providers.CharacterProviders;

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
            Bind<IRaceProvider>().To<RaceProvider>().InSingletonScope();

            Bind<MainViewModel>().To<MainViewModel>().InSingletonScope();
        }
    }
}
