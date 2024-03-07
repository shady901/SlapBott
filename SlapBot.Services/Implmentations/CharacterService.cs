using SlapBott.Data.Models;
using SlapBott.Data.Repos;


namespace SlapBott.Services.Implmentations
{
    public class CharacterService
    {

        private CharacterRepositry? _characterRepositry { get; set; }
        public CharacterService(CharacterRepositry repo)
        {
            _characterRepositry = repo;
            //_mediator = mediator;
        }

        public Character GetCharacterByID(int id)
        {


            return _characterRepositry.GetByCharacterID(id);
        }

      
    }
}
