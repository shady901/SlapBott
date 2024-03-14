using SlapBott.Data.Models;


namespace SlapBott.Data.Repos
{
    public class PlayerCharacterRepositry
    {
        private SlapbottDbContext _dbContext { get; set; }

        public PlayerCharacterRepositry(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }
        public PlayerCharacter GetPlayerCharacterByDiscordID(ulong id)
        {

            PlayerCharacter Character = _dbContext.PlayerCharacter.FirstOrDefault(PCharacter => PCharacter.DiscordId == id);
           
            return Character ?? new PlayerCharacter() {Character = new() };
        }


    }
}
