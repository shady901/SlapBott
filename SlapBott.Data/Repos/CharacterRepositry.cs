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
        public async Task<PlayerCharacter> GetTempPlayerCharacterByDiscordID(ulong id, int regId)
        {
            PlayerCharacter? playerCharacter = null;
            try
            {
                if (id > 0 & regId >0)
                {
                    playerCharacter = await _dbContext.PlayerCharacter
                  .Where(pc => pc.DiscordId == id && pc.IsTemp && pc.RegistrationId == regId)
                  .Include(pc => pc.Character.Stats)
                  .Include(pc => pc.Character.Race)
                  .Include(pc => pc.Character.CharacterClass)
                  .Include(pc => pc.Character.Inventory)
                  .FirstOrDefaultAsync();
                }
               
            }catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
            }

            return playerCharacter ?? new PlayerCharacter() {Character = new() {Stats= new(),Inventory = new() {Equiped = new(),Bag = new()} }, DiscordId = id, RegistrationId = regId};
        }
        public async Task<PlayerCharacter> GetPlayerCharacterByPlayerCharacterId(int id)
        {
            PlayerCharacter? playerCharacter = null;
            try
            {
                if (id > 0 )
                {
                    playerCharacter = await _dbContext.PlayerCharacter
                  .Where(pc => pc.Id == id)
                  .Include(pc => pc.Character.Stats)
                  .Include(pc => pc.Character.Race)
                  .Include(pc => pc.Character.CharacterClass)
                  .Include(pc => pc.Character.Inventory)
                  .FirstOrDefaultAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return playerCharacter ?? new PlayerCharacter() { Character = new() { Stats = new(), Inventory = new() { Equiped = new(), Bag = new() } }};
        }
        public async Task<PlayerCharacter> GetPlayerCharacterByDiscordID(ulong id, int regId)
        {

            PlayerCharacter? Character = await _dbContext.PlayerCharacter
                    .Where(pc => pc.DiscordId == id && pc.RegistrationId == regId)
                    .Include(pc => pc.Character.Stats)
                    .Include(pc => pc.Character.Race)
                    .Include(pc => pc.Character.CharacterClass)
                    .Include(pc => pc.Character.Inventory)
                    .FirstOrDefaultAsync();

            return Character ?? new PlayerCharacter() { Character = new() { Stats = new(), Inventory = new() { Equiped = new(), Bag = new() } }, DiscordId = id, RegistrationId = regId };
        }
        public PlayerCharacter SaveCharacter(PlayerCharacter playerCharacter)
        {
            AddOrUpdateCharacter(playerCharacter);
            _dbContext.SaveChanges();
            return playerCharacter;
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
