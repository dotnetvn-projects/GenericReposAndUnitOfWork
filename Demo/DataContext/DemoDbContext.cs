using Microsoft.EntityFrameworkCore;

namespace Demo.DataContext
{
    public class DemoDbContext:DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
         : base(options)
        { }

        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
