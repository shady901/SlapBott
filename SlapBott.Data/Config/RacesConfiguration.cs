using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class RacesConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Character).WithOne(x=>x.Race).HasForeignKey(x=>x.RaceId);

            builder.Property(x => x.PerLevelStats)
                        .HasConversion(
                                        v => JsonConvert.SerializeObject(v),
                                        v => JsonConvert.DeserializeObject<Dictionary<StatType, int>>(v)
                                    );
            builder.Property(x => x.BaseStats)
                        .HasConversion(
                                        v => JsonConvert.SerializeObject(v),
                                        v => JsonConvert.DeserializeObject<Dictionary<StatType, int>>(v)
                                    );
            builder.HasData(SeedRaces());

        }
        public Race[] SeedRaces()
        {
            List<Race> myRaces = new();
            myRaces.Add(new Race()
            {
                Id = (int)Races.Elf,
                Name = Races.Elf,
                BaseStats =
               new Dictionary<StatType, int>
               {
               {StatType.Dexterity, 4},
               {StatType.Strength, 4},
               {StatType.Intelligence,4},
               {StatType.CritChance,0 },
               {StatType.MaxHealth,100},
               {StatType.Health,100},
               {StatType.AttackDamage,0},
               {StatType.ArmorRating,0},
               {StatType.DodgeChance,5 },
                
               //%'s----------------
               {StatType.ChaosResistance,0},
               {StatType.FireResistance,0},
               {StatType.PhysicalResistance,0},
               {StatType.FrostResistance,0},
               {StatType.LightningResistance,0},
               {StatType.SpellPower,0},
               {StatType.PhysicalDamage,0},
               {StatType.ElementalDamage,0},
               {StatType.Speed,0},
               {StatType.ChaosDamage,0},

               },
                PerLevelStats = new Dictionary<StatType, int>
               {
                   {StatType.Dexterity, 1},

               }
            });
               myRaces.Add(new Race()
                {
                    Id = (int)Races.Human,
                    Name = Races.Human,
                    BaseStats =
               new Dictionary<StatType, int>
               {
               {StatType.Dexterity, 4},
               {StatType.Strength, 4},
               {StatType.Intelligence,4},
               {StatType.CritChance,0 },
               {StatType.MaxHealth,100},
               {StatType.Health,100},
               {StatType.AttackDamage,0},
               {StatType.ArmorRating,0},
               {StatType.DodgeChance,5 },
                
               //%'s----------------
               {StatType.ChaosResistance,0},
               {StatType.FireResistance,0},
               {StatType.PhysicalResistance,0},
               {StatType.FrostResistance,0},
               {StatType.LightningResistance,0},
               {StatType.SpellPower,0},
               {StatType.PhysicalDamage,0},
               {StatType.ElementalDamage,0},
               {StatType.Speed,0},
               {StatType.ChaosDamage,0},

               },
                    PerLevelStats = new Dictionary<StatType, int>
               {
                   {StatType.MaxHealth, 20},

               }
                
              
                });
            myRaces.Add(new Race()
            {
                Id = (int)Races.Undead,
                Name = Races.Undead,
                BaseStats =
              new Dictionary<StatType, int>
              {
               {StatType.Dexterity, 4},
               {StatType.Strength, 4},
               {StatType.Intelligence,4},
               {StatType.CritChance,0 },
               {StatType.MaxHealth,100},
               {StatType.Health,100},
               {StatType.AttackDamage,0},
               {StatType.ArmorRating,0},
               {StatType.DodgeChance,5 },
                
               //%'s----------------
               {StatType.ChaosResistance,0},
               {StatType.FireResistance,0},
               {StatType.PhysicalResistance,0},
               {StatType.FrostResistance,0},
               {StatType.LightningResistance,0},
               {StatType.SpellPower,0},
               {StatType.PhysicalDamage,0},
               {StatType.ElementalDamage,0},
               {StatType.Speed,0},
               {StatType.ChaosDamage,0},

              },
                PerLevelStats = new Dictionary<StatType, int>
               {
                   {StatType.MaxHealth, 20},

               }


            });




            return myRaces.ToArray();
        }
    }
}