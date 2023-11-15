using JWT.Entyties;
using Microsoft.EntityFrameworkCore;

namespace JWT.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<User> Users { get; set; }
    }
}
