using Jigsaw.MiniProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Jigsaw.MiniProject.Data
{
    public class TreeContext : DbContext, ITreeContext
    {
        public TreeContext(DbContextOptions<TreeContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DbConfiguration.ConfigureEntities(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=JigsawDemo;Integrated Security=sspi;");
            }
        }

        public DbSet<TreeItem> TreeItems { get; set; }
    }
}
