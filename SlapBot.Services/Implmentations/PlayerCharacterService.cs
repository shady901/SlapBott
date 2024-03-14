using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Contracts;

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

        public PlayerCharacter GetPlayerCharacterByDiscordIdOrNew(ulong id)
        {
            return _playerCharacterRepositry.GetPlayerCharacterByDiscordID(id);
        }
        
        public string CreateCharacter(ulong DiscordID)
        {
            return null;
        }
       
    }



}
