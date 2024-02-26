using Microsoft.EntityFrameworkCore;

namespace Slappbott.Database
{
    public class SlappbottDbContext: DbContext
    {

        public SlappbottDbContext(DbContextOptions<SlappbottDbContext> options) : base(options) { 
        
        }

    }
}
