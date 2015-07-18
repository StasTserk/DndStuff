using System;
using DnD5thEdTools.Models;

namespace Services
{
    public enum BoolFilterState
    {
        Disabled,
        Yes,
        No
    }

    public interface IFilterService
    {
        Func<Spell, bool> GetFilterForConcentration(BoolFilterState state);
    }
}