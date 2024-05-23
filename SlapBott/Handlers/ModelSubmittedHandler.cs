using Discord;
using Discord.WebSocket;
using MediatR;
using SlapBott.Enums;
using SlapBott.Notifications;
using SlapBott.Requests;
using SlapBott.Services.Dtos;


namespace SlapBott.Handlers
{
    public class ModelSubmittedHandler(IMediator mediator): INotificationHandler<ModelSubmitted>
    {
        private readonly IMediator _mediator = mediator;

        public async Task Handle(ModelSubmitted notification, CancellationToken cancellationToken)
        {

            var modal = notification.Modal;
            var userId = modal.User.Id;
          
          
            ModalSubmittedCommands condition;
            Enum.TryParse(modal.Data.CustomId, out condition);


            var registration = await _mediator.Send(new GetRegistration(userId));
            if (registration == null)
            {
                await modal.RespondAsync("you have not joined the bot");
                return;
            }

            PlayerCharacterDto? playercharacter = await _mediator.Send(new RequestGetExistingCharacterOrNew(userId), cancellationToken);

            if (modal.Data.CustomId == null)
            {
                await modal.RespondAsync("ERROR: ModalHandler CustomId Is NUll");
            }

            switch (condition)
            {
                case ModalSubmittedCommands.NameAndDescription:

                    playercharacter = await _mediator.Send(new UpdateNameAndDescriptionPlayerCharacter(playercharacter, modal.Data.Components), cancellationToken);
                   playercharacter = await _mediator.Send(new RequestSavePlayerCharacterDto(playercharacter));
                    registration.ActiveCharacterId = playercharacter.Id;
                    await _mediator.Send(new SaveRegistrationRequest(registration));
                    await modal.RespondAsync(embed:BuilderReplies.ReplyCreatedCompleteEmbed(playercharacter.Name,playercharacter.Description,playercharacter.SelectedRace.ToString(),playercharacter.SelectedClass.ToString()));
                    break;
                default:
                    await modal.RespondAsync("ERROR: ModalHandler couldnt find customID");
                    break;
            }


        }
           
    }


}
