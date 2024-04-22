using Discord;
using Discord.WebSocket;
using MediatR;
using SlapBott.Enums;
using SlapBott.Notifications;
using SlapBott.Requests;
using SlapBott.Services.Dtos;


namespace SlapBott.Handlers
{
    internal class ModelSubmittedHandler(IMediator mediator): INotificationHandler<ModelSubmitted>
    {
        private readonly IMediator _mediator = mediator;

        public async Task Handle(ModelSubmitted notification, CancellationToken cancellationToken)
        {

            var modal = notification.Modal;
            var userId = modal.User.Id;
            string customId = modal.Data.CustomId;

            var registration = await _mediator.Send(new GetRegistration(userId));
            if (registration == null)
            {
                await modal.RespondAsync("you have not joined the bot");
                return;
            }

            var playercharacter = await _mediator.Send(new CreatePlayerCharacter(userId, (int)registration.Id), cancellationToken);

            if (modal.Data.CustomId == null)
            {
                await modal.RespondAsync("ERROR: ModalHandler CustomId Is NUll");
            }

            switch (customId)
            {
                case SubmittedCommands.createcharacter_namedescription:
                    //AssignCharacterNameDescription(modal);
                    await _mediator.Send(new UpdateNameAndDescriptionPlayerCharacter(playercharacter, modal.Data.Components), cancellationToken);
                    //await _mediator.Send(new RespondWithPlayerCharacter(playercharacter, modal.RespondAsync), cancellationToken);

                    //modal.RespondAsync(embed: BuilderReplies.ReplyCreatedCompleteEmbed(
                    //    _playerCharacterDto.Name,
                    //    _playerCharacterDto.Description,
                    //    _playerCharacterDto.SelectedRace.ToString(),
                    //    _playerCharacterDto.SelectedClass.ToString()
                    //    ), ephemeral: true);
                    //SaveAndCompleteCreation();

                    break;
                default:
                    await modal.RespondAsync("ERROR: ModalHandler couldnt find customID");
                    break;
            }


        }
    }


}
