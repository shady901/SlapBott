using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.VisualBasic;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.ItemProject.Extensions;

namespace SlapBott.Services.Dtos
{
    public class InventoryDto
    {
        public Dictionary<EquipType, Equipment>? Equiped { get; set; }
        public List<Equipment>? Bag { get; set; }

        

        public void SaveItemToBag(Equipment equipment)
        {
            Bag.Add(equipment);
        }
        public void SaveItemToEquiped(Equipment? equipment = null, string? Id = null)
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
        private void SaveArmorToEquiped(Equipment equipment)
        {
            SaveItemToBag(Equiped[equipment.EquipType]);
            RemoveItemFromBag(equipment: equipment);
        }
        private void SaveWeaponToEquiped(Equipment equipment) 
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
        private bool DoesItemExistInBag(string? Id = null, Equipment? equipment = null)
        {

            return GetEquipmentFromBag(Id, equipment) != null;
        }
        private Equipment GetEquipmentFromBag(string? Id = null, Equipment? equipment = null)
        {

            Equipment? temp = null;
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
        private void RemoveItemFromBag(Equipment equipment)
        {          
            Bag.Remove(equipment);
        }

        

        public InventoryDto FromInventory(Inventory? inventory)
        {
            Equiped = inventory.Equiped;
            
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