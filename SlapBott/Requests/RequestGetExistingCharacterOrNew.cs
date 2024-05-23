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
    public class RequestGetExistingCharacterOrNew(ulong Id,int? characterId = null,bool? Temp=null): IRequest<PlayerCharacterDto>
    {
        public ulong UserId { get; } = Id;
        public int? CharId { get; } = characterId;
        public bool? TempUser { get; } =Temp;    
    }
}
