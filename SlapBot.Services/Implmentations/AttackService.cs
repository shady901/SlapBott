

using MediatR;
using SlapBott.Services;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;

namespace SlapBott.Services.Implmentations
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
        public string AssignAttack(PlayerCharacterDto userActiveChar, ulong channelID,string? playerInput = null)
        {
            string msg = "Somthing Went Wrong";
            var (raid, skill, Target) = ParameterManager(playerInput);
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
                _raidService.SetupState(channelID);
                if (!_raidService.IsValidTarget(Target))
                {
                    return "This is not a suitible target";
                }
                var d = userActiveChar.GetBySkill(skill);
                return _raidService.AttackRaid(userActiveChar, d, _raidService.GetEnemyIdByTarget(Target));
            }
            return msg;

        }


        // /attack :fireball
        // /attack raid :fireball
        // /attack raid "target" :fireball
       
        private (string, string, string) ParameterManager(string input)
        {
            if (input is null || input.Trim().Length == 0)
            {
                return (string.Empty, string.Empty, string.Empty);
            }



            string[] temp = input.Trim().ToLower().Split(' ',':');
            var raid = string.Empty;
            var skill = temp[2];
            var target = temp[0];
            if (target == VerifyAttackOptions.Raid.ToString().ToLower())
            {
                raid = target;

            }
           
            target = temp.Length > 1 ? temp[1] : target;

            return (raid, skill, target);
        }

    }


}