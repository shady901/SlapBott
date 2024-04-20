using MediatR;
using SlapBott.Requests;
using SlapBott.Services.Dtos;


namespace SlapBott.RequestHandlers
{
    internal class UpdateNameAndDescriptionPlayerCharacterHandler : IRequestHandler<UpdateNameAndDescriptionPlayerCharacter, PlayerCharacterDto?>
    {

        const string character_name = "character_name";
        const string character_description = "character_description";
        public Task<PlayerCharacterDto?> Handle(UpdateNameAndDescriptionPlayerCharacter request, CancellationToken cancellationToken)
        {
            var playerCharacterDto = request.PlayerCharacter;
            var components = request.Components;

            if(playerCharacterDto == null)
            {
                return Task.FromResult(playerCharacterDto);
            }

            playerCharacterDto.Name = components.First(x => x.CustomId == character_name).Value;
            playerCharacterDto.Description = components.First(x => x.CustomId == character_description).Value;


            return Task.FromResult(playerCharacterDto);

        }
    }
}
