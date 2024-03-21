using Microsoft.EntityFrameworkCore;
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
        public PlayerCharacter GetTempPlayerCharacterByDiscordID(ulong id, int regId)
        {

            PlayerCharacter playerCharacter = _dbContext.PlayerCharacter
                .Where(pc => pc.DiscordId == id && pc.IsTemp && pc.RegistrationId == regId)
                .Include(pc => pc.Character.Stats)
                .Include(pc => pc.Character.Race)
                .Include(pc => pc.Character.CharacterClass)
                .Include (pc => pc.Character.LearnedSkill)
                .FirstOrDefault();

            return playerCharacter ?? new PlayerCharacter() {Character = new() {Stats= new(),Inventory = new() {Equiped = new()} }, DiscordId = id, RegistrationId = regId};
        }
        public PlayerCharacter GetPlayerCharacterByDiscordID(ulong id, int regId)
        {

            PlayerCharacter Character = _dbContext.PlayerCharacter.FirstOrDefault(PCharacter => PCharacter.DiscordId == id && PCharacter.RegistrationId == regId);

            return Character ?? new PlayerCharacter() { Character = new(), DiscordId = id };
        }
        public void SaveCharacter(PlayerCharacter playerCharacter)
        {
            AddOrUpdateCharacter(playerCharacter);
            _dbContext.SaveChanges();

        }
     
        public void AddOrUpdateCharacter(PlayerCharacter c)
        {
            var meth = _dbContext.PlayerCharacter.Update;


            if (c.CharacterId <= 0) // not in the database
            {
                meth = _dbContext.PlayerCharacter.Add;
            }

            meth(c);

        }

    }
}
