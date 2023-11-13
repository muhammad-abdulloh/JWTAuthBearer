using ADars1.Entites;
using Microsoft.EntityFrameworkCore;

namespace ADars1
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
