using MediatR;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Requests
{
    internal class CreatePlayerCharacter(ulong userId, int registrationId) : IRequest<PlayerCharacterDto>
    {
        public ulong UserId { get; } = userId;
        public int RegistrationId { get; } = registrationId;
    }
}
