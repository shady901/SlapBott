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


        public EnemyDto GetEnemyByID(int EnemyID)
        {
            return new EnemyDto().FromEnemy(_enemyRepositry.GetEnemyByID(EnemyID));
        }
      
    }
}
