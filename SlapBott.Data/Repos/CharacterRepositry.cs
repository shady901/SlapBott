using SlapBott.Data;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public class CharacterRepositry
    {
        private SlapbottDbContext _dbContext { get; set; }

        public CharacterRepositry(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }
        public Character GetByCharacterID(int Id)
        {

            Character Character = _dbContext.Character.First(Character => Character.Id == Id);

            return Character;
        }


    }
}
