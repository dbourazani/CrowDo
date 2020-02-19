using Microsoft.EntityFrameworkCore;

namespace TinyCrm.Core.Data
{
    public class TinyCrmDbContext : DbContext
    {
        private readonly string connectionString_;

        public TinyCrmDbContext()
        {
            connectionString_ =
                "Server =localhost; Database =crowDo; " +
                "Integrated Security=SSPI;Persist Security Info=False;";
        }

        public TinyCrmDbContext(string connString)
        {
            connectionString_ = connString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<CrowDo.Models.User>()
                .ToTable("User", "core");
            
            modelBuilder
                .Entity<CrowDo.Models.Funding>()
                .ToTable("Funding", "core");
            
            modelBuilder
                .Entity<CrowDo.Models.Project>()
                .ToTable("Project", "core");

            modelBuilder
                .Entity<CrowDo.Models.Project>()
                .HasIndex(c => c.VatNumber)
                .IsUnique();

            modelBuilder
                .Entity<CrowDo.Models.Project>()
                .Property(c => c.VatNumber)
                .HasMaxLength(9)
                .IsFixedLength();
 

        }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString_);
        }
    }
}
