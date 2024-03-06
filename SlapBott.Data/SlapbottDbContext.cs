using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;

namespace SlapBott.Data
{
    public class SlapbottDbContext : DbContext
    {
        public DbSet<Registration> User { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<CombatState> CombatStates { get; set; }
        public DbSet<Enemy> Enemies { get; set; }

        public SlapbottDbContext(DbContextOptions<SlapbottDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerCharacter>()
                        .HasOne(c => c.Registration)
                        .WithMany(r => r.UserCharacters)
                        .HasForeignKey(r => r.DiscordID);

            modelBuilder.Entity<Registration>()
                .ToTable("User");


            //modelBuilder.Entity<Registration>()
            //    .HasMany<Character>( r => r.UserCharacters)
            //    .WithOne(r=>r.Registration)
            //    .HasForeignKey(r =>r.DiscordID);



        }

    }
}
