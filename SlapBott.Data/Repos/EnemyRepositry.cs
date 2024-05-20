﻿using SlapBott.Data.Models;
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
               enemy = (T)_dbContext.Enemies.First(enemy => enemy.Id == Id);
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
            var meth = _dbContext.Enemies.Update;


            if (enemy.Id <= 0) // not in the database
            {
                meth = _dbContext.Enemies.Add;
            }

            meth(enemy);

        }

       
    }
}
