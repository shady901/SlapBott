using MediatR;
using SlapBott.Requests;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.RequestHandlers
{
    public class SaveRegistrationDtoHandler(IMediator mediator, RegistrationService registration) : IRequestHandler<SaveRegistrationRequest>
    {
        private IMediator _mediator = mediator;
        private RegistrationService _registrationService = registration;
        public Task Handle(SaveRegistrationRequest request, CancellationToken cancellationToken)
        {
            _registrationService.SaveRegistration(request.Registration.ToRegistration(_registrationService.GetUserByDiscordId(request.Registration.discordUserID)));
           return Task.CompletedTask;
        }
    }
}
