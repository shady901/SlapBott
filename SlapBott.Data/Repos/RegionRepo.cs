using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public class RegionRepo
    {
        private SlapbottDbContext _dbContext { get; set; }

        public RegionRepo(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }
        public Region? GetRegionByEnumName(Regions region)
        {
            return _dbContext.Regions.FirstOrDefault(x => x.RegionName == region);
        
        }
        public List<Region> GetAllRegions()
        { 
            return _dbContext.Regions.ToList();
        }

        public Region? GetRegionWithBoss()
        {
            return _dbContext.Regions.FirstOrDefault(x => x.RaidBossId > 0);
        }

        public Region GetRegionWithPendingBoss()
        {
            return _dbContext.Regions.FirstOrDefault(x => x.isBossPending == true);
        }

        public void SaveRegion(Region Region)
        {
            AddOrUpdateRegion(Region);
            _dbContext.SaveChanges();
        }
        public void AddOrUpdateRegion(Region Region)
        {
            var meth = _dbContext.Regions.Update;


            if (Region.Id <= 0) // not in the database
            {
                meth = _dbContext.Regions.Add;
            }

            meth(Region);

        }
    }
}
