using SlapBott.Data.Enums;

namespace SlapBott.ItemProject.Contracts
{
    public interface IItem
    {
        int seed { get; set; }

        string? name { get; set; }
        EquipType EquipType { get; set; }
        ItemRarety itemRarety { get; set; }
        List<ItemAffix> itemAffixes { get; set; }

        T Cast<T>() where T : IItem;



    }
}
