using SlapBott.Data.Enums;
using SlapBott.Data.Models;
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
                Stats = new StatsDto().FromStats(boss.Character.Stats),
                RaceID = (int)boss.Character.RaceId,
                ClassID = (int)boss.Character.ClassId,
                RegionId = boss.RegionId,
                StateId = boss.Character.CombatStateID,
                Skills = boss.Character.LearnedSkillIds,
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
            if(raidBoss == null)
            {
                raidBoss = new RaidBoss() { Character = new Character() { Stats = new Stats()} };
            }
            raidBoss.RegionId = RegionId;
            raidBoss.Character.Name = Name??string.Empty;
            raidBoss.Character.Description = Description??string.Empty;
            raidBoss.Character.Stats = Stats.ToStats();
            raidBoss.Character.RaceId = RaceID;
            raidBoss.Character.ClassId = ClassID;
            raidBoss.Character.CombatStateID = StateId;
            raidBoss.Character.LearnedSkillIds = Skills;
            return raidBoss;
        }

        public void AssignTemplateToBoss(EnemyTemplate enemyTemplate)
        {
            
            Name = enemyTemplate.Name;
            Description = enemyTemplate.Description;
            Stats =new StatsDto().FromStats(enemyTemplate.Stats);
            RaceID = (int)enemyTemplate.RaceId;
            ClassID = (int)enemyTemplate.ClassId;
            Skills = enemyTemplate.LearnedSkillIds;
           
           
        }
        public void SetupPlayerCountStats(int PlayerCount)
        {
           
            Stats.stats[StatType.MaxHealth] = Stats.stats[StatType.MaxHealth] * PlayerCount;
            Stats.stats[StatType.Health] = Stats.stats[StatType.MaxHealth];
           
        }
      
    }
}
