using SlapBott.Data.Models;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class RegistrationDto
    {

        public int? Id { get; set; }
        public required ulong discordUserID { get; set; }


        public RegistrationDto()
        { }


        public static RegistrationDto FromUserDB(Registration user)
        {
            return new RegistrationDto
            {
                Id = user.Id,
                discordUserID = user.DiscordId,

            };
            
        }


       
        /// <summary>
        /// Converts PlayerDto back to Player object
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Registration ToUser(Registration? p = null)
        {
           
            p.DiscordId = discordUserID;
           
            return p;
        }
    }
}
