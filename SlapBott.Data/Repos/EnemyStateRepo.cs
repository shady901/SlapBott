using SlapBott.Services.Combat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public class EnemyStateRepo : Repo<EnemyCombatState>
    {
        public EnemyStateRepo(SlapbottDbContext dBContext) : base(dBContext)
        {
        }

        public EnemyCombatState SaveState(EnemyCombatState enemyCombatState)
        {
          return AddOrUpdateEntity(enemyCombatState);
        }
    }
}
