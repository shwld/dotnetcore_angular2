using Microsoft.EntityFrameworkCore;

namespace core_angular2.Models
{
    public class DefaultContext : DbContext
    {
        public static DefaultContext GetBy(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DefaultContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DefaultContext(optionsBuilder.Options);
        }

        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        { }

        public DbSet<Note> Notes { get; set; }
    }
}
