using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Dtos;

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
        public EnemyDto SaveEnemy(EnemyDto enemy)
        {
           var original = _enemyRepositry.GetEnemyByID<Enemy>(enemy.Id);

            return EnemyDto.FromRecord(_enemyRepositry.SaveEnemy(enemy.ToEnemy(original)));
        }
        public RaidBoss SaveRaidBoss(RaidBossDto raidBoss, RaidBoss? OriginalRb = null)
        {

            if (OriginalRb == null)
            {
                OriginalRb = _enemyRepositry.GetEnemyByID<RaidBoss>(raidBoss.Id);
            }
           return (RaidBoss)_enemyRepositry.SaveEnemy(raidBoss.ToRaidBoss(OriginalRb));
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
            return GetEnemyAs<T, Enemy>(EnemyID); 
        }
        private T GetEnemyByID<T>(int EnemyID) where T : Enemy 
        {
            return _enemyRepositry.GetEnemyByID<T>(EnemyID);
        }

        public RaidBossDto GenerateNewRaidBoss(Classes? classes = null,Races? races = null )
        {
            var template = _enemyTemplateRepositry.GetTemplate(classes: classes, race: races);
            RaidBossDto raidBoss = new RaidBossDto() { };
            raidBoss.AssignTemplateToBoss(template);
            raidBoss.Stats.InitialiseRaidBossStats();            



            return raidBoss;

        }
       

    }
}
