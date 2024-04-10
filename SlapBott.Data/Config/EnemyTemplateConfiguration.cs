using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class EnemyTemplateConfiguration : IEntityTypeConfiguration<EnemyTemplate>
    {
        public void Configure(EntityTypeBuilder<EnemyTemplate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Stats)
                       .HasConversion(
                                       v => JsonConvert.SerializeObject(v),
                                       v => JsonConvert.DeserializeObject<Stats>(v)
                                   );
            
            builder.HasData(SeedEnemyTemplates());
        }
        public EnemyTemplate[] SeedEnemyTemplates()
        {
            int Increment = 1;
            List<EnemyTemplate> myEnemies = new();
            myEnemies.Add(new EnemyTemplate() {
                Id = Increment++,
                Name="Skeleton "+Classes.Warrior.ToString(), 
                Description= "a Pile of bones that has formed a silhouette of a Humanoid",
                ClassId = (int)Classes.Warrior,
                RaceId = (int)Races.Undead,
                Stats = new Stats(),
                LearnedSkillIds = new List<int>() {1},
                
                
            });
            return myEnemies.ToArray();
        }
    }
}