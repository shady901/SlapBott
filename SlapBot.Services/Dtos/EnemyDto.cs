using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class EnemyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Stats Stats { get; set; }
        public CombatStats CStats { get; set; }

        public Dictionary<string, Skill> Skills { get; set; }
        public EnemyDto FromEnemy(Enemy enemy)
        {
            return new EnemyDto
            {
                Id = enemy.Id,
                Name = enemy.Name,
                Description = enemy.Description,
                Stats = enemy.Stats,
                CStats = enemy.CStats,
            };
        }
        public Enemy ToEnemy(Enemy? enemy = null)
        {

            enemy.Id = Id;
            enemy.Name = Name;
            enemy.Description = Description;
            enemy.Stats = Stats;
            enemy.CStats = CStats;
            return enemy;
        }
    }
}
