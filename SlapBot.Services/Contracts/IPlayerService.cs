using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Contracts
{
    public interface IPlayerService
    {

       string JoinBot(ulong discordUserID);
     
       void SaveNewPlayer(RegistrationDto p);

       bool CheckIfPlayerExists(ulong discordUserId);

    }
}
