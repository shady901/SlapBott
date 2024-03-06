using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Contracts
{
    public interface IPlayerCharacterCreation
    {

       string CreateCharacter(ulong DiscordID);

    }
}
