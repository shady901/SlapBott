using SlapBott.Data.Enums;



namespace SlapBott.Data.Models
{
    public class Skill
    {
        public int Id { get; set; }        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ElementalType ElementalType { get; set; }
        public WeaponType? RequiredWeaponType { get; set; }
        public Dictionary<StatType,double> StatTypeRatio { get; set; }
        //buffs debufs



       
        
    }
}
