using CharacterSheetVisualizer.Design;
using Ninject.Modules;
using Services.Controllers.Interfaces;

namespace CharacterSheetVisualizer.NinjectModules
{
    public class DesignTimeModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IClassController>().To<DesignClassController>().InSingletonScope();
        }
    }
}
