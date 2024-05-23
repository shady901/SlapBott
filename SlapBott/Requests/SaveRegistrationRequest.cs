using Discord.Net;
using MediatR;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Requests
{
    public class SaveRegistrationRequest(RegistrationDto registration) : MediatR.IRequest
    {
        public RegistrationDto Registration = registration;
    }
}
