using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.VisualBasic;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.ItemProject.Extensions;

namespace SlapBott.Services.Dtos
{
    public class InventoryDto
    {
        public Dictionary<EquipType, EquipmentDto>? Equiped { get; set; }
        public List<EquipmentDto>? Bag { get; set; }

        

        public void SaveItemToBag(EquipmentDto equipment)
        {
            Bag.Add(equipment);
        }
        public void SaveItemToEquiped(EquipmentDto? equipment = null, string? Id = null)
        {
            var temp = GetEquipmentFromBag(Id, equipment);
            if (temp!=null)
            {
                if (temp.EquipType == EquipType.MainHand || temp.EquipType == EquipType.OffHand)
                {
                    SaveWeaponToEquiped(temp);
                }
                else
                {
                    SaveArmorToEquiped(temp);
                }
            }

        }
        private void SaveArmorToEquiped(EquipmentDto equipment)
        {
            SaveItemToBag(Equiped[equipment.EquipType]);
            RemoveItemFromBag(equipment: equipment);
        }
        private void SaveWeaponToEquiped(EquipmentDto equipment) 
        {
            SaveItemToBag(Equiped[equipment.EquipType]);
            if (equipment.WeaponType.GetHandedAttribute() == Handed.TwoHanded)
            {                
                SaveItemToBag(Equiped[EquipType.OffHand]);
                Equiped.Remove(EquipType.OffHand);
              
            }
            Equiped[equipment.EquipType] = equipment;
            RemoveItemFromBag(equipment: equipment);
        }
        private bool DoesItemExistInBag(string? Id = null, EquipmentDto? equipment = null)
        {

            return GetEquipmentFromBag(Id, equipment) != null;
        }
        private EquipmentDto GetEquipmentFromBag(string? Id = null, EquipmentDto? equipment = null)
        {

            EquipmentDto? temp = null;
            if (equipment != null || Id != null)
            {
                if (equipment == null)
                {
                    temp = Bag.Where(x => x.Id == equipment.Id).FirstOrDefault();
                }
                else
                {
                    temp = Bag.Where(x => x.Id.ToString() == Id).FirstOrDefault();
                }

            }
            return temp;
        }
        private void RemoveItemFromBag(EquipmentDto equipment)
        {          
            Bag.Remove(equipment);
        }

        

        public InventoryDto FromInventory(Inventory? inventory)
        {
            
            return this;
        }

        internal Inventory? ToInventory(Inventory? inventory = null)
        {
            if (inventory == null)
            { 
                inventory = new Inventory();
            }
            inventory.Equiped = Equiped;
            return inventory;
        }
    }
}