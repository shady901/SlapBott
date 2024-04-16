using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class RegionDto
    {
        public int Id { get; set; }
        public Regions RegionName { get; set; }
        
        public bool isBossPending { get; set; } = false;
        public bool HasActiveBoss { get; set; } = false;
        public ICollection<Enemy>? Enemies { get; set; }
        public RegionDto FromRegion(Region region)
        {
            return new RegionDto()
            {
                Id = region.Id,
                RegionName = region.RegionName,
                Enemies = region.Enemies,
                isBossPending = region.isBossPending
            };
        }
        public Region ToRegion(Region? region =null)
        {
            if (region == null)
            {
                region = new Region();
                region.Id = Id;
            }
            
            region.RegionName = RegionName;  
            region.isBossPending = isBossPending;
            return region;
        }
    }
}
