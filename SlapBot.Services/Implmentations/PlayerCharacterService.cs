using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Contracts;

namespace SlapBott.Services.Implmentations
{
    public class PlayerCharacterService
    {


        private CharacterRepositry? _characterRepositry { get; set; }
        public PlayerCharacterService(CharacterRepositry repo)
        {
            _characterRepositry = repo;
            //_mediator = mediator;
        }

        public Character GetCharacterByID(int id)
        {
            return _characterRepositry.GetByCharacterID(id);
        }

        public string CreateCharacter(ulong DiscordID)
        {
            return null;
        }
       
    }


    //public class CharacterService
    //{

    //    public string Create<T>(T character) where T: Character
    //    {

    //    }
    //}

}
