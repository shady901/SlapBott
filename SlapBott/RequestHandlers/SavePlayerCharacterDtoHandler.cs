using MediatR;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.RequestHandlers
{
    public class SavePlayerCharacterDtoHandler(IMediator mediator,PlayerCharacterService playerCharacterService) : IRequestHandler<RequestSavePlayerCharacterDto, PlayerCharacterDto>
    {
        private readonly IMediator mediator = mediator;

        private PlayerCharacterService _playerCharacterService = playerCharacterService;

        public async Task<PlayerCharacterDto> Handle(RequestSavePlayerCharacterDto request, CancellationToken cancellationToken)
        {
            try
            {
             return  await _playerCharacterService.SaveCharacter(request.CharacterDto);
             }
            catch (Exception ex)
            {
                Console.WriteLine("SavePlayerCharacterDtoHandler: "+ex);
            }
            return new PlayerCharacterDto();
            
        }
    }
}
