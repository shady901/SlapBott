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
    public class SelectMenuSubmittedHandler(IMediator mediator, RegistrationService r) 
        : BaseNotificationHandler(r) 
        , INotificationHandler<SelectMenuExecuted>
    {
        private readonly IMediator _mediator = mediator;

        public async Task Handle(SelectMenuExecuted notification, CancellationToken cancellationToken)
        {
            var component = notification.Component;
            SelectMenuCommands condition;
            Enum.TryParse(component.Data.CustomId, out condition);
         

            if (!await CheckRegistation(component.User.Id))
            {
                await component.RespondAsync("You have not joined the bot");
                return;
            };



           // SetupBaseCharacterDto(arg.User.Id);


            switch (condition)
            {
                case SelectMenuCommands.AssigningRace:
                  await _mediator.Publish(new AssignRaceNotification(component));
                    
                    break;
                case SelectMenuCommands.AssignClass:
                    await _mediator.Publish(new AssignClassNotification(component));
                    break;
                case SelectMenuCommands.UseSkill:
                    await _mediator.Publish(new SelectMenuUsedSkillNotification(component));
                    break;
                default:
                    break;
            }



        }

       
    }



    


   

}
