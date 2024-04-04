using Newtonsoft.Json.Linq;
using SlapBott.Data.Enums;
using SlapBott.ItemProject.Enums;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Markup;

namespace SlapBott.ItemProject
{
    public enum AffixType
    { 
        none = 0,
        Prefix = 1,
        Suffix = 2,
    }
    public class ItemAffix
    {
        private bool _isWeapon;
        private ItemRarety _rarety { get; set; }

        private Random _seededRandom;
        private AffixRangeAttribute? _statRange { get; set; }
        public AffixType AffixType {  get; set; } 
        public int StatValue { get; set; }
        public Enum StatEnum { get; set; }
        public StatType StatType { get; set; }
        private Dictionary<ItemRarety, int> _raretyModifier = new Dictionary<ItemRarety, int>
          {
           { ItemRarety.Normal, 0 },   
           { ItemRarety.Uncommon, 1 },
           { ItemRarety.Rare, 2 },     
           { ItemRarety.Epic, 4 },    
           { ItemRarety.Legendary,8 } 
          };

        public ItemAffix(ItemRarety itemRarety, bool IsWeapon, Random SeededRandom, AffixType affix)
        {
            AffixType = affix;
            _seededRandom = SeededRandom;
            _isWeapon = IsWeapon;
            _rarety = itemRarety;
        }

        public ItemAffix GenerateItemAffix()
        {   
            GetRange();
            RandomStatValueBasedOfRange();
            AssignStatypeBasedOnEnumSelection();
            return this;
        }

      

        private void GetRange()
        {
            //gets the range from the enum        
            StatEnum = GetRandomAffixBasedOnProperties();
            FieldInfo fieldInfo = StatEnum.GetType().GetField(StatEnum.ToString());
           _statRange = (AffixRangeAttribute)fieldInfo.GetCustomAttribute(typeof(AffixRangeAttribute), false);
        }


        private Enum GetRandomAffixBasedOnProperties()
        {
            Type affixType = _isWeapon ? 
                (AffixType == AffixType.Prefix ? typeof(WeaponPrefix) : typeof(WeaponSuffix)) :
                (AffixType == AffixType.Prefix ? typeof(ArmorPrefix) : typeof(ArmorSuffix));
           
            return GetAffix(affixType);

        }

        private Enum GetAffix(Type affix) 
        {
            Array statType = Enum.GetValues(affix);

            int index = _seededRandom.Next(0,statType.Length);

            return (Enum)statType.GetValue(index);
             
            
        }
        private void RandomStatValueBasedOfRange()
        {
           StatValue =  _seededRandom.Next(_statRange.Min + _raretyModifier[_rarety] , _statRange.Max + _raretyModifier[_rarety] + 1);
        }

        private void AssignStatypeBasedOnEnumSelection()
        {
          StatType = (StatType)Enum.Parse(typeof(StatType), StatEnum.ToString());
        }
    }
}