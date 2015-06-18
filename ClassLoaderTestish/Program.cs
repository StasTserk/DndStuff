using System;
using Data.EffectParser;
using Data.Models;
using Data.Repositories;
using Services.Controllers;

namespace ClassLoaderTestish
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new ClassLoader(new XmlToEffectParser());
            var controller = new ClassController(loader);

            var barb = controller.GetClassByClassType(CharacterClassType.Barbarian);

            Console.WriteLine(barb);
        }
    }
}
