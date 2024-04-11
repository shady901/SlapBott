using SlapBott.Data.Models;
using SlapBott.Services.Implmentations;
namespace SlapBott.Services.Dtos
{


    public class RaidBossDto : Target
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public static RaidBossDto FromRecord(RaidBoss boss)
        {
            return new RaidBossDto()
            {
                Id = boss.Id,
                Name = boss.Character.Name,
                Description = boss.Character.Description,
                Stats = boss.Character.Stats,

            };
        } 

        public RaidBossDto FromRaidBoss(RaidBoss raidBoss)
        {
            return new RaidBossDto
            {
                Id = raidBoss.Id,
                Name = raidBoss.Character.Name,
                Description = raidBoss.Character.Description,
                Stats = raidBoss.Character.Stats,
                RaceID = (int)raidBoss.Character.RaceId,
                ClassID = (int)raidBoss.Character.ClassId,
            };
        }
    
        public RaidBoss ToRaidBoss(Region region, RaidBoss? raidBoss = null)
        {

            raidBoss.Id = Id;
            raidBoss.Character.Name = Name;
            raidBoss.Character.Description = Description;
            raidBoss.Character.Stats = Stats;
            raidBoss.Character.RaceId = RaceID;
            raidBoss.Character.ClassId = ClassID;
            raidBoss.Region = region;
            return raidBoss;
        }

        public void AssignTemplateToBoss(EnemyTemplate enemyTemplate)
        {
            
            Name = enemyTemplate.Name;
            Description = enemyTemplate.Description;
            Stats = enemyTemplate.Stats;
            RaceID = (int)enemyTemplate.RaceId;
            ClassID = (int)enemyTemplate.ClassId;
            Race = new RaceDto().FromRace(enemyTemplate.Race);
            CharacterClassDto = new CharacterClassDto().FromClass(enemyTemplate.CharacterClass);
        }

      
    }
}
