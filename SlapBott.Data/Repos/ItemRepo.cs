using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public class ItemRepo<Tout> : Repo<Tout> where Tout : Item
    {
        public ItemRepo(SlapbottDbContext dBContext) : base(dBContext)
        {

        }
    }
}
