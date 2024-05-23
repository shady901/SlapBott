using MediatR;
using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Dtos;

namespace SlapBott.Services.Implmentations
{
    public class RegistrationService
    {

        private RegistrationRepositry? _registrationRepositry { get; set; }
        public RegistrationService(RegistrationRepositry repo)
        {
            _registrationRepositry = repo;
            //_mediator = mediator;
        }


        public string RegisterUser(ulong discordUserID, string username, int attempts = 0)
        {

            string msg = "U Already Have A Registered Account";

            if (!CheckIfPlayerExists(discordUserID))
            {

                try
                {
                    SaveRegistration(new Registration
                    {
                        UserName = username,
                        DiscordId = discordUserID,
                    });
                    msg = "U have joined the Cause";
                    //_mediator.Publish(new NewRegistration() { Name = username });
                }
                catch (Exception ex)
                {
                    msg = $"There was an problem saving registration: {ex.Message}";
                }


            }


            return msg;
        }



        public void SaveRegistration(Registration p)
        {
          
            _registrationRepositry.SaveRegistration(p);
        }



        //checks if player exists within the DB based on a ulong Discord id that is gotten when a command called from discord 
        //players are shared across discord servers, and not tied to per server
        /// <summary>
        /// returns if player DiscordID exists within the DB 
        /// </summary>
        /// <returns></returns>
        public bool CheckIfPlayerExists(ulong discordUserId)
        {

            var reg = GetUserByDiscordId(discordUserId);


            return reg is null ? false : true ;
        }

        public Registration GetUserByDiscordId(ulong discordUserID)
        {
            return _registrationRepositry.GetByDiscordID(discordUserID);
        }


        public int? GetActiveCharacterId(ulong discordUserID)
        {
            return GetUserByDiscordId(discordUserID).ActiveCharacterId;

        }

        public int? GetActiveTempCharacterId(ulong discordUserID)
        {
            return GetUserByDiscordId(discordUserID).PlayerCharacters.First(x=>x.IsTemp)?.Id;
            
        }
        public bool CharacterLimitReachedByDiscordId(ulong DiscordId)
        { 
           int MyCount =  GetUserByDiscordId(DiscordId).PlayerCharacters.Where(x=>!x.IsTemp).Count();
           return MyCount >= 5;
        }


    }
}
