using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Services.Controllers.Interfaces;

namespace Providers.CharacterProviders
{
    public class ClassProvider : IClassProvider
    {
        private readonly IClassController _classController;

        public ClassProvider(IClassController classController)
        {
            _classController = classController;
        }

        public CharacterClass GetSampleClass()
        {
            return _classController.GetClassByClassType(CharacterClassType.Barbarian);
        }

        public CharacterClass GetClassByClassType(CharacterClassType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CharacterClass> GetAvailableLevelUpOptions(Character player)
        {
            if (player.LevelModifiers.Level == 20)
            {
                // if max level return empty list
                return new List<CharacterClass>();
            }

            // otherwise return all classes we are not level 20 in -- TODO add multiclassing
            return player.LevelModifiers.ClassesAndLevels
                .Select(cl => GetClassByClassType(cl.Item1));
        }

        public IEnumerable<ClassLevel> GetAvailableClassLevelOptions(Character player)
        {
            if (player.LevelModifiers.Level == 20)
            {
                // if max level return empty list
                return new List<ClassLevel>();
            }

            // otherwise return all classes we are not level 20 in -- TODO add multiclassing
            return player.LevelModifiers.ClassesAndLevels
                .Select(cl => GetClassByClassType(cl.Item1).LevelEffects.First(l => l.Level == cl.Item2));
        }
    }
}
