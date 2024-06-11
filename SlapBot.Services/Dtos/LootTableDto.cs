using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class LootTableDto
    {


        public List<LootTableItemDto> LootTable = new List<LootTableItemDto>();




        public LootTableDto FromLootTable(LootTable lootTable)
        {
            DtoHelper.ConvertCollection<LootTableItem,LootTableItemDto>(lootTable.LootTableItems, this.LootTable , "FromRecord");

            return this;
        }



        public LootTableItemDto RandomItemFromLootTable()
        { 
            Random r = new Random();

            return LootTable[r.Next(LootTable.Count)];
        }
    }
    public class LootTableItemDto
    {
    
        public ItemType? ItemType { get; set; }
        public int ItemId { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public ItemRarety? GearRarety { get; set; }  // Only for gear items


        public LootTableItemDto FromRecord(LootTableItem item) 
        {
            ItemType = item.ItemType;
            ItemId = item.ItemId;
            Quantity = item.Quantity;
            GearRarety = item.GearRarety;

            return this;
        }

    }
}
