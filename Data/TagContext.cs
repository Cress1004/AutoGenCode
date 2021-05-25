using Microsoft.EntityFrameworkCore;

namespace AutoGenCode.Data
{
    public class TagContext : DbContext
    {
        public TagContext(DbContextOptions<TagContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                .HasOne<GenUI>(r => r.GenUI)
                .WithMany(g => g.Regions)
                .HasForeignKey(r => r.GenUIId);
            modelBuilder.Entity<Region>()
             .HasOne<Tag>(r => r.Tag)
             .WithMany(t => t.Regions)
             .HasForeignKey(r => r.TagId);
            modelBuilder.Entity<GenUITag>().HasKey(gt => new { gt.GenUIId, gt.TagId });
            modelBuilder.Entity<GenUITag>()
                .HasOne(gt => gt.GenUI)
                .WithMany(gt => gt.Tags)
                .HasForeignKey(gt => gt.GenUIId);
            modelBuilder.Entity<GenUITag>()
                .HasOne(gt => gt.Tag)
                .WithMany(gt => gt.GenUIs)
                .HasForeignKey(gt => gt.TagId);

        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<GenUI> GenUIs { get; set; }
        //public DbSet<GenUITag> GenUITags { get; set; }
    }
}
