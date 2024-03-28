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
            builder.HasData(SeedingSkills());


          
        }
        public Skill[] SeedingSkills()
        {
            return
            [new Skill()
            {
                Id = 1,
                Name = "Strike",
                Description = "You use All your force to create a Powerfull Strike",
                ElementalType = ElementalType.Physical,
                RequiredWeaponType = null,
                    StatTypeRatio = new Dictionary<StatType, double> 
                    {
                        {StatType.Strength, 0.4 },
                        {StatType.Dexterity, 0.3 },
                        {StatType.Intelligence, 0.25 }
                    }
                }
            ];
        
        }
    }
}