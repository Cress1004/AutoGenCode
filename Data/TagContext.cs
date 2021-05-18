using Microsoft.EntityFrameworkCore;

namespace AutoGenCode.Data
{
    public class TagContext : DbContext
    {
        public TagContext(DbContextOptions<TagContext> options)
            : base(options)
        {

        }

        public DbSet<Tags> Tags { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<GenUI> GenUI { get; set; }
    }
}
