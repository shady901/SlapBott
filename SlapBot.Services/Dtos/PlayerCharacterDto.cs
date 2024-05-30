﻿using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Services.Dtos
{
    public class PlayerCharacterDto : Target
    {
      
        public bool IsTemp { get; set; }
        public bool HasLeveled { get; set; } = false;
        public Races SelectedRace { get; set; }
        public Classes SelectedClass { get; set; }
        public ulong DiscordId { get; set; }
        //public Stats Stats { get; set; }
        public int RegId { get; set; }
      
        public int Level => (int)(450 + Math.Sqrt(202500 + 1800 * CharExp)) / 900;
        //   public List<Ailments> ailments { get; set; }
        //   public List<Buff> Buffs { get; set; }


     

        public static PlayerCharacterDto FromCharacter(PlayerCharacter playercharacter)
        {
            if (playercharacter.Character == null)
            {
                Console.WriteLine($"From CharacterMeth DId:{playercharacter.DiscordId} CharId:{playercharacter.CharacterId} char is null");
                
            }


            return new PlayerCharacterDto
            {

                RegId = playercharacter.RegistrationId,
                StatsId = playercharacter.Character.StatsId,
                Stats = new StatsDto().FromStats(playercharacter.Character.Stats),
                IsTemp = playercharacter.IsTemp,
                Name = playercharacter.Character.Name ?? "Temp",
                Description = playercharacter.Character.Description ?? "Temp",
                DiscordId = playercharacter.DiscordId,
                Id = playercharacter.Id,
                Skills = playercharacter.Character.LearnedSkillIds ?? new(),


                SelectedRace = playercharacter.Character.RaceId is null ? Races.None : (Races)playercharacter.Character.RaceId,
                Race = playercharacter.Character.Race is null ? new RaceDto() : new RaceDto().FromRace(playercharacter.Character.Race),

                CombatStateId = playercharacter.Character.CombatStateID,
                SelectedClass = playercharacter.Character.ClassId is null ? Classes.None : (Classes)playercharacter.Character.ClassId,
                CharacterClass = playercharacter.Character.CharacterClass is null ? new CharacterClassDto() : new CharacterClassDto().FromClass(playercharacter.Character.CharacterClass),
                InventoryId = playercharacter.Character.InventoryId,
                Inventory = new InventoryDto().FromInventory(playercharacter.Character.Inventory),
            };
            
               
        }
        public PlayerCharacter ToCharacter(PlayerCharacter? playerCharacter = null)
        {
         
            playerCharacter.RegistrationId = RegId;
            playerCharacter.DiscordId = DiscordId;
            playerCharacter.Character.Name = Name;
            playerCharacter.Character.Description = Description;
            //playerCharacter.Character.Stats.stats.Clear();
            Stats.ToStats(playerCharacter.Character.Stats);
            playerCharacter.IsTemp = IsTemp;
            playerCharacter.Character.RaceId = (int)SelectedRace;
            playerCharacter.Character.ClassId = SelectedClass == Classes.None ? null : (int)SelectedClass;
            playerCharacter.Character.LearnedSkillIds = Skills;
            playerCharacter.Character.Inventory = Inventory.ToInventory(playerCharacter.Character.Inventory);
            playerCharacter.Character.CombatStateID = StateId;
            return playerCharacter;
        }


        public SkillDto GetBySkill(string skill)
        {
            if (skill == string.Empty)
            {
                return null;
            }
            //SkillDto? TargetSkill = Skills?.FirstOrDefault(x => x.Name.ToLower().Contains(skill.ToLower()));

            return null;

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

            var oldlevel = Level;
            CharExp += (ulong)exp;

            HasLeveled = oldlevel != Level;
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

        public void SetCharacerRaceBaseStats()
        {
            if (Race?.BaseStats != null)
            {
                Stats.stats = Race.BaseStats;
            }
           
        }
        public void SetCharacerClassBaseStats()
        {
            if (CharacterClass?.BaseStats != null)
            {
                Stats.stats = CharacterClass.BaseStats;
            }

        }

       
    }
}
