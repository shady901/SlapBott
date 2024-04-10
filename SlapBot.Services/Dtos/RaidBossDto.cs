using SlapBott.Data.Models;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            };
        }
    
        public RaidBoss ToRaidBoss(RaidBoss? raidBoss = null)
        {

            raidBoss.Id = Id;
            raidBoss.Character.Name = Name;
            raidBoss.Character.Description = Description;
            raidBoss.Character.Stats = Stats;

            return raidBoss;
        }

        public void AssignTemplateToBoss(EnemyTemplate enemyTemplate)
        {



        }

        
    }
}
