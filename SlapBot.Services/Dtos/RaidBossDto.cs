using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Implmentations;
namespace SlapBott.Services.Dtos
{


    public class RaidBossDto : Target
    {
   

        public static RaidBossDto FromRecord(RaidBoss boss)
        {
            return new RaidBossDto()
            {
                Id = boss.Id,
                Name = boss.Character.Name,
                Description = boss.Character.Description ?? string.Empty,
                Stats = boss.Character.Stats,
                RaceID = (int)boss.Character.RaceId,
                ClassID = (int)boss.Character.ClassId,
                RegionId = boss.RegionId,
                StateId = boss.Character.CombatStateID,
            };
        } 

        //public RaidBossDto FromRaidBoss(RaidBoss raidBoss)
        //{
        //    return new RaidBossDto
        //    {
        //        Id = raidBoss.Id,
        //        Name = raidBoss.Character.Name,
        //        Description = raidBoss.Character.Description,
        //        Stats = raidBoss.Character.Stats,
        //        RaceID = (int)raidBoss.Character.RaceId,
        //        ClassID = (int)raidBoss.Character.ClassId,
        //    };
        //}
    
        public RaidBoss ToRaidBoss(RaidBoss? raidBoss = null)
        {
            if (raidBoss == null)// if making new raid boss it will be null
            {
                raidBoss = new RaidBoss(){Character= new Character() {Inventory = new Inventory() } };
                raidBoss.Id = Id;
            }
            raidBoss.RegionId = RegionId;
            raidBoss.Character.Name = Name??string.Empty;
            raidBoss.Character.Description = Description??string.Empty;
            raidBoss.Character.Stats = Stats;
            raidBoss.Character.RaceId = RaceID;
            raidBoss.Character.ClassId = ClassID;
            raidBoss.Character.CombatStateID = StateId;
            return raidBoss;
        }

        public void AssignTemplateToBoss(EnemyTemplate enemyTemplate)
        {
            
            Name = enemyTemplate.Name;
            Description = enemyTemplate.Description;
            Stats = enemyTemplate.Stats;
            RaceID = (int)enemyTemplate.RaceId;
            ClassID = (int)enemyTemplate.ClassId;
           
           
        }
        public void SetupPlayerCountStats(int PlayerCount)
        {
            Stats.stats[StatType.MaxHealth] = Stats.stats[StatType.MaxHealth] * PlayerCount;
            Stats.stats[StatType.Health] = Stats.stats[StatType.MaxHealth];
           
        }
      
    }
}
