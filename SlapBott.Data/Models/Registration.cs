using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class Registration
    {

        public int Id { get; set; } 
        public required ulong DiscordId { get; set; }
        public required string UserName { get; set; }

        public virtual List<Character> UserCharacters { get; set; } = new List<Character>();
        public int ActiveCharacter { get; set; }

        [ForeignKey ("ActiveCharacter")]
        public virtual Character? Character { get; set; }


    }
}
