using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace SlapBott.Data
{
    public class SlapBottDbContextFactory : IDesignTimeDbContextFactory<SlapbottDbContext>
    {

        public SlapbottDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SlapbottDbContext>();

            optionsBuilder.UseSqlite(Properties.Resources.DbConnection);

            return new SlapbottDbContext(optionsBuilder.Options);
        }
    }
}
