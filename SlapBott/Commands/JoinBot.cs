namespace SlapBott.Core.Commands
{


    using Discord.Interactions;
    using InteractionFramework;
    using MediatR;
    using SlapBott.Services.Implmentations;
    using SlapBott.Services.Notifactions;
    using System.Reflection.Metadata;

    public class JoinBot : InteractionModuleBase<SocketInteractionContext>
    {
        // Dependencies can be accessed through Property injection, public properties with public setters will be set by the service provider
       
        private readonly RegistrationService _registrationService;
        
        private InteractionHandler _handler;
        public InteractionService Commands { get; set; }
        // Constructor injection is also a valid way to access the dependencies
        public JoinBot(InteractionHandler handler, RegistrationService registrationService)
        {
            _handler = handler;
            _registrationService = registrationService;
            //_mediator = mediator;
        }




        [SlashCommand("joinbot", description : "This Joins The BOT", ignoreGroupNames : false, runMode : RunMode.Async)]
        public async Task JoinBotAsync()
        {
            var userid = Context.User.Id;
            var userName = Context.User.Username;
         
            string msg = _registrationService.RegisterUser(userid, userName);

            try
            {
                 await RespondAsync(msg);
            }catch (Exception ex)
            {
        
            }


        }

       


    }

}