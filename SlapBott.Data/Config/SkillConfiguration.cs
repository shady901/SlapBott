using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StatTypeRatio)
                            .HasConversion(
                                            v => JsonConvert.SerializeObject(v),
                                            v => JsonConvert.DeserializeObject<Dictionary<StatType, double>>(v)
                                        );



            //builder.HasData([
            //    new Skill()
            //        {
            //            Id = 1,
            //            Description = "",
            //            Name = "Name",
            //            ElementalType = ElementalType.Fire,
            //            StatTypeRatio = new Dictionary<StatType, double>() { { StatType.Speed, 1 } }
            //        },
            //    new Skill()
            //    {
            //        Id = 2,
            //        Description = "",
            //        Name = "Name",
            //        ElementalType = ElementalType.Fire,
            //        StatTypeRatio = new Dictionary<StatType, double>() { { StatType.Speed, 1 } }
            //    }



                //]);


        }

    }
}