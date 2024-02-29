using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services
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
