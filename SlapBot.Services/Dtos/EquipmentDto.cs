using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public int MaterialId { get; set; } = 0;
        public int ConsumableId { get; set; } = 0;
        public Material? Material { get; set; }
        public Consumable? Consumable { get; set; }
        public int Seed { get; set; }
        public EquipType EquipType { get; set; }
        public WeaponType WeaponType { get; set; }
        public ArmorType ArmorType { get; set; }
        public int DroppedLevel { get; set; }
        public int Count { get; set; }



        public EquipmentDto FromRecord(Equipment equipment)
        {
            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment));

            Id = equipment.Id;
            MaterialId = equipment.MaterialId;
            ConsumableId = equipment.ConsumableId;
            Material = equipment.Material;
            Consumable = equipment.Consumable;
            Seed = equipment.Seed;
            EquipType = equipment.EquipType;
            WeaponType = equipment.WeaponType;
            ArmorType = equipment.ArmorType;
            DroppedLevel = equipment.DroppedLevel;
            Count = equipment.Count;

            return this;
        }

        public Equipment ToRecord(Equipment equipment = null)
        {
            if (equipment == null)
            {
                equipment = new Equipment();
            }

            equipment.MaterialId = this.MaterialId;
            equipment.ConsumableId = this.ConsumableId;
            equipment.Material = this.Material;
            equipment.Consumable = this.Consumable;
            equipment.Seed = this.Seed;
            equipment.EquipType = this.EquipType;
            equipment.WeaponType = this.WeaponType;
            equipment.ArmorType = this.ArmorType;
            equipment.DroppedLevel = this.DroppedLevel;
            equipment.Count = this.Count;

            return equipment;
        }
    }
}
}
