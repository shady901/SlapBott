using SlapBott.Data.Enums;

namespace SlapBott.ItemProject.Contracts
{
    public interface IItem
    {
        int Seed { get; set; }

        string Name { get; set; }
        string Description { get; set; }
        EquipType EquipType { get; set; }
        ItemRarety itemRarety { get; set; }
        List<ItemAffix> itemAffixes { get; set; }




    }
}
