using System;
using DnD5thEdTools.Models;

namespace Services
{
    public class FilterService
        : IFilterService
    {
        public Func<Spell, bool> GetFilterForConcentration(BoolFilterState state)
        {
            switch (state)
            {
                case BoolFilterState.Yes:
                    return (x => x.Concentration);
                case BoolFilterState.No:
                    return (x => !x.Concentration);
                default:
                    return null;
            }
        }
    }
}
