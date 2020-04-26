using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BolaoShow.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CustomIdentity> CustomIdentity { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //      modelBuilder.HasDefaultSchema("identity");
        //}
    }
}
