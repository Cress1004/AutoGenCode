using Microsoft.EntityFrameworkCore;

namespace AutoGenCode.Data
{
    public class ElementContext : DbContext
    {
        public ElementContext(DbContextOptions<ElementContext> options)
            : base(options)
        {

        }

        public DbSet<Elements> Elements { get; set; }
    }
}
