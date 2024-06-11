using MediatR;
using SlapBott.Requests;
using SlapBott.Services;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.RequestHandlers
{
    public class ConvertToEquipmentFromLootTableItemHandler(IMediator mediator) : IRequestHandler<RequestConvertToEquipmentFromLootTableItemDto, EquipmentDto>
    {
        private IMediator _mediator = mediator;

      
        public Task<EquipmentDto> Handle(RequestConvertToEquipmentFromLootTableItemDto request, CancellationToken cancellationToken)
        {




        }
    }
}
