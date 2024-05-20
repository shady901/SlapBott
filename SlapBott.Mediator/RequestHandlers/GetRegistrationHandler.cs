using MediatR;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;


namespace SlapBott.RequestHandlers
{
    public class GetRegistrationHandler(RegistrationService registeredServices) : IRequestHandler<GetRegistration, RegistrationDto>
    {
        private readonly RegistrationService _registrationService = registeredServices;
                
        public Task<RegistrationDto> Handle(GetRegistration request, CancellationToken cancellationToken)
        {
            var reg = RegistrationDto.FromUserDB(_registrationService.GetUserByDiscordId(request.UserId)); ;
            
            return Task.FromResult(reg);
        }
    }
}
