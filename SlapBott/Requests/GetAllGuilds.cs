using MediatR;
using SlapBott.Data.Models;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Requests
{
    public class GetAllGuilds() : IRequest<IEnumerable<DiscordGuildDto>>
    {
     
    }
}
