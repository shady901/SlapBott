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
        public EnemyService(EnemyRepositry repo)
        {
            _enemyRepositry = repo;
            //_mediator = mediator;
        }
        public void SaveEnemy(EnemyDto enemy)
        {
            _enemyRepositry.SaveEnemy(enemy.ToEnemy());
        }
        public void SaveRaidBoss(RaidBossDto raidBoss)
        {

            _enemyRepositry.SaveEnemy(raidBoss.ToRaidBoss());
        }

        private Tout Get<Tout, TIn>(int Id) where Tout : Target where TIn : Enemy
        {
            TIn enemy = GetEnemyByID<TIn>(Id);
            if (enemy != null)
            {
                return (Tout)(object)Tout.FromRecord(enemy);
            }
            return default;
        }

        public EnemyDto GetEnemyByID(int EnemyID)
        {
            return Get<EnemyDto, Enemy>(EnemyID);
        }
        public RaidBossDto GetRaidBossByID(int EnemyID)
        {
            return RaidBossDto.FromRecord(GetEnemyByID<RaidBoss>(EnemyID));
            //return new RaidBossDto().FromRaidBoss(_enemyRepositry.GetEnemyByID<RaidBoss>(EnemyID));
        }

        private T GetEnemyByID<T>(int EnemyID) where T : Enemy 
        {
            return _enemyRepositry.GetEnemyByID<T>(EnemyID);
        }

        private void GenerateRaidBoss()
        {

            //Create an Instance of a raidboss
            //GetTemplate
            //assign properties (stats,name ,ect)

            //assign class (get class changes and passives)
            //assign Skills (template or Random)




        }

    }
}
