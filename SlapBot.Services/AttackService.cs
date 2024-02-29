

using MediatR;
using SlapBot.Services;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;

namespace SlapBott.Services
{
    public enum VerifyAttackOptions
    {
        None,
        Raid
    }
    public class AttackService
    {
        private IRaidService _raidService;

        //        private readonly IMediator _mediator;

        public AttackService(IRaidService raidService)
        {

            _raidService = raidService;

            //_mediator = mediator;
        }




        // this assigns an attack type based on player input being "/Attack Raid" "/Attack" if not specified we need to store current target
        public string AssignAttack(CharacterDto userActiveChar, string? playerInput = null)
        {
            string msg = "Somthing Went Wrong";
            var (raid, skill) = ParameterManager(playerInput);
            //if skill is not null get the skill from player and if it does exists return

            if (userActiveChar.GetBySkill(skill) is null)
            {
                if (skill == string.Empty)
                {
                    return "Please Specify the Skill you want to Use";
                }
                return $"You do not Have {skill} Skill";
            }
            //if raid do method and return a string replying attacking raid, when raid attack has completed reply to player with results using the hidden message feature 
            if (VerifyAttackOptions.Raid.ToString().ToLower() == raid)
            {
                var d = userActiveChar.GetBySkill(skill);
                return _raidService.AttackRaid(userActiveChar, d);
            }
            return msg;



        }



        private (string, string) ParameterManager(string input)
        {
            if (input is null || input.Trim().Length == 0)
            {
                return (string.Empty, string.Empty);
            }



            string[] temp = input.Trim().ToLower().Split(' ');
            var raid = string.Empty;
            var skill = temp[0];
            if (skill == VerifyAttackOptions.Raid.ToString().ToLower())
            {
                raid = skill;

            }
            skill = (temp.Length > 1) ? temp[1] : skill;

            return (raid, skill);
        }

    }


}