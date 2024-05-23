using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class Registration
    {

        public int Id { get; set; } 
        public ulong DiscordId { get; set; }
        public string? UserName { get; set; }

        public virtual List<PlayerCharacter> PlayerCharacters { get; set; } = new List<PlayerCharacter>();
        public int? ActiveCharacterId { get; set; }

        [ForeignKey ("ActiveCharacterId")]

        public virtual PlayerCharacter? Character { get; set; }

        

    }
}
