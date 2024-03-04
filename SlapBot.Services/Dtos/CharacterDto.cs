﻿using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class CharacterDto
    {


        public bool HasLeveled { get; set; } = false;
        public int Id { get; set; }
        public int DiscordID { get; set; }
        //public Stats Stats { get; set; }

        public ulong CharExp { get; set; }
        public int level => (int)(450 + Math.Sqrt(202500 + 1800 * CharExp)) / 900;
        //   public List<Ailments> ailments { get; set; }
        //   public List<Buff> Buffs { get; set; }
        public Stats Stats;
        public SubClass CharacterClass { get; set; }
        //equipement inventory starts at id of 
        public Inventory Inventory { get; set; }
        public Dictionary<int, Skill> Skills { get; set; }
        public CharacterDto FromCharacter(Character character)
        {
            return new CharacterDto { Stats = character.Stats };
        }
        public Character ToCharacter(Character? character = null)
        {
            return new Character { Stats = character.Stats };
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
            return Inventory.Equiped;
        }
        /// <summary>
        /// ID is ItemID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>an equiment</returns>
        public Equipment GetEquipmentByItemID(int ID)
        {
            return Inventory.First(e => e.ItemID == ID);
        }
        public void AddExp(int exp)
        {

            var oldlevel = level;
            CharExp += (ulong)exp;

            HasLeveled = oldlevel != level;
        }

        public int GetCombinedStat(StatType statType)
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

 
        public int CalculateBaseStatDamageFor(Skill skill) 
        {

            var damage = 0;
            List<StatType> baseTypes = new List<StatType>() { StatType.Intelligence , StatType.Intelligence , StatType.Intelligence };
            foreach (var baseType in baseTypes)
            {
                var d = (int)skill.StatTypeRatio[baseType];
                var t = (int)GetCombinedStat(baseType);
                damage += t * d;
            }

            return damage;
        }
    }
}
