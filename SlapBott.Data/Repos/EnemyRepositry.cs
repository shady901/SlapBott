using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SlapBott.Data.Models;
using System;

namespace SlapBott.Data.Repos
{
    public class EnemyRepositry
    {
        private SlapbottDbContext _dbContext { get; set; }

        public EnemyRepositry(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }
        public T? GetEnemyByID<T>(int Id) where T : Enemy
        {
            T enemy;
            if (Id>0)
            {
               enemy = (T)_dbContext.Enemies
                    .Include(x => x.Character.Inventory)
                      
                    .Include(x => x.Character.Stats)
                    .First(enemy => enemy.Id == Id);
               
                return enemy;
            }

            return Activator.CreateInstance<T>();

        }
        
        public Enemy SaveEnemy(Enemy enemy)
        {
            AddOrUpdateEnemy(enemy);
            _dbContext.SaveChanges();
            return enemy;
        }
        public void AddOrUpdateEnemy(Enemy enemy)
        {
            if (enemy.Id <= 0) // not in the database
            {
                _dbContext.Enemies.Add(enemy);
            }
            else
            {
                _dbContext.Enemies.Update(enemy);
            }

            //DisplayTrackedEnemy();

        }
        //public void DisplayTrackedEnemy()
        //{
        //    var trackedEntities = _dbContext.ChangeTracker.Entries<RaidBoss>();

        //    foreach (var entry in trackedEntities)
        //    {
        //        Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");

        //        foreach (var property in entry.CurrentValues.Properties)
        //        {
        //            Console.WriteLine($"{property.Name}: {entry.CurrentValues[property]}");
        //        }
        //    }
        //}
       
    }
}
