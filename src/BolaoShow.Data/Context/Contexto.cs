using BolaoShow.Bussiness.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BolaoShow.Data.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Aposta> Apostas { get; set; }
        public DbSet<Sorteio> Sorteios { get; set; }
        public DbSet<Aposta_Sorteio> Aposta_Sorteios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            builder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(builder);
        }

    }
}
