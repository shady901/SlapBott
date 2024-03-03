using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Enemy
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Stats Stats { get; set; }
        public CombatStats CStats { get; set; }

        public Dictionary<string, Skill> Skills { get; set; }
    //    public Dictionary<string, Effects> Effects { get; set; }

    }
    public class WarriorSkills
    {
        public const string Slash = "slash";
    }

    public class MageSkills
    {
        public const string FireBall = "fireball";
    }



}
