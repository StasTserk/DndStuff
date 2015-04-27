using System.Collections.Generic;

namespace CharacterSheetVisualizer.Model
{
    public interface IStatService
    {
        IEnumerable<Stat> GetDefaultStats(LevelModifiers modifiers);
    }
}