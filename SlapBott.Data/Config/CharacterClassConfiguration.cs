using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    internal class CharacterClassConfiguration : IEntityTypeConfiguration<CharacterClass>
    {
        public void Configure(EntityTypeBuilder<CharacterClass> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Character).WithOne(x => x.CharacterClass).HasForeignKey(x => x.ClassId);

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
            builder.HasData(SeedClasses());


        }
        public CharacterClass[] SeedClasses()
        {
            List<CharacterClass> myRaces = new();
            myRaces.Add(new CharacterClass()
            {
                Id = (int)Classes.Warrior,
                Name = Classes.Warrior,
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
                   {StatType.Strength, 1},
               }
            });
            myRaces.Add(new CharacterClass()
            {
                Id = (int)Classes.Mage,
                Name = Classes.Mage,
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
                   {StatType.SpellPower, 1},
                   { StatType.Intelligence ,1}
               }


            });




            return myRaces.ToArray();
        }
    
    }
}