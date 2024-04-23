using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;

namespace SlapBott.Services.Implmentations
{
    public class PlayerCharacterService
    {


        private PlayerCharacterRepositry? _playerCharacterRepositry { get; set; }
      
        public PlayerCharacterService(PlayerCharacterRepositry repo)
        {
            _playerCharacterRepositry = repo;
            //_mediator = mediator;
        }

        public async Task<PlayerCharacter> GetTempPlayerCharacterByDiscordIdOrNew(ulong id, int regId)
        {
            return await _playerCharacterRepositry.GetTempPlayerCharacterByDiscordID(id,regId);
        }

        public void SaveCharacter(PlayerCharacterDto p)
        {

            PlayerCharacter player = _playerCharacterRepositry.GetPlayerCharacterByDiscordID(p.DiscordId,p.regId);

          
            _playerCharacterRepositry.SaveCharacter(p.ToCharacter(player));
        }
    }



}
