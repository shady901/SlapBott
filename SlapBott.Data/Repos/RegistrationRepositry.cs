using SlapBott.Data.Models;

namespace SlapBott.Data.Repos
{
    public class RegistrationRepositry
    {
        private SlapbottDbContext _dbContext { get; set; }

        public RegistrationRepositry(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }


        
        public Registration GetByDiscordID(ulong discordId)
        {

            //nnjmjm1var user = _dbContext.User.FirstOrDefault(User => User.DiscordId == discordId);

            return _dbContext.User.FirstOrDefault(user =>user.DiscordId == discordId);
        }

        public void SaveRegistration(Registration reg)
        {
            AddOrUpdateRegistration(reg);
            _dbContext.SaveChanges();
        }
        public void AddOrUpdateRegistration(Registration reg)
        {
            var meth = _dbContext.User.Update;


            if (reg.DiscordId <= 0) // not in the database
            {
                meth = _dbContext.User.Add;
            }

            meth(reg);

        }


    }
}
