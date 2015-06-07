namespace Data.Models.Items
{
    public interface IEquippable : IItem
    {
        void EquipOn(Character target);
        void RemoveFrom(Character target);
        EquippableSlot GetSlot();
    }

    public enum EquippableSlot
    {
        Head,
        Shoulders,
        Chest,
        Wrists,
        Belt,
        Boots,
        Ring,
        Weapon
    }
}
