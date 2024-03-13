using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class Registration
    {

        public int Id { get; set; } 
        public required ulong DiscordId { get; set; }
        public required string UserName { get; set; }

        public virtual List<PlayerCharacter> PlayerCharacters { get; set; } = new List<PlayerCharacter>();
        public int ActiveCharacterId { get; set; }
        public int TemporaryCharacterId { get; set; }

        [ForeignKey ("ActiveCharacterId")]
        public virtual Character? Character { get; set; }

        [ForeignKey("TemporaryCharacterId")]
        public virtual TempCharacter TempCharacter { get; set; }


    }
}
