using MediatR;
using SlapBott.Services.Dtos;

namespace SlapBott.Requests
{
    public class GetRegistration(ulong userId) : IRequest<RegistrationDto>
    {
        public ulong UserId { get; } = userId;
    }
}
