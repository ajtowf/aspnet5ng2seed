using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace aspnet5ng2seed.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\ProjectsV13;Database=aspnet5ng2seed;Trusted_Connection=true;MultipleActiveResultSets=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
