using SlapBott.Data.Enums;
using SlapBott.ItemProject.Builders;
using SlapBott.ItemProject.Items;



namespace SlapBott.ItemProject
{
    public class ItemComputation
    {
        private Random _random = new Random();
        private Random _seedRandom;
     
        
        public ItemComputation()
        {

        }

      

        public T GenerateItem<T>(ItemParameters itemParameters)
        {
            itemParameters.Seed = SetSeededRandom(itemParameters.Seed);
            var equipedType = GenerateEquipTypeFromItemType(typeof(T));
            return (T)Activator.CreateInstance(typeof(T), _seedRandom, equipedType, itemParameters);
        }

        public EquipType GenerateEquipTypeFromItemType(Type type)
        {
            if (type != typeof(Weapon))
            {
                return (EquipType)_seedRandom.Next(1, 5);

            }
            return (EquipType)_seedRandom.Next(6, 8);

        }
         

    
        private int SetSeededRandom(int? seed)
        {
            int _seed = seed ?? GenerateNewSeed();
            _seedRandom = new Random(_seed);
            return _seed;
        }
        private int GenerateNewSeed()
        {
            return _random.Next(9999, int.MaxValue);
        }

        

    }
}
