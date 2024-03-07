
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class DamageTarget
    {
        public int Id { get; set; }
        public int Damage { get; set; }

        public int TargetId { get; set; }

        [ForeignKey("TargetId")]
        public virtual Character Target { get; set; }
    }
}
