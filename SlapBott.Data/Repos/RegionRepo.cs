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
    public class RegionRepo: Repo<Region>
    {
        public RegionRepo(SlapbottDbContext dBContext):base(dBContext) { }
       
        public Region? GetRegionByEnumName(Regions region)
        {
            return _dbContext.Regions.FirstOrDefault(x => x.RegionName == region);
        
        }
        public List<Region> GetAllRegionsWithAliveRaidboss()
        { 
            return _dbContext.Regions.Include(x=>x.Enemies.OfType<RaidBoss>().Where(y=>!y.IsDead)).ToList();
        }
        public List<Region> GetAllRegionsWithDeadRaidboss()
        {
            return _dbContext.Regions.Include(x => x.Enemies.OfType<RaidBoss>().Where(y => y.IsDead)).ToList();
        }
        public List<Region> GetAllRegions()
        {
            return _dbContext.Regions.ToList();
        }
        public List<Region> GetAllRegionsWithEnemies()
        {
            var d = _dbContext.Regions.Include(x => x.Enemies);
            Console.Write(d.ToQueryString());
            return _dbContext.Regions.Include(x=>x.Enemies).ThenInclude(x=>x.Character).ThenInclude(x=>x.Stats).ToList();
        }
        public Region GetRegionWithPendingBoss()
        {
            return _dbContext.Regions.FirstOrDefault(x => x.isBossPending == true);
        }

        public void SaveRegion(Region Region)
        {
            AddOrUpdateEntity(Region);
        }


        public void SaveAndSetRegionBossToPending(Region region)
        {
            region.isBossPending = true;
            AddOrUpdateEntity(region);
        
        }

        public Region GetRegionByIdOrNew(int id)
        {
           return GetByIdOrNew(id);
        }

        //public List<Region> GetAllRegionsWithRaidboss()
        //{
        //    //return _dbContext.Regions.Include(x => x.Enemies).ToList().SelectMany(x=>x.Enemies of);
        //}
    }
}
