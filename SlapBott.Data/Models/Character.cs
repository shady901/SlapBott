
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class Character
    {

        public int Id { get; set; }
        public int DiscordID { get; set; }

        public Stats stats;

        [ForeignKey("DiscordID")]
        public virtual Registration Registration { get; set; }

        public Character()
        { 
            
        }




    }
}
