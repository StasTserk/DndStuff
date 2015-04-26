using System;
using DnD5thEdTools.Models;

namespace MVVMViews.Messages
{
    public enum FilterType
    {
        Concentration,
    }

    public class FilterAppliedMessage
    {
        public FilterType Type { get; set; }
        public Func<Spell, bool> FilterFunction { get; set; }
    }
}
