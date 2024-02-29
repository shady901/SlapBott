using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Models;
using Slappbott.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var user = _dbContext.User.FirstOrDefault(User => User.DiscordId == discordId);

            return user;
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
