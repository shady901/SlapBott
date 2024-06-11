using SlapBott.Data.Enums;

namespace SlapBott.Data.Models
{
    public class Material: Item
    {
        public ProffessionType[] CanBeUsedInProffesions { get; set; }      
        
    }
}
