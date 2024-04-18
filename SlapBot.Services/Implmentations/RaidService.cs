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

        public void RaidCheck()
        {
            Dictionary<Regions, RegionDto> regionDic = _regionService.GetAllRegionsWithEnemiesAsDictionary();
            RegionDto? pendingRegion = regionDic.FirstOrDefault(x => x.Value.isBossPending && x.Value.HasActiveBoss == false).Value;
                        
            //getallregions without an active raid boss
            //generate one, assign region as pending to give time to sign up to boss
            if ( regionDic.Where(x=>x.Value.HasActiveBoss == false && x.Value.isBossPending == false) != null)
            {
                GenerateRaidBoss();
            }

            //then check if a region currently has pending, then display rb to server and set as not 










            if (pendingRegion != null)
            {
                RaidBoss temp = (RaidBoss)pendingRegion.Enemies.First(x => !x.IsDead && x.GetType().Equals(typeof( RaidBoss)));
                pendingRegion.isBossPending = false;
                pendingRegion.HasActiveBoss = true;
                RaidBossDto myraid = RaidBossDto.FromRecord(temp);
                myraid.SetupPlayerCountStats(_combatManager.GetStateById(myraid.StateId).Characters.Count); // calls setupPcount with state characters count (multiplies raid for player count)
                _enemyService.SaveRaidBoss(myraid,temp);
                _regionService.SaveRegion(pendingRegion);
                //PostRaid (WithAttackButton/Flee/UseItem)
                //(reminder) Manage Buttons
            }
            //Check if one is about to happen else do nothing       
           
        }

        private RaidBossDto GenerateRaidBoss()
        {
            Random rnd = new Random();
            RegionDto region = _regionService.GetRegionByRegionEnum((Regions)rnd.Next(1, Enum.GetValues(typeof(Regions)).Length + 1));
            RaidBossDto raidBoss = _enemyService.GenerateNewRaidBoss();
            _regionService.SaveAndSetRegionBossToPending(region);
            raidBoss.RegionId = region.Id;
            var raidboss = _enemyService.SaveRaidBoss(raidBoss);          
       
            return raidBoss;
        }
       

        
    }
}
