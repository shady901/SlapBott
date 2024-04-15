using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
using System.Security.Cryptography;
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
        private RegionService _regionService;
        private EnemyService _enemyService;
        public RaidService(CombatManager combatManager, RegionService regionService, EnemyService enemyService)
        {
            _enemyService = enemyService;
            _regionService = regionService;
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


        public string AttackRaid(PlayerCharacterDto characterDto, SkillDto skill, int Target)
        {
            //EnemyDto myTarget = _enemyService.GetEnemyByID(GetEnemyIDByTarget(Target));
            // _combatManager.PlayerTurn(characterDto, skill, myTarget);
            // _combatManager.SaveState();



            return "this is my raid results";



        }
        public void BossAttack()
        {



        }

        public int GetEnemyIdByTarget(string target)
        {

            return _combatManager.GetEnemyIDByTarget(target);
        }

        public RaidBossDto RaidCheck(object? state)
        {
            Dictionary<Regions, RegionDto> regionDic = _regionService.GetAllRegionsAsDictionary();
            RegionDto? pendingRegion = regionDic.FirstOrDefault(x => x.Value.isBossPending).Value;
            if (_regionService.GetRegionWithRaidBoss() != null)
            {
                GenerateRaidBoss();
            }
            if (pendingRegion != null&&pendingRegion.RaidBossId!=null)
            {
                pendingRegion.isBossPending = false;
                
                RaidBossDto myraid =_enemyService.GetEnemyTargetByID<RaidBossDto>((int)pendingRegion.RaidBossId);
                myraid.SetupPlayerCountStats(_combatManager.GetStateById(myraid.StateId).Characters.Count); // calls setupPcount with state characters count (multiplies raid for player count)
                return myraid;
                //PostRaid (WithAttackButton/Flee/UseItem)
                //(reminder) Manage Buttons
            }
            //Check if one is about to happen else do nothing       
            return new RaidBossDto();
        }

        private void GenerateRaidBoss()
        {
            Random rnd = new Random();
            RegionDto region = _regionService.GetRegionByRegionEnum((Regions)rnd.Next(1, Enum.GetValues(typeof(Regions)).Length + 1));
            RaidBossDto raidBoss = _enemyService.GenerateNewRaidBoss();
            region.isBossPending = true;
            _enemyService.SaveRaidBoss(raidBoss, region);

        }
        private void ApplyPlayerCountStats()
        { 
            
        }

        
    }
}
