using SlapBott.Data.Models;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;

namespace SlapBot.Services
{
    public class RaidService :IRaidService
    {

        public RaidService() 
        {

        }
       


        public string JoinRaid(ulong userId, ulong channelId)
        {


           return "You have joined the raid";
        }


        public string AttackRaid(CharacterDto characterDto, Skill skill)
        {
            return "this is my raid results";
        
        
        
        }
    }
}
