using SlapBott.Data.Models;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
using System.Threading.Channels;
/*
           Get all Characters Participating
           foreach add exp to characters
           if leveled add to list for charctermangers
           */
namespace SlapBott.Services.Implmentations
{
    public class RaidService : IRaidService
    {
        private CombatManager _combatManager;
        public RaidService(CombatManager combatManager)
        {
            _combatManager = combatManager;
        }



        public string JoinRaid(ulong userId, ulong channelId)
        {


            return "You have joined the raid";
        }
        public bool IsValidTarget(string target) 
        {
            
           
            if (Convert.ToInt32(target) >= _combatManager.GetEnemyIDs().Count())
            {
            return true;
            }
        
            return false; 
        }
        public void SetupState(ulong channelID)
        {
            _combatManager.GetStateByChannelId(channelID);
        }


        public string AttackRaid(CharacterDto characterDto, Skill skill,int Target)
        {
           EnemyDto myTarget = _enemyService.GetEnemyByID(GetEnemyIDByTarget(Target));
            _combatManager.PlayerTurn(characterDto, skill, myTarget);
            _combatManager.SaveState();
            


            return "this is my raid results";



        }
        public void BossAttack()
        {
            
            //get play

        }

        public int GetEnemyIdByTarget(string target)
        {

            return _combatManager.GetEnemyIDByTarget(target);
        }
    }
}
