using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class PlayerCharacterDto : Target, ITarget
    {
        public bool IsTemp { get; set; }
        public bool HasLeveled { get; set; } = false;
        public Races SelectedRace { get; set; }
        public RaceDto? Race { get; set; }
        public ulong DiscordId { get; set; }
        //public Stats Stats { get; set; }

        public ulong CharExp { get; set; }
        public int level => (int)(450 + Math.Sqrt(202500 + 1800 * CharExp)) / 900;
        //   public List<Ailments> ailments { get; set; }
        //   public List<Buff> Buffs { get; set; }

        public Classes SelectedClass { get; set; }
        public CharacterClassDto? CharacterClass { get; set; }
        public SubClassDto? SubClass { get; set; }
        //equipement inventory starts at id of 
        public InventoryDto? Inventory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PlayerCharacterDto FromCharacter(PlayerCharacter character)
        {
            return new PlayerCharacterDto { Stats = character.Character.Stats, IsTemp = character.IsTemp};
        }



        public Skill GetBySkill(string skill)
        {
            if (skill == string.Empty)
            {
                return null;
            }
            var temp = Skills.Values.FirstOrDefault(x => x.Name.ToLower().Contains(skill.ToLower()));

            return temp;

        }
        public Equipment GetEquipmentBySlot(EquipType d)
        {
            return null; //Inventory.Equiped;
        }
        /// <summary>
        /// ID is ItemID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>an equiment</returns>
        public Equipment GetEquipmentByItemID(int ID)
        {
            return null; // Inventory.First(e => e.ItemID == ID);
        }
        public void AddExp(int exp)
        {

            var oldlevel = level;
            CharExp += (ulong)exp;

            HasLeveled = oldlevel != level;
        }

        public int GetCombinedStat(StatType statType)
        {

            //return Stats.Dexterity + Inventory.GetAllEquipedItemsStatsByStatType(statType);
            //var itemStat = Inventory.GetAllEquipedItemsStatsByStatType(statType);
            if (Inventory.Equiped.Count >= 0)
            {
                switch (statType)
                {
                    case StatType.Dexterity:
                        return Stats.Dexterity + Inventory.GetAllEquipedItemsStatsByStatType(statType);
                    case StatType.Strength:
                        return Stats.Strength + Inventory.GetAllEquipedItemsStatsByStatType(statType);
                    case StatType.Intelligence:
                        return Stats.Intelligence + Inventory.GetAllEquipedItemsStatsByStatType(statType);
                    case StatType.AttackDamage:
                        return Stats.AttackDamage + Inventory.GetAllEquipedItemsStatsByStatType(statType);
                    case StatType.CritChance:
                        return Stats.CritChance + Inventory.GetAllEquipedItemsStatsByStatType(statType);
                    case StatType.SpellPower:
                        return Stats.SpellPower + Inventory.GetAllEquipedItemsStatsByStatType(statType);
                    case StatType.Health:
                        return Stats.Health + Inventory.GetAllEquipedItemsStatsByStatType(statType);
                    case StatType.MaxHealth:
                        return Stats.MaxHealth + Inventory.GetAllEquipedItemsStatsByStatType(statType);
                    default:
                        return 0;
                }
            }
            return 0;
        }


        public int CalculateBaseStatDamageFor(Skill skill)
        {

            var damage = 0;
            List<StatType> baseTypes = new List<StatType>() { StatType.Intelligence, StatType.Intelligence, StatType.Intelligence };
            foreach (var baseType in baseTypes)
            {
                //var d = (int)skill.StatTypeRatio[baseType];
                //var t = (int)GetCombinedStat(baseType);
                //damage += t * d;
            }

            return damage;
        }

        //public void ApplyDamage(int damage, StatType elementalType)
        //{

        //}



    }
}
