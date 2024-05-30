using SlapBott.Data.Models;
using SlapBott.Services.Contracts;

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
                Skills = enemy.Character.LearnedSkillIds,
                
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
                Skills = enemy.Character.LearnedSkillIds,
            };
        }
        public Enemy ToEnemy(Enemy? enemy = null)
        {

            enemy.Id = Id;
            enemy.Character.Name = Name;
            enemy.Character.Description = Description;

            Stats.ToStats(enemy.Character.Stats);
            
            return enemy;
        }

        public static int GetRandomFromList(List<int> list)
        {
            Random random = new Random();
            int index = random.Next(list.Count);
            return list[index];
        }
    }
}
