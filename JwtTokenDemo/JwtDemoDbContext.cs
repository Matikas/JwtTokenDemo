using Microsoft.EntityFrameworkCore;

namespace JwtTokenDemo
{
    public class JwtDemoDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public JwtDemoDbContext(DbContextOptions<JwtDemoDbContext> options) : base(options)
        {

        }
    }
}
