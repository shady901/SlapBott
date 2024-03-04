using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using SlapBott.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class EnemyDto: Target ,ITarget
    {


        public string Name { get; set; }
        public string Description { get; set; }
       

        //public void ApplyDamage(int damage, StatType elementalType)
        //{
            
        //}

        public EnemyDto FromEnemy(Enemy enemy)
        {
            return new EnemyDto
            {
                Id = enemy.Id,
                Name = enemy.Name,
                Description = enemy.Description,
                Stats = enemy.Stats,
           
            };
        }
        public Enemy ToEnemy(Enemy? enemy = null)
        {

            enemy.Id = Id;
            enemy.Name = Name;
            enemy.Description = Description;
            enemy.Stats = Stats;
            
            return enemy;
        }
    }
}
