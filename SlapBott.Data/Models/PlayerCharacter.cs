using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlapBott.Data.Contracts;


namespace SlapBott.Data.Models
{
    public class PlayerCharacter : Character, IAmPlayerCharacter
    {
        [ForeignKey("DiscordID")]
        public virtual Registration Registration { get; set; }

        public int DiscordID { get; set; }
       
    }
}
