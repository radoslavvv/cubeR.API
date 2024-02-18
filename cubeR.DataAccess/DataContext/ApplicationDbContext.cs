using Microsoft.EntityFrameworkCore;

namespace cubeR.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Solve> Solves { get; set; }

        public DbSet<Cube> Cubes { get; set; }
    }
}
