using SlapBott.Data.Models;


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

            Character Character = null; // _dbContext.Character.First(Character => Character.Id == Id);

            return Character;
        }


    }
}
