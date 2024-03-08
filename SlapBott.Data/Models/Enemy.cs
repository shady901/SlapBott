using SlapBott.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Enemy : IAmEnemy
    {


       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ulong CharExp { get; set; }
        public int level => (int)(450 + Math.Sqrt(202500 + 1800 * CharExp)) / 900;
        //public List<Ailments> ailments { get; set; }
        //public List<Buff> Buffs { get; set; }
        public Stats Stats;
        public Inventory Inventory;
        public SubClass CharacterClass { get; set; }



    }




}
