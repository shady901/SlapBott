using SlapBott.Data.Enums;

namespace SlapBott.ItemProject.Contracts
{
    public interface IItem
    {
        int Seed { get; set; }

        string? name { get; set; }
        EquipType EquipType { get; set; }
        ItemRarety itemRarety { get; set; }
        List<ItemAffix> itemAffixes { get; set; }




    }
}
