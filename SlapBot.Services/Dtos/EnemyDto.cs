using SlapBott.Data.Models;
using SlapBott.Services.Contracts;
using SlapBott.Services.Implmentations;

namespace SlapBott.Services.Dtos
{
    public class EnemyDto: Target
    {


     

        //public void ApplyDamage(int damage, StatType elementalType)
        //{

        //}
        public static EnemyDto FromRecord(Enemy enemy)
        {
            return new EnemyDto
            {
                Id = enemy.Id,
                Name = enemy.Character.Name,
                Description = enemy.Character.Description,
                Stats = new StatsDto().FromStats(enemy.Character.Stats),

            };
        }
        public EnemyDto FromEnemy(Enemy enemy)
        {
            return new EnemyDto
            {
                Id = enemy.Id,
                Name = enemy.Character.Name,
                Description = enemy.Character.Description,
                Stats = new StatsDto().FromStats(enemy.Character.Stats),
           
            };
        }
        public Enemy ToEnemy(Enemy? enemy = null)
        {

            enemy.Id = Id;
            enemy.Character.Name = Name;
            enemy.Character.Description = Description;
            enemy.Character.Stats = Stats.ToStats();
            
            return enemy;
        }
    }
}
