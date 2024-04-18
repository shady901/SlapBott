using SlapBott.Services.Combat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public class PlayerStateRepo : Repo<PlayerCharacterCombatState>
    {
        public PlayerStateRepo(SlapbottDbContext dBContext) : base(dBContext)
        {
        }

        public PlayerCharacterCombatState SaveState(PlayerCharacterCombatState playerCombatState)
        {
            return AddOrUpdateEntity(playerCombatState);
        }
    }
}
