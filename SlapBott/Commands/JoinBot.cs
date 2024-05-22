namespace SlapBott.Core.Commands
{
    using Discord;
    using Discord.Interactions;
    using InteractionFramework;
    using MediatR;
    using SlapBott.Data.Enums;
    using SlapBott.Services.Implmentations;
    using SlapBott.Services.Notifactions;
    using System;
    using System.Data;
    using System.Reflection.Metadata;

    public class JoinBot : InteractionModuleBase<SocketInteractionContext>
    {
       
        private readonly RegistrationService _registrationService;
        
        private InteractionHandler _handler;
        public InteractionService Commands { get; set; }
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
         
           
          
            string roleName = DiscordRole.SlapBottParticipant.ToString();
            IRole? existingRole = Context.Guild.Roles.FirstOrDefault(r => r.Name == roleName);
            if (existingRole == null)
            {
                existingRole = await Context.Guild.CreateRoleAsync(roleName);
            }
            var user = Context.Guild.GetUser(userid);
            if (user == null)
            {
                Console.WriteLine("User not found Cannot Add Role");
               
            }
            await user.AddRoleAsync(existingRole);
            // Assign the role to the user



            string msg = _registrationService.RegisterUser(userid, userName);

            try
            {
                 await RespondAsync(msg);
            }catch (Exception ex)
            {
                    Console.WriteLine(ex.Message);
            }


        }

       


    }

}