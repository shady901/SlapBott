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
            IQueryable<EnemyTemplate> query = _dbContext.EnemyTemplates;

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

            if (classes == null && race == null)
            {
                int totalCount = query.Count();
                int randomIndex = new Random().Next(totalCount);
                query = query.OrderBy(x => Guid.NewGuid()).Skip(randomIndex);
            }
            return query.FirstOrDefault();
        }
    }
}
