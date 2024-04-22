using Discord;
using Discord.WebSocket;
using MediatR;
using SlapBott.Commands;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Enums;
using SlapBott.Notifications;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;


namespace SlapBott.Handlers
{
    internal class SelectMenuSubmittedHandler(IMediator mediator, RegistrationService r) 
        : BaseNotificationHandler(r) 
        , INotificationHandler<SelectMenuExecuted>
    {
        private readonly IMediator _mediator = mediator;

        public async Task Handle(SelectMenuExecuted notification, CancellationToken cancellationToken)
        {
            var a = notification.Component;
            SelectMenuCommands condition;
            Enum.TryParse(a.Data.CustomId, out condition);
         

            if (!await CheckRegistation(a.User.Id))
            {
                await a.RespondAsync("you have not joined the bot");
                return;
            };



           // SetupBaseCharacterDto(arg.User.Id);


            switch (condition)
            {
                case SelectMenuCommands.AssigningRace:
                    _mediator.Publish(new AssigningRace(a));
                    
                    break;
                case SelectMenuCommands.AssignClass:
                    //AssigningClass(arg);
                    break;
                default:
                    break;
            }



        }

       
    }



    


   

}
