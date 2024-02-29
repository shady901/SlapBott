
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class Character
    {

        public int Id { get; set; }
        public int DiscordID { get; set; }
        public Stats Stats { get; set; }
        public CombatStats CStats;
        
        [ForeignKey("DiscordID")]
        public virtual Registration Registration { get; set; }

        public Character()
        {           
            
        }

        



    }
}
