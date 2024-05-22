using Discord;
using Discord.WebSocket;
using MediatR;
using SlapBott.CommandsEnum;
using SlapBott.Notifications;
using SlapBott.Requests;
using SlapBott.Services.Dtos;


namespace SlapBott.Handlers
{
    public class ButtonHandler(IMediator mediator) : INotificationHandler<ButtonExecuted>
    {
        private IMediator _mediator = mediator;
        private SocketMessageComponent _button;
        public async Task Handle(ButtonExecuted notification, CancellationToken cancellationToken)
        {
            _button = notification.socketButtonComponent;
            SocketMessageComponentData buttonData = _button.Data;
            string[] CustomId = _button.Data.CustomId.Split(' ');
            CompareCustomIdAndBeginMethods(CustomId[0],int.Parse(CustomId[1]));

        }

        private void CompareCustomIdAndBeginMethods(string customId, int id)
        {
            if (Enum.TryParse<ButtonCustomIds>(customId, out var buttonId))
            {
                switch (buttonId)
                {
                    case ButtonCustomIds.JoinRaid:
                        JoinRaid(id);
                        break;

                    // Add more cases here as needed
                    // case ButtonCustomIds.SomeOtherAction:
                    //     SomeOtherAction();
                    //     break;

                    default:
                        // Optional: Handle unexpected cases if necessary
                        Console.WriteLine($"Unhandled ButtonCustomId: {customId}");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid ButtonCustomId: {customId}");
                // Optionally handle invalid IDs, log, or throw an exception
            }
        }
        private async void JoinRaid(int raidBossId)
        {
//probs check for active character

            RaidBossDto raidBossDto = await _mediator.Send(new RequestGetEnemyCharacter(raidBossId));
            PlayerCharacterDto player = await _mediator.Send(new RequestGetExistingCharacterOrNew(_button.User.Id));
            await _mediator.Publish(new CreateAndAssignPlayerStateNotification(player.Id, raidBossDto.StateId));
            player.StateId = raidBossDto.StateId;
            await _mediator.Send(new RequestSavePlayerCharacterDto(player));
            //check if combat has started reply with fight has already begun and dismiss
            //request to be inputed into combat state

        }


    }
}
