using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Implmentations
{
    public class EnemyService
    {
        private EnemyRepositry? _enemyRepositry { get; set; }
        private EnemyTemplateRepo? _enemyTemplateRepositry { get; set; }
        public EnemyService(EnemyRepositry repo, EnemyTemplateRepo enemyTemplateRepo)
        {
            _enemyTemplateRepositry = enemyTemplateRepo;
            _enemyRepositry = repo;
            //_mediator = mediator;
        }
        public void SaveEnemy(EnemyDto enemy)
        {
            _enemyRepositry.SaveEnemy(enemy.ToEnemy());
        }
        public void SaveRaidBoss(RaidBossDto raidBoss, RegionDto region)
        {

            _enemyRepositry.SaveEnemy(raidBoss.ToRaidBoss(region.ToRegion()));
        }

        private Tout GetEnemyAs<Tout, TIn>(int id) where Tout : Target where TIn : Enemy
        {
            TIn enemy = GetEnemyByID<TIn>(id);
            if (enemy != null)
            {
                var fromRecordMethod = typeof(Tout).GetMethod("FromRecord");
                return fromRecordMethod.Invoke(null, new object[] { enemy }) as Tout;
            }
            return default;
        }

    
        public T GetEnemyTargetByID<T>(int EnemyID) where T : Target
        {
            return GetEnemyAs<T, Enemy>(EnemyID); ;
        }
        private T GetEnemyByID<T>(int EnemyID) where T : Enemy 
        {
            return _enemyRepositry.GetEnemyByID<T>(EnemyID);
        }

        public RaidBossDto GenerateNewRaidBoss(Classes? classes = null,Races? races = null )
        {

            RaidBossDto raidBoss = new RaidBossDto();
            raidBoss.AssignTemplateToBoss(_enemyTemplateRepositry.GetTemplate(classes:classes, race:races));
            raidBoss.Stats.InitialiseRaidBossStats();            
            return raidBoss;
        }

    }
}
