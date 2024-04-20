using MediatR;
using SlapBott.Services.Dtos;

namespace SlapBott.Requests
{
    internal class GetRegistration(ulong userId) : IRequest<RegistrationDto>
    {
        public ulong UserId { get; } = userId;
    }
}
