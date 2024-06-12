using MediatR;
using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.RequestHandlers
{
    public class GetMaterialOrConsumableFromItemIdHandler<Tout>(ItemRepo<Tout> itemRepo) : IRequestHandler<RequestGetMaterialOrConsumableFromItemId<Tout>, Tout> where Tout : Item
    {
        private ItemRepo<Tout> _itemRepo = itemRepo;
        async Task<Tout> IRequestHandler<RequestGetMaterialOrConsumableFromItemId<Tout>, Tout>.Handle(RequestGetMaterialOrConsumableFromItemId<Tout> request, CancellationToken cancellationToken)
        {
         return _itemRepo.GetById(request.Id);
        }
    }
}
