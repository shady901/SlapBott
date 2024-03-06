using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using Slappbott.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SlapBott.Data.Repos
{
    public class EnemyRepositry
    {
        private SlapbottDbContext _dbContext { get; set; }

        public EnemyRepositry(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }
        public Enemy GetEnemyByID(int Id)
        {

            Enemy enemy = _dbContext.Enemies.First(enemy => enemy.Id == Id);

            return enemy;
        }
        public void SaveEnemy(Enemy enemy)
        {
            AddOrUpdateEnemy(enemy);
            _dbContext.SaveChanges();
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
