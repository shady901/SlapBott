using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public class RaceRepo
    {
        private SlapbottDbContext _dbContext { get; set; }

        public RaceRepo(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }
    }
}
