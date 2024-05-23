using SlapBott.Data.Models;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class RegistrationDto
    {

        public int Id { get; set; }
        public ulong discordUserID { get; set; }
        public string UserName { get; set; }

        public List<PlayerCharacter> PlayerCharacters { get; set; } = new List<PlayerCharacter>();
        public int? ActiveCharacterId { get; set; }

        public PlayerCharacter? Character { get; set; }


        public RegistrationDto()
        { }


        public static RegistrationDto FromUserDB(Registration user)
        {
            return new RegistrationDto
            {
                Id = user.Id,
                discordUserID = user.DiscordId,
                UserName = user.UserName,
                Character = user.Character,
                ActiveCharacterId = user.ActiveCharacterId,
                PlayerCharacters = user.PlayerCharacters,

            };
            
        }


       
        /// <summary>
        /// Converts PlayerDto back to Player object
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Registration ToRegistration(Registration? p = null)
        {
            if (p == null)
            {
                p = new Registration();
            }
           
            p.DiscordId = discordUserID;
            p.PlayerCharacters = PlayerCharacters;
            p.Character = Character;
            p.ActiveCharacterId = ActiveCharacterId;
            p.UserName = UserName;
            return p;
        }
    }
}
