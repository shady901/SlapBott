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
    public class SavePlayerCharacterDtoHandler(IMediator mediator,PlayerCharacterService playerCharacterService) : IRequestHandler<RequestSavePlayerCharacterDto, bool>
    {
        private readonly IMediator mediator = mediator;

        private PlayerCharacterService _playerCharacterService = playerCharacterService;

        public async Task<bool> Handle(RequestSavePlayerCharacterDto request, CancellationToken cancellationToken)
        {
            try
            {
               await _playerCharacterService.SaveCharacter(request.CharacterDto);

            }
            catch (Exception ex)
            {
                Console.WriteLine("SavePlayerCharacterDtoHandler: "+ex);
            }
         
            return false;
        }
    }
}
