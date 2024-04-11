using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Implmentations
{
    public class RegionService
    {
        private RegionRepo _regionRepo;
        public RegionService(RegionRepo regionRepo)
        {
            _regionRepo = regionRepo;
        }


        public Dictionary<Regions, RegionDto> GetAllRegionsAsDictionary()
        {
            Dictionary < Regions, RegionDto > RegionCollection = new Dictionary<Regions, RegionDto>();
            foreach (var region in _regionRepo.GetAllRegions())
            {
                RegionCollection.Add(region.RegionName, new RegionDto().FromRegion(region));
            }
            return RegionCollection;
        }

        public RegionDto GetRegionByRegionEnum(Regions regions)
        {
           return new RegionDto().FromRegion(_regionRepo.GetRegionByEnumName(regions));
        }
        public RegionDto GetRegionWithRaidBoss()
        {
            return new RegionDto().FromRegion(_regionRepo.GetRegionWithBoss());
        }

        public RegionDto GetRegionWithPendingRaidBoss()
        {
            return new RegionDto().FromRegion(_regionRepo.GetRegionWithPendingBoss());
        }

        public void SaveRegion(RegionDto region)
        {
            _regionRepo.SaveRegion(region.ToRegion());
        }
    }
}
