//using Discord.Interactions;
//using InteractionFramework;
//using SlapBott.Data.Models;
//using SlapBott.Services.Dtos;
//using SlapBott.Services.Implmentations;


//namespace SlapBott.Commands
//{

//    public class Attack : InteractionModuleBase<SocketInteractionContext>
//    {

//        private readonly RegistrationService _registrationService;
//        private readonly AttackService _attackService;
//        private InteractionHandler _handler;
//        private CharacterService _characterService;
//        public InteractionService Commands { get; set; }
//        // Constructor injection is also a valid way to access the dependencies
//        public Attack(InteractionHandler handler, RegistrationService registrationService, AttackService attackService, CharacterService characterService)
//        {
//            _handler = handler;
//            _registrationService = registrationService;
//            _attackService = attackService;
//            _characterService = characterService;
//            //_mediator = mediator;
//        }




//        [SlashCommand("Attack", "Choose what you want to attack",ignoreGroupNames:false,runMode:RunMode.Async)]
//        public async Task AttackAsync(string? input = null)
//        {
           
//            var userid = Context.User.Id;
//            var userName = Context.User.Username;
//            CharacterDto characterDto = new CharacterDto { Stats = new Stats() };
//            characterDto = characterDto.FromCharacter(_characterService.GetCharacterByID(_registrationService.GetActiveCharacter(userid)));

//            string msg = _attackService.AssignAttack(characterDto, Context.Channel.Id, input );

//            try
//            {
//                await RespondAsync(msg);
//            }
//            catch (Exception ex)
//            {

//            }
//        }

//    }
//}

