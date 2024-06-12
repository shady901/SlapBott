using MediatR;
using SlapBott.ItemProject.Items;
using SlapBott.Requests;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.RequestHandlers
{
    public class GenerateNewItemHandler(ItemService itemService) : IRequestHandler<RequestGenerateNewItem,Gear>
    {
        private ItemService _itemService = itemService;

         async Task<Gear> IRequestHandler<RequestGenerateNewItem, Gear>.Handle(RequestGenerateNewItem request, CancellationToken cancellationToken)
        {
            if (_itemService.GenerateRandomItemType()==typeof(Weapon))
            {
               return await Task.FromResult(_itemService.GenerateNewItem<Weapon>(request.ItemParameterBuilder.Build()));
            }
            return await Task.FromResult(_itemService.GenerateNewItem<Armor>(request.ItemParameterBuilder.Build()));
        }
    }
}
