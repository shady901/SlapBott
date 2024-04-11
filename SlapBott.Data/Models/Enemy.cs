using SlapBott.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Enemy : IAmEnemy
    {

        public int Id { get; set; }
        public int CharacterId { get; set; }

        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }

    }




}
