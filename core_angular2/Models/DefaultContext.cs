using Microsoft.EntityFrameworkCore;

namespace core_angular2.Models
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        { }

        public DbSet<Note> Notes { get; set; }
    }
}
