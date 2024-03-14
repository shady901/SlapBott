using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlapBott.Data.Contracts;


namespace SlapBott.Data.Models
{
    public class PlayerCharacter :  IAmPlayerCharacter
    {

        public int Id { get; set; }
        public bool HasLeveled { get; set; }    

        public ulong DiscordId { get; set; }


        public int RegistrationId { get; set; }    
        public int CharacterId { get; set; }
        public bool IsTemp { get; set; } = true;

        public Race? Race { get; set; }
        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }

        [ForeignKey("RegistrationId")]
        public virtual Registration Registration { get; set; }  


    }
}
