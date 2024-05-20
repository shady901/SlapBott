using Discord;
using MediatR;
using SlapBott.Requests;
using SlapBott.Services.Dtos;

namespace SlapBott.RequestHandlers
{
    public class RespondWithPlayerCharacterHandler : IRequestHandler<RespondWithPlayerCharacter, bool>
    {
        public Task<bool> Handle(RespondWithPlayerCharacter request, CancellationToken cancellationToken)
        {
           var respond = request.RespondAsync;
            var playerCharacter = request.Playercharacter;
            if (playerCharacter != null)
            {
                var embed = BuilderReplies.ReplyCreatedCompleteEmbed(
                            playerCharacter.Name,
                            playerCharacter.Description,
                            playerCharacter.SelectedRace.ToString(),
                            playerCharacter.SelectedClass.ToString()
                    );

                respond(null, null, false, true, null, null, embed);

                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
