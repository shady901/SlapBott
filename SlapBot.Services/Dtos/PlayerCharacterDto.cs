using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Contracts;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class PlayerCharacterDto : Target,IDisplayAble, ITarget
    {
      
        public bool IsTemp { get; set; }
        public bool HasLeveled { get; set; } = false;
        public Races SelectedRace { get; set; }
        public RaceDto? Race { get; set; }
        public ulong DiscordId { get; set; }
        //public Stats Stats { get; set; }
        public int regId { get; set; }
        public ulong CharExp { get; set; }
        public int level => (int)(450 + Math.Sqrt(202500 + 1800 * CharExp)) / 900;
        //   public List<Ailments> ailments { get; set; }
        //   public List<Buff> Buffs { get; set; }

        public Classes SelectedClass { get; set; }
        public CharacterClassDto? CharacterClass { get; set; }
        public SubClassDto? SubClass { get; set; }
        //equipement inventory starts at id of 
        public InventoryDto? Inventory { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; }
      //  public int CharId { get; private set; }
        public int statsId { get; set; }
        public int CombatStateId { get; set; } = 0;
       
        public static PlayerCharacterDto FromCharacter(PlayerCharacter playercharacter)
        {
            if (playercharacter.Character == null)
            {
                Console.WriteLine($"From CharacterMeth DId:{playercharacter.DiscordId} CharId:{playercharacter.CharacterId} char is null");
                
            }


            return new PlayerCharacterDto
            {

                regId = playercharacter.RegistrationId,
                statsId = playercharacter.Character.StatsId,
                Stats = playercharacter.Character.Stats,
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
                Inventory = new InventoryDto().FromInventory(playercharacter.Character.Inventory),
            };
            
               
        }
        public PlayerCharacter ToCharacter(PlayerCharacter? playerCharacter = null)
        {
           
            playerCharacter.RegistrationId = regId;
            playerCharacter.DiscordId = DiscordId;
            playerCharacter.Character.Name = Name;
            playerCharacter.Character.Description = Description;
            playerCharacter.Character.Stats = Stats;
            playerCharacter.IsTemp = IsTemp;
            playerCharacter.Character.RaceId = (int)SelectedRace;
            playerCharacter.Character.ClassId = SelectedClass == Classes.None ? null : (int)SelectedClass;
            playerCharacter.Character.LearnedSkillIds = Skills;
            playerCharacter.Character.Inventory = Inventory?.ToInventory();
           
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

            var oldlevel = level;
            CharExp += (ulong)exp;

            HasLeveled = oldlevel != level;
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
