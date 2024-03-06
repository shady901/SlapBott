using SlapBott.Data.Models;
using SlapBott.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Implmentations
{
    public class PlayerCharacterService : CharacterService, IPlayerCharacterCreation
    {




        public string CreateCharacter(ulong DiscordID)
        {
            base.Create(new PlayerCharacter()
            {

            });
        }
    }


    public class CharacterService
    {

        public string Create<T>(T character) where T: Character
        {

        }
    }

}
