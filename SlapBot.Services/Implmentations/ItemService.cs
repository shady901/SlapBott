using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Implmentations
{


    public static class ItemServiceFactory
    {

        public static IItemService CreateService<T>() where T : item
        {
            if (typeof(t) is Consumable)
            {
                return new ConsumableService();
            }
        }


        public class ConsumableService : ItemService<Consumable, ConsumableDto>, IItemService
        {

        }
        public class MaterialService : ItemService<Material, MaterialDto>, IItemService
        {

        }


        public abstract class ItemService<Tin, Tout> where Tin : Item where Tout : class
        {
            private ItemRepo<Tin, Tout> _itemRepo;
            public ItemService(ItemRepo<Tin, Tout> itemRepo)
            {
                _itemRepo = itemRepo;
            }
            public ItemService<Tin, Tout> ForTypeB()
            {
                if (typeof(Tin) == typeof(Consumable))
                {
                    return (ItemService<Tin, Tout>)this;
                }
                throw new InvalidOperationException("This method can only be used when Tin is of type TypeB.");
            }
        }
    }
}

