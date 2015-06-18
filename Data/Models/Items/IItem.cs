using System.Collections.Generic;
using Data.Models.Effects;

namespace Data.Models.Items
{
    public interface IItem
    {
        void Use(Character target);

        string Name { get; }
        string Description { get; }
        string ShortDescription { get; }
        double Weight { get; }
        int Cost { get; }
    }
}