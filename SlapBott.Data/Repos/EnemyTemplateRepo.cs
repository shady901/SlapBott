using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public class EnemyTemplateRepo
    {
        private SlapbottDbContext _dbContext { get; set; }

        public EnemyTemplateRepo(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }

        public EnemyTemplate GetTemplate(Classes? classes = null, Races? race = null)
        {
            IQueryable<EnemyTemplate> query = _dbContext.EnemyTemplates.AsNoTracking();

            if (classes != null)
            {
                int classId = (int)classes;
                query = query.Where(x => x.ClassId == classId);
            }
            if (race != null)
            {
                int raceId = (int)race;
                query = query.Where(x => x.RaceId == raceId);
            }          
            List<EnemyTemplate> templates = query.ToList();

            int totalCount = templates.Count;
            if (totalCount == 0)
            {
                return new(); 
            }
            int randomIndex = new Random().Next(totalCount-1);
            EnemyTemplate randomTemplate = templates[randomIndex];
            return randomTemplate;
        }
       
    }
}
