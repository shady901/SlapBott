using MediatR;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
using SlapBott.Services.Notifactions;
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
        private CombatStateService _combatStateService;
        private IMediator _mediator;
        public RaidService(CombatManager combatManager, RegionService regionService, EnemyService enemyService, CombatStateService combatStateService, IMediator mediator)
        {
            _mediator = mediator;
            _enemyService = enemyService;
            _regionService = regionService;
            _combatManager = combatManager;
            _combatStateService = combatStateService;
        }



        public string JoinRaid(ulong userId, ulong channelId)
        {


            return "You have joined the raid";
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

       

        public async void RaidCheck(object? state)
        {


            Dictionary<Regions, RegionDto> regionDic = _regionService.GetAllRegionsWithEnemiesAsDictionary();
            RegionDto? pendingRegion = regionDic.FirstOrDefault(x => x.Value.isBossPending && x.Value.HasActiveBoss == false).Value;
            var a = regionDic.Where(x => x.Value.HasActiveBoss == false && x.Value.isBossPending == false).FirstOrDefault().Value;
            //getallregions without an active raid boss
            //generate one, assign region as pending to give time to sign up to boss
            if (a != null)
            {
               await GenerateRaidBoss(a.RegionName);
            }

            //then check if a region currently has pending, then display rb to server and set as not 


            //if (pendingRegion != null)
            //{
            //    RaidBoss temp = (RaidBoss)pendingRegion.Enemies.First(x => !x.IsDead && x.GetType().Equals(typeof( RaidBoss)));
            //    pendingRegion.isBossPending = false;
            //    pendingRegion.HasActiveBoss = true;
            //    RaidBossDto myraid = RaidBossDto.FromRecord(temp);
            //    myraid.SetupPlayerCountStats(_combatStateService.GetCombatStateByIdOrNew(myraid.StateId).Characters.Count); // calls setupPcount with state characters count (multiplies raid for player count)
            //    _enemyService.SaveRaidBoss(myraid,temp);
            //    _regionService.SaveRegion(pendingRegion);


            //  await  _mediator.Send(new PostRaidNotification(myraid, pendingRegion.RegionName));
                
            //}
          
           
        }

        private async Task GenerateRaidBoss(Regions regionName)
        {

            RegionDto region = _regionService.GetRegionByRegionEnum(regionName);
            RaidBossDto raidBoss = _enemyService.GenerateNewRaidBoss();
            var state = _combatStateService.GetCombatStateByIdOrNew(0);
            var stateId = _combatStateService.SaveState(state).Id;
            _regionService.SaveAndSetRegionToPending(region);
            raidBoss.RegionId = region.Id;
            raidBoss.StateId = stateId;
            var raidBossId = _enemyService.SaveRaidBoss(raidBoss).Id;
            await EnemyCombatStateAssignAndSave(stateId, raidBossId);

        }
        private async Task EnemyCombatStateAssignAndSave(int stateId,int EnemyId)
        {

            EnemyCombatStateDto state = _combatStateService.GetEnemyStateByIdOrNew(stateId);
            state.IsActive = true;
            state.CombatStateId = stateId;
            state.ParticipantId = EnemyId;
            state.HadTurn = false;
            _combatStateService.SaveEnemyCombatState(state);
            await Task.CompletedTask;  
        }

       
    }
}
