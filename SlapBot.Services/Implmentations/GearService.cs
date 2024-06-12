using SlapBott.Data.Repos;
using SlapBott.ItemProject;
using SlapBott.ItemProject.Builders;
using SlapBott.ItemProject.Items;

using Gear = SlapBott.ItemProject.Items.Gear;

namespace SlapBott.Services.Implmentations
{
    public class GearService
    {
   
        private ItemComputation _itemComputation = new();
        public GearService() 
        {
          
        
        }

        public T GenerateNewItem<T>(ItemParameters itemParameters) where T:Gear
        {   
           return _itemComputation
               .GenerateItem<T>(itemParameters);
        }
        public Type GenerateRandomItemType()
        {
            Type[] types = {typeof(Armor),typeof(Weapon)};
            Random random   = new Random();
           return types[random.Next(2)];
        }
       
      
    }
}
