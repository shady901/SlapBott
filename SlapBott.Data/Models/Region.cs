using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Region
    {
        public int Id { get; set; }
        public Regions RegionName { get; set; }
       
        
        public virtual ICollection<Enemy>? Enemies { get; set; }
        public bool isBossPending { get; set; }
        public bool HasActiveBoss { get; set; }
        //events
    }
}
