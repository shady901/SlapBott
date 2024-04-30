using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Config;
using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Combat.Models;

namespace SlapBott.Data
{
    public class SlapbottDbContext : DbContext
    {

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Turn> Turns { get; set; }

        public DbSet<CombatState> CombatStates { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<PlayerCharacter> PlayerCharacter { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<RaidBoss> RaidBosses { get; set; }
       public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Stats> PlayersStats { get; set; }
        public DbSet<Race> Races { get; set; }
       public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<EnemyTemplate> EnemyTemplates { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<DiscordGuild> DiscordGuilds { get; set; }
        public SlapbottDbContext(DbContextOptions<SlapbottDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           modelBuilder.ApplyConfiguration<Skill>(new SkillConfiguration());
            modelBuilder.ApplyConfiguration<Turn>(new TurnConfiguration());
            modelBuilder.ApplyConfiguration<CombatState>(new CombatStateConfiguration());
            modelBuilder.ApplyConfiguration<Registration>(new RegistrationConfiguration()); 
            modelBuilder.ApplyConfiguration<PlayerCharacter>(new PlayCharacterConfiguration());
            modelBuilder.ApplyConfiguration<Enemy>(new EnemyConfiguration());
            modelBuilder.ApplyConfiguration<Boss>(new BossConfiguration());
            modelBuilder.ApplyConfiguration<Inventory>(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration<Stats>(new PlayerStatsConfiguration());
            modelBuilder.ApplyConfiguration<Race>(new RacesConfiguration());
            modelBuilder.ApplyConfiguration<CharacterClass>(new CharacterClassConfiguration());
            modelBuilder.ApplyConfiguration<Character>(new CharacterConfiguration());
            modelBuilder.ApplyConfiguration<EnemyTemplate>(new EnemyTemplateConfiguration());
            modelBuilder.ApplyConfiguration<Region>(new RegionConfiguration());
            modelBuilder.ApplyConfiguration<DiscordGuild>(new DiscordGuildConfiguration());

        }

    }
}
