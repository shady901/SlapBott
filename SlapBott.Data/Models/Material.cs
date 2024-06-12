using SlapBott.Data.Enums;

namespace SlapBott.Data.Models
{
    public class Material: Item
    {
        public ProffesionTypes[] CanBeUsedInProffesions { get; set; }      
        
    }
}
