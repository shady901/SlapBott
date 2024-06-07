using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class BaseEnemy
    {
        public int Id { get; set; }
        //enemy type as "Skeleton, Dragon Ect" 
        public EnemyTypes EnemyType { get; set; }
        public List<Material>? Materials { get; set; }


    }
}
