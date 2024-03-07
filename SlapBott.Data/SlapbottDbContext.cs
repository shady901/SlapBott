using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Config;
using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;

namespace SlapBott.Data
{
    public class SlapbottDbContext : DbContext
    {

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Turn> Turns { get; set; }

        public DbSet<CombatState> CombatStates { get; set; }

        public DbSet<Registration> User { get; set; }


        //public DbSet<Character> PCharacter { get; set; }
        //public DbSet<Enemy> Enemies { get; set; }

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



            //modelBuilder.ApplyConfiguration<PlayerCharacter>(new PlayCharacterConfiguration());


            //modelBuilder.Entity<Registration>()
            //    .ToTable("User");



        }

    }
}
